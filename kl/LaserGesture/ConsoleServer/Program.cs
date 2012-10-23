using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using Proshot.CommandServer;

namespace ConsoleServer
{
	public class Program
	{
		private List<ClientManager> _clients;
		private BackgroundWorker _bwListener;
		private Socket _listenerSocket;
		private IPAddress _serverIp;
		private int _serverPort;

		/// <summary>
		/// Start the console server.
		/// </summary>
		/// <param name="args">These are optional arguments.Pass the local ip address of the server as the first argument and the local port as the second argument.</param>
		public static void Main(string[] args)
		{
			//var f = new motion.MainForm();
			//f.Show();

			var progDomain = new Program { _clients = new List<ClientManager>() };

			if (args.Length == 0)
			{
				progDomain._serverPort = 8000;
				progDomain._serverIp = IPAddress.Any;
			}
			if (args.Length == 1)
			{
				progDomain._serverIp = IPAddress.Parse(args[0]);
				progDomain._serverPort = 8000;
			}
			if (args.Length == 2)
			{
				progDomain._serverIp = IPAddress.Parse(args[0]);
				progDomain._serverPort = int.Parse(args[1]);
			}

			progDomain._bwListener = new BackgroundWorker { WorkerSupportsCancellation = true };
			progDomain._bwListener.DoWork += progDomain.StartToListen;
			progDomain._bwListener.RunWorkerAsync();

			Console.WriteLine("*** Listening on port {0}{1}{2} started.Press ENTER to shutdown server. ***\n", progDomain._serverIp, ":", progDomain._serverPort);

			Console.ReadLine();

			progDomain.DisconnectServer();
		}

		private void StartToListen(object sender, DoWorkEventArgs e)
		{
			_listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			_listenerSocket.Bind(new IPEndPoint(_serverIp, _serverPort));
			_listenerSocket.Listen(200);
			while (true)
			{
				CreateNewClientManager(_listenerSocket.Accept());
			}
		}

		private void CreateNewClientManager(Socket socket)
		{
			var newClientManager = new ClientManager(socket);
			newClientManager.CommandReceived += CommandReceived;
			newClientManager.Disconnected += ClientDisconnected;
			CheckForAbnormalDc(newClientManager);
			_clients.Add(newClientManager);
			UpdateConsole("Connected.", newClientManager.IP, newClientManager.Port);
		}

		private void CheckForAbnormalDc(ClientManager mngr)
		{
			if (RemoveClientManager(mngr.IP))
			{
				UpdateConsole("Disconnected.", mngr.IP, mngr.Port);
			}
		}

		void ClientDisconnected(object sender, ClientEventArgs e)
		{
			if (RemoveClientManager(e.IP))
			{
				UpdateConsole("Disconnected.", e.IP, e.Port);
			}
		}

		private bool RemoveClientManager(IPAddress ip)
		{
			lock (this)
			{
				var index = IndexOfClient(ip);
				if (index != -1)
				{
					var name = _clients[index].ClientName;
					_clients.RemoveAt(index);

					//Inform all clients that a client had been disconnected.
					var cmd = new Command(CommandType.ClientLogOffInform, IPAddress.Broadcast) {SenderName = name, SenderIP = ip};
					BroadCastCommand(cmd);
					return true;
				}
				return false;
			}
		}

		private int IndexOfClient(IPAddress ip)
		{
			var index = -1;
			foreach (var cMngr in _clients)
			{
				index++;
				if (cMngr.IP.Equals(ip))
					return index;
			}
			return -1;
		}

		private void CommandReceived(object sender, CommandEventArgs e)
		{
			//When a client connects to the server sends a 'ClientLoginInform' command with a MetaData in this format :
			//"RemoteClientIP:RemoteClientName". With this information we should set the name of ClientManager and then
			//Send the command to all other remote clients.
			if (e.Command.CommandType == CommandType.ClientLoginInform)
			{
				SetManagerName(e.Command.SenderIP, e.Command.MetaData);
			}

			//If the client asked for existance of a name,answer to it's question.
			if (e.Command.CommandType == CommandType.IsNameExists)
			{
				var isExixsts = IsNameExists(e.Command.SenderIP, e.Command.MetaData);
				SendExistanceCommand(e.Command.SenderIP, isExixsts);
				return;
			}

			//If the client asked for list of a logged in clients,replay to it's request.
			if (e.Command.CommandType == CommandType.SendClientList)
			{
				SendClientListToNewClient(e.Command.SenderIP);
				return;
			}

			if (e.Command.Target.Equals(IPAddress.Broadcast))
				BroadCastCommand(e.Command);
			else
				SendCommandToTarget(e.Command);

		}

		private void SendExistanceCommand(IPAddress targetIP, bool isExists)
		{
			var cmdExistance = new Command(CommandType.IsNameExists, targetIP, isExists.ToString())
			{
				SenderIP = _serverIp,
				SenderName = "Server"
			};
			SendCommandToTarget(cmdExistance);
		}

		private void SendClientListToNewClient(IPAddress newClientIp)
		{
			foreach (var mngr in _clients)
			{
				if (mngr.Connected && !mngr.IP.Equals(newClientIp))
				{
					var cmd = new Command(CommandType.SendClientList, newClientIp)
					{
						MetaData = mngr.IP + ":" + mngr.ClientName,
						SenderIP = _serverIp,
						SenderName = "Server"
					};
					SendCommandToTarget(cmd);
				}
			}
		}

		private string SetManagerName(IPAddress remoteClientIp, string nameString)
		{
			var index = IndexOfClient(remoteClientIp);
			if (index != -1)
			{
				var name = nameString.Split(new[] { ':' })[1];
				_clients[index].ClientName = name;
				return name;
			}
			return "";
		}
		private bool IsNameExists(IPAddress remoteClientIp, string nameToFind)
		{
			foreach (var mngr in _clients)
				if (mngr.ClientName == nameToFind && !mngr.IP.Equals(remoteClientIp))
				{
					return true;
				}
			return false;
		}

		private void BroadCastCommand(Command cmd)
		{
			foreach (var mngr in _clients)
				if (!mngr.IP.Equals(cmd.SenderIP))
				{
					mngr.SendCommand(cmd);
				}
		}

		private void SendCommandToTarget(Command cmd)
		{
			foreach (var mngr in _clients)
				if (mngr.IP.Equals(cmd.Target))
				{
					mngr.SendCommand(cmd);
					return;
				}
		}
		private static void UpdateConsole(string status, IPAddress IP, int port)
		{
			Console.WriteLine("Client {0}{1}{2} has been {3} ( {4}|{5} )", IP, ":", port, status, DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
		}

		public void DisconnectServer()
		{
			if (_clients != null)
			{
				foreach (var mngr in _clients)
					mngr.Disconnect();

				_bwListener.CancelAsync();
				_bwListener.Dispose();
				_listenerSocket.Close();
				GC.Collect();
			}
		}
	}
}
