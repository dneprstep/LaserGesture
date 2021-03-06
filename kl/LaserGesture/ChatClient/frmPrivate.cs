using System;
using System.Drawing;
using System.Windows.Forms;
using Proshot.CommandClient;
using System.Net;
using System.Runtime.InteropServices;

namespace ChatClient
{
	internal enum FlashMode
	{
		FlashwCaption = 0x1,
		FlashwTray = 0x2,
		FlashwAll = FlashwCaption | FlashwTray
	}

	internal struct FlashInfo
	{
		public int CdSize;
		public IntPtr Hwnd;
		public int DwFlags;
		public int UCount;
		public int DwTimeout;
	}

	public partial class frmPrivate : Form
	{

		private readonly CMDClient _remoteClient;
		private readonly IPAddress _targetIp;
		private readonly string _remoteName;
		private bool _activated;
		public string RemoteName
		{
			get { return _remoteName; }
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

		public frmPrivate(CMDClient cmdClient, IPAddress friendIP, string name, string initialMessage)
		{
			InitializeComponent();
			_remoteClient = cmdClient;
			_targetIp = friendIP;
			_remoteName = name;
			Text += " With " + name;
			txtMessages.Text = _remoteName + ": " + initialMessage + Environment.NewLine;
			_remoteClient.CommandReceived += private_CommandReceived;
		}

		public frmPrivate(CMDClient cmdClient, IPAddress friendIP, string name)
		{
			InitializeComponent();
			_remoteClient = cmdClient;
			_targetIp = friendIP;
			_remoteName = name;
			Text += " With " + name;
			_remoteClient.CommandReceived += private_CommandReceived;
		}

		private void private_CommandReceived(object sender, CommandEventArgs e)
		{
			switch (e.Command.CommandType)
			{
				case (CommandType.Message):
					if (!e.Command.Target.Equals(IPAddress.Broadcast) && e.Command.SenderIp.Equals(this._targetIp))
					{
						txtMessages.Text += e.Command.SenderName + ": " + e.Command.MetaData + Environment.NewLine;
						if (!_activated)
						{
							if (WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized)
								ShareUtils.PlaySound(ShareUtils.SoundType.NewMessageReceived);
							else
								ShareUtils.PlaySound(ShareUtils.SoundType.NewMessageWithPow);
							Flash(Handle, FlashMode.FlashwAll, 3);
						}
					}
					break;
			}
		}

		[DllImport("user32.dll")]
		private static extern int FlashWindowEx(ref FlashInfo pfwi);
		private static void Flash(IntPtr hwnd, FlashMode flashMode, int times)
		{
			unsafe
			{
				var flashInf = new FlashInfo
				{
					CdSize = sizeof (FlashInfo),
					DwFlags = (int) flashMode,
					DwTimeout = 0,
					Hwnd = hwnd,
					UCount = times
				};
				FlashWindowEx(ref flashInf);
			}
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			SendMessage();
		}

		private void SendMessage()
		{
			if (_remoteClient.Connected && txtNewMessage.Text.Trim() != "")
			{
				_remoteClient.SendCommand(new Command(CommandType.Message, _targetIp, txtNewMessage.Text));
				txtMessages.Text += _remoteClient.NetworkName + ": " + txtNewMessage.Text.Trim() + Environment.NewLine;
				txtNewMessage.Text = "";
				txtNewMessage.Focus();
			}
		}

		private void frmPrivate_FormClosing(object sender, FormClosingEventArgs e)
		{
			_remoteClient.CommandReceived -= private_CommandReceived;
		}

		private void mniExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void mniSave_Click(object sender, EventArgs e)
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
				ShareUtils.SaveAsHtml(saveDlg.FileName, txtMessages.Lines, Text);
			}
		}

		private void frmPrivate_Load(object sender, EventArgs e)
		{
			Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width, Screen.PrimaryScreen.WorkingArea.Height - DesktopBounds.Height);
		}

		private void frmPrivate_Activated(object sender, EventArgs e)
		{
			_activated = true;
		}

		private void frmPrivate_Deactivate(object sender, EventArgs e)
		{
			_activated = false;
		}
	}
}