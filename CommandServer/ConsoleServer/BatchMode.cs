namespace ConsoleServer
{
	public class BatchMode
	{
		public static void StartServer()
		{
			Program.Main(new[] { GetIp(), "8001" });
		}

		private static string GetIp()
		{
			var myHost = System.Net.Dns.GetHostName();
			return System.Net.Dns.GetHostByName(myHost).AddressList[0].ToString();
		}
	}
}
