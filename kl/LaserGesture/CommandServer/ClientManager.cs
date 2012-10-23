using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;

namespace Proshot.CommandServer
{
	 /// <summary>
	 /// The class that contains some methods and properties to manage the remote clients.
	 /// </summary>
	public class ClientManager
	 {
		/// <summary>
		/// Gets the IP address of connected remote client.This is 'IPAddress.None' if the client is not connected.
		/// </summary>
		public IPAddress IP
		{
			get
			{
				return _socket != null ? ((IPEndPoint)_socket.RemoteEndPoint).Address : IPAddress.None;
			}
		}

		/// <summary>
		/// Gets the port number of connected remote client.This is -1 if the client is not connected.
		/// </summary>
		public int Port
		{
			get { return _socket != null ? ((IPEndPoint) _socket.RemoteEndPoint).Port : -1; }
		}

		/// <summary>
		/// Gets The value that specifies the remote client is connected to this server or not.
		/// </summary>
		public bool Connected
		{
			get 
			{
				return _socket != null && _socket.Connected;
			}
		}

		private readonly Socket _socket;

		/// <summary>
		/// The name of remote client.
		/// </summary>
		public string ClientName { get; set; }

		readonly NetworkStream _networkStream;
		private readonly BackgroundWorker _bwReceiver;

		#region Constructor
		/// <summary>
		/// Creates an instance of ClientManager class to comunicate with remote clients.
		/// </summary>
		/// <param name="clientSocket">The socket of ClientManager.</param>
		public ClientManager(Socket clientSocket)
		{
			_socket = clientSocket;
			_networkStream = new NetworkStream(_socket);
			_bwReceiver = new BackgroundWorker();
			_bwReceiver.DoWork += StartReceive;
			_bwReceiver.RunWorkerAsync();
		}

		#endregion

		#region Private Methods

		private void StartReceive(object sender, DoWorkEventArgs e)
		{
			while (_socket.Connected)
			{
				//Read the command's Type.
				var buffer = new byte[4];
				var readBytes = _networkStream.Read(buffer, 0, 4);
				if (readBytes == 0)
					break;
				var cmdType = (CommandType) (BitConverter.ToInt32(buffer, 0));

				//Read the command's target size.
				buffer = new byte[4];
				readBytes = _networkStream.Read(buffer, 0, 4);
				if (readBytes == 0)
					break;
				var ipSize = BitConverter.ToInt32(buffer, 0);

				//Read the command's target.
				buffer = new byte[ipSize];
				readBytes = _networkStream.Read(buffer, 0, ipSize);
				if (readBytes == 0)
					break;
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
					break;
				var cmdMetaData = Encoding.Unicode.GetString(buffer);

				var cmd = new Command(cmdType, IPAddress.Parse(cmdTarget), cmdMetaData) {SenderIP = IP};
				cmd.SenderName = cmd.CommandType == CommandType.ClientLoginInform ? cmd.MetaData.Split(new[] {':'})[1] : ClientName;
				OnCommandReceived(new CommandEventArgs(cmd));
			}
			OnDisconnected(new ClientEventArgs(_socket));
			Disconnect();
		}

		private void BwSenderRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (!e.Cancelled && e.Error == null && ((bool)e.Result))
			{
				OnCommandSent(new EventArgs());
			}
			else
			{
				OnCommandFailed(new EventArgs());
			}

			((BackgroundWorker) sender).Dispose();
			GC.Collect();
		}

		private void BwSenderDoWork(object sender, DoWorkEventArgs e)
		{
			var cmd = (Command) e.Argument;
			e.Result = SendCommandToClient(cmd);
		}
		
		//This Semaphor is to protect the critical section from concurrent access of sender threads.
	 	readonly System.Threading.Semaphore _semaphor = new System.Threading.Semaphore(1 , 1);

		private bool SendCommandToClient(Command cmd)
		{
			try
			{
				_semaphor.WaitOne();
				//Type
				var buffer = BitConverter.GetBytes((int) cmd.CommandType);
				_networkStream.Write(buffer, 0, 4);
				_networkStream.Flush();

				//Sender IP
				var senderIpBuffer = Encoding.ASCII.GetBytes(cmd.SenderIP.ToString());
				buffer = BitConverter.GetBytes(senderIpBuffer.Length);
				_networkStream.Write(buffer, 0, 4);
				_networkStream.Flush();
				_networkStream.Write(senderIpBuffer, 0, senderIpBuffer.Length);
				_networkStream.Flush();

				//Sender Name
				var senderNameBuffer = Encoding.Unicode.GetBytes(cmd.SenderName);
				buffer = BitConverter.GetBytes(senderNameBuffer.Length);
				_networkStream.Write(buffer, 0, 4);
				_networkStream.Flush();
				_networkStream.Write(senderNameBuffer, 0, senderNameBuffer.Length);
				_networkStream.Flush();

				//Target
				var ipBuffer = Encoding.ASCII.GetBytes(cmd.Target.ToString());
				buffer = BitConverter.GetBytes(ipBuffer.Length);
				_networkStream.Write(buffer, 0, 4);
				_networkStream.Flush();
				_networkStream.Write(ipBuffer, 0, ipBuffer.Length);
				_networkStream.Flush();

				//Meta Data.
				if (string.IsNullOrEmpty(cmd.MetaData))
					cmd.MetaData = "\n";

				var metaBuffer = Encoding.Unicode.GetBytes(cmd.MetaData);
				buffer = BitConverter.GetBytes(metaBuffer.Length);
				_networkStream.Write(buffer, 0, 4);
				_networkStream.Flush();
				_networkStream.Write(metaBuffer, 0, metaBuffer.Length);
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

		#endregion

		#region Public Methods
		/// <summary>
		/// Sends a command to the remote client if the connection is alive.
		/// </summary>
		/// <param name="cmd">The command to send.</param>
		public void SendCommand(Command cmd)
		{
			if (_socket != null && _socket.Connected)
			{
				var bwSender = new BackgroundWorker();
				bwSender.DoWork += BwSenderDoWork;
				bwSender.RunWorkerCompleted += BwSenderRunWorkerCompleted;
				bwSender.RunWorkerAsync(cmd);
			}
			else
			{
				OnCommandFailed(new EventArgs());
			}
		}



		/// <summary>
		/// Disconnect the current client manager from the remote client and returns true if the client had been disconnected from the server.
		/// </summary>
		/// <returns>True if the remote client had been disconnected from the server,otherwise false.</returns>
		public bool Disconnect()
		{
			if (_socket != null && _socket.Connected)
			{
				try
				{
					_socket.Shutdown(SocketShutdown.Both);
					_socket.Close();
					return true;
				}
				catch
				{
					return false;
				}
			}
			return true;
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
		/// <param name="e">Received command.</param>
		protected virtual void OnCommandReceived(CommandEventArgs e)
		{
			if (CommandReceived != null)
				CommandReceived(this, e);
		}

		/// <summary>
		/// Occurs when a command had been sent to the remote client successfully.
		/// </summary>
		public event CommandSentEventHandler CommandSent;

		/// <summary>
		/// Occurs when a command had been sent to the remote client successfully.
		/// </summary>
		/// <param name="e">The sent command.</param>
		protected virtual void OnCommandSent(EventArgs e)
		{
			if (CommandSent != null)
				CommandSent(this, e);
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
				CommandFailed(this, e);
		}

		/// <summary>
		/// Occurs when a client disconnected from this server.
		/// </summary>
		public event DisconnectedEventHandler Disconnected;
		
		/// <summary>
		/// Occurs when a client disconnected from this server.
		/// </summary>
		/// <param name="e">Client information.</param>
		protected virtual void OnDisconnected(ClientEventArgs e)
		{
			if (Disconnected != null)
				Disconnected(this, e);
		}

		#endregion
	 }
}
