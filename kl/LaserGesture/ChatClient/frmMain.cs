using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using Proshot.CommandClient;

namespace ChatClient
{
	public partial class frmMain : Form
	{
		private CMDClient _client;
		private readonly List<frmPrivate> _privateWindowsList;
		public frmMain()
		{
			InitializeComponent();
			_privateWindowsList = new List<frmPrivate>();
			_client = new CMDClient(IPAddress.Parse("192.168.0.105"), 8001, "None");
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Enter)
			{
				SendMessage();
			}
			if (txtMessages.Focused && !ShareUtils.IsValidKeyForReadOnlyFields(keyData))
			{
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private bool IsPrivateWindowOpened(string remoteName)
		{
			foreach (var privateWindow in _privateWindowsList)
			{
				if (privateWindow.RemoteName == remoteName)
				{
					return true;
				}
			}
			return false;
		}

		private frmPrivate FindPrivateWindow(string remoteName)
		{
			foreach (var privateWindow in _privateWindowsList)
			{
				if (privateWindow.RemoteName == remoteName)
				{
					return privateWindow;
				}
			}
			return null;
		}

		void client_CommandReceived(object sender, CommandEventArgs e)
		{
			switch (e.Command.CommandType)
			{
                case (CommandType.Message):
			        {
			            if (e.Command.Target.Equals(IPAddress.Broadcast))
			                txtMessages.Text += e.Command.SenderName + ": " + e.Command.MetaData + Environment.NewLine;
			            else if (!IsPrivateWindowOpened(e.Command.SenderName))
			            {
			                OpenPrivateWindow(e.Command.SenderIp, e.Command.SenderName, e.Command.MetaData);
			                ShareUtils.PlaySound(ShareUtils.SoundType.NewMessageWithPow);
			            }
			        }
			        break;

				case (CommandType.FreeCommand):
					var newInfo = e.Command.MetaData.Split(new[] {':'});
					AddToList(newInfo[0], newInfo[1]);
					ShareUtils.PlaySound(ShareUtils.SoundType.NewClientEntered);
					break;
				case (CommandType.SendClientList):
					var clientInfo = e.Command.MetaData.Split(new[] {':'});
					AddToList(clientInfo[0], clientInfo[1]);
					break;
				case (CommandType.ClientLogOffInform):
					RemoveFromList(e.Command.SenderName);
					break;
			}
		}

		private void RemoveFromList(string name)
		{
			var item = lstViwUsers.FindItemWithText(name);
			if (item.Text != _client.Ip.ToString())
			{
				lstViwUsers.Items.Remove(item);
				ShareUtils.PlaySound(ShareUtils.SoundType.ClientExit);
			}

			var target = FindPrivateWindow(name);
			if (target != null)
			{
				target.Close();
			}
		}

		private void mniEnter_Click(object sender, EventArgs e)
		{
			if (mniEnter.Text == "Login")
			{
				var dlg = new frmLogin(IPAddress.Parse("192.168.0.105"), 8001);
				dlg.ShowDialog();
				_client = dlg.Client;

				if (_client.Connected)
				{
					_client.CommandReceived += client_CommandReceived;
					_client.SendCommand(new Command(CommandType.FreeCommand, IPAddress.Broadcast, _client.Ip + ":" + _client.NetworkName));
					_client.SendCommand(new Command(CommandType.SendClientList, _client.ServerIp));
					AddToList(_client.Ip.ToString(), _client.NetworkName);
					mniEnter.Text = "Log Off";
				}
			}
			else
			{
				mniEnter.Text = "Login";
				_privateWindowsList.Clear();
				_client.Disconnect();
				lstViwUsers.Items.Clear();
				txtNewMessage.Clear();
				txtNewMessage.Focus();
			}
		}


		private void mniExit_Click(object sender , EventArgs e)
		{
			Close();
		}

		private void btnSend_Click(object sender , EventArgs e)
		{
			SendMessage();
		}

		private void SendMessage()
		{
			if ( _client.Connected && txtNewMessage.Text.Trim() != "" )
			{
					_client.SendCommand(new Command(CommandType.Message , IPAddress.Broadcast , this.txtNewMessage.Text));
					txtMessages.Text += this._client.NetworkName + ": " + this.txtNewMessage.Text.Trim() + Environment.NewLine;
					txtNewMessage.Text = "";
					txtNewMessage.Focus();
			}
		}

		private void AddToList(string ip,string name)
		{
			var newItem = this.lstViwUsers.Items.Add(ip);
			newItem.ImageKey = "Smiely.png";
			newItem.SubItems.Add(name);
		}

		private void OpenPrivateWindow(IPAddress remoteClientIp,string clientName)
		{
			if ( _client.Connected )
			{
				if ( !IsPrivateWindowOpened(clientName) )
				{
					var privateWindow = new frmPrivate(_client , remoteClientIp , clientName);
					_privateWindowsList.Add(privateWindow);
					privateWindow.FormClosed += privateWindow_FormClosed;
					privateWindow.StartPosition = FormStartPosition.CenterParent;
					privateWindow.Show(this);
				}
			}
		}

		private void OpenPrivateWindow(IPAddress remoteClientIp , string clientName , string initialMessage)
		{
			if (_client.Connected )
			{
				var privateWindow = new frmPrivate(_client , remoteClientIp , clientName , initialMessage);
				_privateWindowsList.Add(privateWindow);
				privateWindow.FormClosed += privateWindow_FormClosed;
				privateWindow.Show(this);
			}
		}

		void privateWindow_FormClosed(object sender , FormClosedEventArgs e)
		{
			this._privateWindowsList.Remove((frmPrivate)sender);
		}

		private void btnPrivate_Click(object sender , EventArgs e)
		{
			StartPrivateChat();
		}

		private void StartPrivateChat()
		{
			if (lstViwUsers.SelectedItems.Count != 0)
			{
				OpenPrivateWindow(IPAddress.Parse(lstViwUsers.SelectedItems[0].Text),
				lstViwUsers.SelectedItems[0].SubItems[1].Text);
			}
		}

		private void frmMain_FormClosing(object sender , FormClosingEventArgs e)
		{
			Proshot.LanguageManager.LanguageActions.ChangeLanguageToEnglish();
			_client.Disconnect();
		}

		private void mniSave_Click(object sender , EventArgs e)
		{
			var saveDlg = new SaveFileDialog
			{
				Filter = "HTML Files(*.HTML;*.HTM)|*.html;*.htm",
				FilterIndex = 0,
				RestoreDirectory = true,
				CheckPathExists = true,
				OverwritePrompt = true,
				FileName = Text
			};
			if (saveDlg.ShowDialog() == DialogResult.OK)
			{
				ShareUtils.SaveAsHtml(saveDlg.FileName, this.txtMessages.Lines, this.Text);
			}
		}

		private void mniCopy_Click(object sender , EventArgs e)
		{
			txtNewMessage.Copy();
		}

		private void mniPaste_Click(object sender , EventArgs e)
		{
			txtNewMessage.Paste();
		}

		private void mniCopyText_Click(object sender , EventArgs e)
		{
			txtMessages.Copy();
		}

		private void mniPrivate_Click(object sender , EventArgs e)
		{
			StartPrivateChat();
		}
	}
}