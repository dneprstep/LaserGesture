using System.Drawing;
using System.Net;
using Proshot.CommandClient;

namespace ChatClient
{
	public class BatchMode
	{
		private const string _myName = "Стрелок";

		private static CMDClient _client;

		public static void SendMessage(string text)
		{
			_client.SendCommand(new Command(CommandType.Message, IPAddress.Broadcast, text));
		}

        public static void SendImage(Bitmap bitmap)
        {
            _client.SendImage(bitmap);
        }

		public static void StartClient()
		{
			_client = new CMDClient(IPAddress.Parse(GetIp()), 8001, "None") {NetworkName = _myName};
			_client.ConnectToServer();
            _client.CommandReceived += SetMessage;
		}

        public static void SetMessage(object sender, System.EventArgs e)
        {
            
        }

	    private static string GetIp()
		{
			var myHost = System.Net.Dns.GetHostName();
			return System.Net.Dns.GetHostByName(myHost).AddressList[0].ToString();
		}

        public static CMDClient GetClient()
        {
            return _client;
        }
	}
}
