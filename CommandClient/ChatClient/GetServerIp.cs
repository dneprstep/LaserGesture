using System;
using System.Windows.Forms;
using System.Net;
using Proshot.CommandClient;
using Proshot.UtilityLib.CommonDialogs;

namespace ChatClient
{
	public partial class GetServerIp : Form
	{
		public string ServerIp { get; set; }

		public GetServerIp()
		{
			InitializeComponent();
		}

		public bool IsCancel { get; set; }

		private void btnEnterClick(object sender, EventArgs e)
		{
			ServerIp = serverName.Text.Replace(',','.');
			Close();
		}

		private void btnExitClick(object sender, EventArgs e)
		{
			IsCancel = true;
			Close();
		}
	}
}