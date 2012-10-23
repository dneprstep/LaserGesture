using System.Net;

namespace Proshot.CommandClient
{
	/// <summary>
	/// A class that implements a command object.
	/// </summary>
	public class Command
	{
		/// <summary>
		/// [Gets/Sets] The IP address of command sender.
		/// </summary>
		public IPAddress SenderIp { get; set; }

		/// <summary>
		/// [Gets/Sets] The name of command sender.
		/// </summary>
		public string SenderName { get; set; }

		/// <summary>
		/// [Gets/Sets]  The type of command to send.If you wanna use the Message command type,create a Message class instead of command.
		/// </summary>
		public CommandType CommandType { get; set; }

		/// <summary>
		/// [Gets/Sets] The targer machine that will receive the command.Set this property to IPAddress.Broadcast if you want send the command to all connected clients.
		/// </summary>
		public IPAddress Target { get; set; }

		/// <summary>
		/// [Gets/Sets] The body of the command.This string is different in various commands.
		/// <para>Message : The text of the message.</para>
		/// <para>ClientLoginInform,ClientLogOffInform : The IP of loged in/out machine.</para>
		/// <para>***WithTimer : The interval of timer in miliseconds.The default value is 60000 equal to 1 min.</para>
		/// <para>IsNameExists : The name of client you want to check it's existance.</para>
		/// <para>Otherwise pass the "" or null.</para>
		/// </summary>
		public string MetaData { get; set; }

		/// <summary>
		/// Creates an instance of command object to send over the network.
		/// </summary>
		/// <param name="type">The type of command.If you wanna use the Message command type,create a Message class instead of command.</param>
		/// <param name="targetMachine">The targer machine that will receive the command.Set this property to IPAddress.Broadcast if you want send the command to all connected clients.</param>
		/// <param name="metaData">
		/// The body of the command.This string is different in various commands.
		/// <para>Message : The text of the message.</para>
		/// <para>ClientLoginInform : "RemoteClientIP:RemoteClientName".</para>
		/// <para>***WithTimer : The interval of timer in miliseconds..The default value is 60000 equal to 1 min.</para>
		/// <para>IsNameExists : The name of client you want to check it's existance.</para>
		/// <para>Otherwise pass the "" or null or use the next overriden constructor.</para>
		/// </param>
		public Command(CommandType type, IPAddress targetMachine, string metaData)
		{
			CommandType = type;
			Target = targetMachine;
			MetaData = metaData;
		}

		/// <summary>
		/// Creates an instance of command object to send over the network.
		/// </summary>
		/// <param name="type">The type of command.If you wanna use the Message command type,create a Message class instead of command.</param>
		/// <param name="targetMachine">The targer machine that will receive the command.Set this property to IPAddress.Broadcast if you want send the command to all connected clients.</param>
		public Command(CommandType type, IPAddress targetMachine)
		{
			CommandType = type;
			Target = targetMachine;
			MetaData = "";
		}
	}
}
