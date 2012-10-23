using System.Collections.Generic;

namespace ChatClient
{
	public class Sound
	{
		public static void PlaySound(int intNumber)
		{
			var numbers = ParseNumber(intNumber);
			
			//var rcMngr = new Proshot.ResourceManager.Resourcer(Proshot.ResourceManager.LoadMethod.FromCallingCode);
			foreach (var number in numbers)
			{
				//var player = new System.Media.SoundPlayer { Stream = rcMngr.GetResourceStream("20.wav"/*string.Format("{0}.wav", number)*/) };
				//var soundName = string.Format("Sound//{0}.wav", number);
				var player = new System.Media.SoundPlayer(string.Format("Sound//{0}.wav", number));
				player.Play();
			}
			return;
		}

		public static void PlaySound(string strNumber)
		{
			int number;
			var isNumber = int.TryParse(strNumber, out number);
			if (isNumber)
			{
				PlaySound(number);
			}
			return;
		}

		public static void Play(string sound)
		{
			var player = new System.Media.SoundPlayer(string.Format("Sound//{0}.wav", sound));
			player.Play();
		}

		private static IEnumerable<int> ParseNumber(int number)
		{
			var numberList = new List<int>();
			if (number > 20)
			{
				var getInt = (int) (number/10);
				numberList.Add(getInt);
				numberList.Add((getInt%10)*10);
			}
			else
			{
				numberList.Add(number);
			}
			return numberList;
		}
	}
}
