using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.Windows.Forms;

namespace Proshot.CommandClient
{
	/// <summary>
	/// The command client command class.
	/// </summary>
	public class CMDClient
	{
		private Socket _clientSocket;
		private NetworkStream _networkStream;
		private BackgroundWorker _bwReceiver;
		private readonly IPEndPoint _serverEp;

		/// <summary>
		/// [Gets] The value that specifies the current client is connected or not.
		/// </summary>
		public bool Connected
		{
			get 
			{
				return _clientSocket != null && _clientSocket.Connected;
			}
		}
		/// <summary>
		/// [Gets] The IP address of the remote server.If this client is disconnected,this property returns IPAddress.None.
		/// </summary>
		public IPAddress ServerIp
		{
			get
			{
				return Connected ? _serverEp.Address : IPAddress.None;
			}
		}

		/// <summary>
		/// [Gets] The comunication port of the remote server.If this client is disconnected,this property returns -1.
		/// </summary>
		public int ServerPort
		{
			get { return Connected ? _serverEp.Port : -1; }
		}
		/// <summary>
		/// [Gets] The IP address of this client.If this client is disconnected,this property returns IPAddress.None.
		/// </summary>
		public IPAddress Ip
		{
			get 
			{
				return Connected ? ((IPEndPoint)_clientSocket.LocalEndPoint).Address : IPAddress.None;
			}
		}
		/// <summary>
		/// [Gets] The comunication port of this client.If this client is disconnected,this property returns -1.
		/// </summary>
		public int Port
		{
			get { return Connected ? ((IPEndPoint) _clientSocket.LocalEndPoint).Port : -1; }
		}

		/// <summary>
		/// [Gets/Sets] The string that will sent to the server and then to other clients, to identify this client to them.
		/// </summary>
		public string NetworkName { get; set; }

		#region Contsructors
		/// <summary>
		/// Cretaes a command client instance.
		/// </summary>
		/// <param name="server">The remote server to connect.</param>
		/// <param name="netName">The string that will send to the server and then to other clients, to identify this client to all clients.</param>
		public CMDClient(IPEndPoint server, string netName)
		{
			_serverEp = server;
			NetworkName = netName;
			System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;
		}

		/// <summary>
		/// Cretaes a command client instance.
		/// </summary>
		///<param name="serverIP">The IP of remote server.</param>
		///<param name="port">The port of remote server.</param>
		/// <param name="netName">The string that will send to the server and then to other clients, to identify this client to all clients.</param>
		public CMDClient(IPAddress serverIP, int port, string netName)
		{
			_serverEp = new IPEndPoint(serverIP, port);
			NetworkName = netName;
			System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;
		}

		#endregion

		#region Private Methods

		private void NetworkChange_NetworkAvailabilityChanged(object sender, System.Net.NetworkInformation.NetworkAvailabilityEventArgs e)
		{
			if (!e.IsAvailable)
			{
				OnNetworkDead(new EventArgs());
				OnDisconnectedFromServer(new EventArgs());
			}
			else
			{
				OnNetworkAlived(new EventArgs());
			}
		}

		private void StartReceive(object sender, DoWorkEventArgs e)
		{
			while (_clientSocket.Connected)
			{
				//Read the command's Type.
				var buffer = new byte[4];
				var readBytes = _networkStream.Read(buffer, 0, 4);
				if (readBytes == 0)
				{
					break;
				}
				var cmdType = (CommandType)(BitConverter.ToInt32(buffer, 0));

				//Read the command's sender ip size.
				buffer = new byte[4];
				readBytes = _networkStream.Read(buffer, 0, 4);
				if (readBytes == 0)
				{
					break;
				}
				var senderIpSize = BitConverter.ToInt32(buffer, 0);

				//Read the command's sender ip.
				buffer = new byte[senderIpSize];
				readBytes = _networkStream.Read(buffer, 0, senderIpSize);
				if (readBytes == 0)
				{
					break;
				}
				var senderIp = IPAddress.Parse(Encoding.ASCII.GetString(buffer));

				//Read the command's sender name size.
				buffer = new byte[4];
				readBytes = _networkStream.Read(buffer, 0, 4);
				if (readBytes == 0)
				{
					break;
				}
				var senderNameSize = BitConverter.ToInt32(buffer, 0);

				//Read the command's sender name.
				buffer = new byte[senderNameSize];
				readBytes = _networkStream.Read(buffer, 0, senderNameSize);
				if (readBytes == 0)
				{
					break;
				}
				var senderName = Encoding.Unicode.GetString(buffer);

				//Read the command's target size.
				buffer = new byte[4];
				readBytes = _networkStream.Read(buffer, 0, 4);
				if (readBytes == 0)
				{
					break;
				}
				var ipSize = BitConverter.ToInt32(buffer, 0);

				//Read the command's target.
				buffer = new byte[ipSize];
				readBytes = _networkStream.Read(buffer, 0, ipSize);
				if (readBytes == 0)
				{
					break;
				}
				var cmdTarget = Encoding.ASCII.GetString(buffer);

				//Read the command's MetaData size.
				buffer = new byte[4];
				readBytes = _networkStream.Read(buffer, 0, 4);
				if (readBytes == 0)
					break;
				var metaDataSize = BitConverter.ToInt32(buffer, 0);

				//Read the command's Meta data.
				buffer = new byte[metaDataSize];
				readBytes = _networkStream.Read(buffer, 0, metaDataSize);
				if (readBytes == 0)
				{
					break;
				}
				var cmdMetaData = Encoding.Unicode.GetString(buffer);

				var cmd = new Command(cmdType, IPAddress.Parse(cmdTarget), cmdMetaData)
				{
					SenderIp = senderIp,
					SenderName = senderName
				};
				OnCommandReceived(new CommandEventArgs(cmd));
			}
			OnServerDisconnected(new ServerEventArgs(_clientSocket));
			Disconnect();
		}

		private void bwSender_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (!e.Cancelled && e.Error == null && ((bool)e.Result))
			{
				OnCommandSent(new EventArgs());
			}
			else
			{
				OnCommandFailed(new EventArgs());
			}

			((BackgroundWorker)sender).Dispose();
			GC.Collect();
		}

		private void bwSender_DoWork(object sender, DoWorkEventArgs e)
		{
			var cmd = (Command)e.Argument;
			e.Result = SendCommandToServer(cmd);
		}

		//This Semaphor is to protect the critical section from concurrent access of sender threads.
		readonly System.Threading.Semaphore _semaphor = new System.Threading.Semaphore(1, 1);
		private bool SendCommandToServer(Command cmd)
		{
			try
			{
				_semaphor.WaitOne();
				if (string.IsNullOrEmpty(cmd.MetaData))
				{
					SetMetaDataIfIsNull(cmd);
				}
				//CommandType
				var buffer = BitConverter.GetBytes((int)cmd.CommandType);
				_networkStream.Write(buffer, 0, 4);
				_networkStream.Flush();
				//Command Target
				var ipBuffer = Encoding.ASCII.GetBytes(cmd.Target.ToString());
				buffer = BitConverter.GetBytes(ipBuffer.Length);
				_networkStream.Write(buffer, 0, 4);
				_networkStream.Flush();
				_networkStream.Write(ipBuffer, 0, ipBuffer.Length);
				_networkStream.Flush();
				//Command MetaData
				if (cmd.MetaData != null)
				{
					var metaBuffer = Encoding.Unicode.GetBytes(cmd.MetaData);
					buffer = BitConverter.GetBytes(metaBuffer.Length);
					_networkStream.Write(buffer, 0, 4);
					_networkStream.Flush();
					_networkStream.Write(metaBuffer, 0, metaBuffer.Length);
				}
				_networkStream.Flush();

				_semaphor.Release();
				return true;
			}
			catch
			{
				_semaphor.Release();
				return false;
			}
		}

		private void SetMetaDataIfIsNull(Command cmd)
		{
			switch (cmd.CommandType)
			{
				case (CommandType.ClientLoginInform):
					cmd.MetaData = Ip + ":" + NetworkName;
					break;
				case (CommandType.PcLockWithTimer):
				case (CommandType.PcLogOffWithTimer):
				case (CommandType.PcRestartWithTimer):
				case (CommandType.PcShutDownWithTimer):
				case (CommandType.UserExitWithTimer):
					cmd.MetaData = "60000";
					break;
				default:
					cmd.MetaData = "\n";
					break;
			}
		}

		#endregion

		#region Public Methods
		/// <summary>
		/// Connect the current instance of command client to the server.This method throws ServerNotFoundException on failur.Run this method and handle the 'ConnectingSuccessed' and 'ConnectingFailed' to get the connection state.
		/// </summary>
		public void ConnectToServer()
		{
			var bwConnector = new BackgroundWorker();
			bwConnector.DoWork += bwConnector_DoWork;
			bwConnector.RunWorkerCompleted += bwConnector_RunWorkerCompleted;
			bwConnector.RunWorkerAsync();
		}

		private void bwConnector_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (!((bool)e.Result))
			{
				OnConnectingFailed(new EventArgs());
			}
			else
			{
				OnConnectingSuccessed(new EventArgs());
			}

			((BackgroundWorker)sender).Dispose();
		}

		private void bwConnector_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				_clientSocket.Connect(_serverEp);
				e.Result = true;
				_networkStream = new NetworkStream(_clientSocket);
				_bwReceiver = new BackgroundWorker
				{
					WorkerSupportsCancellation = true
				};
				_bwReceiver.DoWork += StartReceive;
				_bwReceiver.RunWorkerAsync();

				//Inform to all clients that this client is now online.
				var informToAllCmd = new Command(CommandType.ClientLoginInform, IPAddress.Broadcast, Ip + ":" + NetworkName);
				SendCommand(informToAllCmd);
			}
			catch
			{
				e.Result = false;
			}
		}
		/// <summary>
		/// Sends a command to the server if the connection is alive.
		/// </summary>
		/// <param name="cmd">The command to send.</param>
		public void SendCommand(Command cmd)
		{
			if (_clientSocket != null && _clientSocket.Connected)
			{
				var bwSender = new BackgroundWorker();
				bwSender.DoWork += bwSender_DoWork;
				bwSender.RunWorkerCompleted += bwSender_RunWorkerCompleted;
				bwSender.WorkerSupportsCancellation = true;
				bwSender.RunWorkerAsync(cmd);
			}
			else
				OnCommandFailed(new EventArgs());
		}
        public void SendImage(Bitmap cmd)
        {
            if (_clientSocket != null && _clientSocket.Connected)
            {
                var bmp = cmd;
                var ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                var bmpBytes = ms.GetBuffer();
                bmp.Dispose();
                ms.Close();
                var send = SendVarData(_clientSocket, bmpBytes);
            }
            else
                OnCommandFailed(new EventArgs());
        }

        private static int SendVarData(Socket s, byte[] data)
        {
            var total = 0;
            var size = data.Length;
            var dataleft = size;

            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(size);
            int sent = s.Send(datasize);

            while (total < size)
            {
                sent = s.Send(data, total, dataleft, SocketFlags.None);
                total += sent;
                dataleft -= sent;
            }
            return total;
        }
		/// <summary>
		/// Disconnect the client from the server and returns true if the client had been disconnected from the server.
		/// </summary>
		/// <returns>True if the client had been disconnected from the server,otherwise false.</returns>
		public bool Disconnect()
		{
			if (_clientSocket == null || !_clientSocket.Connected)
			{
				return true;
			}
			try
			{
				_clientSocket.Shutdown(SocketShutdown.Both);
				_clientSocket.Close();
				_bwReceiver.CancelAsync();
				OnDisconnectedFromServer(new EventArgs());
				return true;
			}
			catch
			{
				return false;
			}
		}

		#endregion

		#region Events
		/// <summary>
		/// Occurs when a command received from a remote client.
		/// </summary>
		public event CommandReceivedEventHandler CommandReceived;
		/// <summary>
		/// Occurs when a command received from a remote client.
		/// </summary>
		/// <param name="e">The received command.</param>
		protected virtual void OnCommandReceived(CommandEventArgs e)
		{
			if (CommandReceived != null)
			{
				var target = CommandReceived.Target as Control;
				if (target != null && target.InvokeRequired)
				{
					target.Invoke(CommandReceived, new object[] { this, e });
				}
				else
				{
					CommandReceived(this, e);
				}
			}
		}

		/// <summary>
		/// Occurs when a command had been sent to the the remote server Successfully.
		/// </summary>
		public event CommandSentEventHandler CommandSent;
		/// <summary>
		/// Occurs when a command had been sent to the the remote server Successfully.
		/// </summary>
		/// <param name="e">The sent command.</param>
		protected virtual void OnCommandSent(EventArgs e)
		{
			if (CommandSent != null)
			{
				var target = CommandSent.Target as Control;
				if (target != null && target.InvokeRequired)
				{
					target.Invoke(CommandSent, new object[] { this, e });
				}
				else
				{
					CommandSent(this, e);
				}
			}
		}

		/// <summary>
		/// Occurs when a command sending action had been failed.This is because disconnection or sending exception.
		/// </summary>
		public event CommandSendingFailedEventHandler CommandFailed;
		/// <summary>
		/// Occurs when a command sending action had been failed.This is because disconnection or sending exception.
		/// </summary>
		/// <param name="e">The sent command.</param>
		protected virtual void OnCommandFailed(EventArgs e)
		{
			if (CommandFailed != null)
			{
				var target = CommandFailed.Target as Control;
				if (target != null && target.InvokeRequired)
				{
					target.Invoke(CommandFailed, new object[] { this, e });
				}
				else
				{
					CommandFailed(this, e);
				}
			}
		}

		/// <summary>
		/// Occurs when the client disconnected.
		/// </summary>
		public event ServerDisconnectedEventHandler ServerDisconnected;
		/// <summary>
		/// Occurs when the server disconnected.
		/// </summary>
		/// <param name="e">Server information.</param>
		protected virtual void OnServerDisconnected(ServerEventArgs e)
		{
			if (ServerDisconnected != null)
			{
				var target = ServerDisconnected.Target as Control;
				if (target != null && target.InvokeRequired)
				{
					target.Invoke(ServerDisconnected, new object[] { this, e });
				}
				else
				{
					ServerDisconnected(this, e);
				}
			}
		}

		/// <summary>
		/// Occurs when this client disconnected from the remote server.
		/// </summary>
		public event DisconnectedEventHandler DisconnectedFromServer;
		/// <summary>
		/// Occurs when this client disconnected from the remote server.
		/// </summary>
		/// <param name="e">EventArgs.</param>
		protected virtual void OnDisconnectedFromServer(EventArgs e)
		{
			if (DisconnectedFromServer != null)
			{
				var target = DisconnectedFromServer.Target as Control;
				if (target != null && target.InvokeRequired)
				{
					target.Invoke(DisconnectedFromServer, new object[] { this, e });
				}
				else
				{
					DisconnectedFromServer(this, e);
				}
			}
		}

		/// <summary>
		/// Occurs when this client connected to the remote server Successfully.
		/// </summary>
		public event ConnectingSuccessedEventHandler ConnectingSuccessed;
		/// <summary>
		/// Occurs when this client connected to the remote server Successfully.
		/// </summary>
		/// <param name="e">EventArgs.</param>
		protected virtual void OnConnectingSuccessed(EventArgs e)
		{
			if (ConnectingSuccessed != null)
			{
				var target = ConnectingSuccessed.Target as Control;
				if (target != null && target.InvokeRequired)
				{
					target.Invoke(ConnectingSuccessed, new object[] { this, e });
				}
				else
				{
					ConnectingSuccessed(this, e);
				}
			}
		}

		/// <summary>
		/// Occurs when this client failed on connecting to server.
		/// </summary>
		public event ConnectingFailedEventHandler ConnectingFailed;
		/// <summary>
		/// Occurs when this client failed on connecting to server.
		/// </summary>
		/// <param name="e">EventArgs.</param>
		protected virtual void OnConnectingFailed(EventArgs e)
		{
			if (ConnectingFailed != null)
			{
				var target = ConnectingFailed.Target as Control;
				if (target != null && target.InvokeRequired)
				{
					target.Invoke(ConnectingFailed, new object[] { this, e });
				}
				else
				{
					ConnectingFailed(this, e);
				}
			}
		}

		/// <summary>
		/// Occurs when the network had been failed.
		/// </summary>
		public event NetworkDeadEventHandler NetworkDead;
		/// <summary>
		/// Occurs when the network had been failed.
		/// </summary>
		/// <param name="e">EventArgs.</param>
		protected virtual void OnNetworkDead(EventArgs e)
		{
			if (NetworkDead != null)
			{
				var target = NetworkDead.Target as Control;
				if (target != null && target.InvokeRequired)
				{
					target.Invoke(NetworkDead, new object[] { this, e });
				}
				else
				{
					NetworkDead(this, e);
				}
			}
		}

		/// <summary>
		/// Occurs when the network had been started to work.
		/// </summary>
		public event NetworkAlivedEventHandler NetworkAlived;
		/// <summary>
		/// Occurs when the network had been started to work.
		/// </summary>
		/// <param name="e">EventArgs.</param>
		protected virtual void OnNetworkAlived(EventArgs e)
		{
			if (NetworkAlived != null)
			{
				var target = NetworkAlived.Target as Control;
				if (target != null && target.InvokeRequired)
				{
					target.Invoke(NetworkAlived, new object[] { this, e });
				}
				else
				{
					NetworkAlived(this, e);
				}
			}
		}

		#endregion
	}
}
