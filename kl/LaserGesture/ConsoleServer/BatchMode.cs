using System.Diagnostics;

namespace ConsoleServer
{
	public class BatchMode
	{
		private static Process _process;

		private static BatchMode _bm;

		private BatchMode()
		{
			
		}

		public static void StartServer(string port)
		{
			_process = new Process
			{
				StartInfo =
				{
					WorkingDirectory = System.IO.Directory.GetCurrentDirectory(),
					FileName = "ConsoleServer.exe",
					Arguments = GetIp() + " 8001"
				}
			};
			//_bm = new BatchMode();
			_process.Start();
		}

		public static void Stop()
		{
             _process.Kill();
		}

		public static string GetIp()
		{
			var myHost = System.Net.Dns.GetHostName();
			return System.Net.Dns.GetHostByName(myHost).AddressList[0].ToString();
		}


	}
}
