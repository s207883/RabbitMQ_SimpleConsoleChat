using SimpleChat.BLL.Interfaces;
using System;
using SimpleChat.BLL.Implementations;
using SimpleChat.DAL.Models;
using System.Threading.Tasks;

namespace SimpleChat.ConsoleApp
{
	public class Program
	{
		private static  IMessageController messageController;
		public static void Main()
		{
			messageController = new MessageController("127.0.0.1",5673,"/", "Listener2", "Listener2");
			DrawMenu();
		}
		static void DrawMenu()
		{
			Console.WriteLine("What need to do?");
			Console.WriteLine
				(
					$"Press {Environment.NewLine}" +
					$"\tE - to exit {Environment.NewLine}" +
					$"\tS - to send message {Environment.NewLine}" +
					$"\tR - to connect channel {Environment.NewLine}"
				);
			bool continueWorking = true;
			while (continueWorking)
			{
				var key = Console.ReadKey().Key;
				Console.WriteLine();
				switch (key)
				{
					case ConsoleKey.E:
						continueWorking = false;
						break;
					case ConsoleKey.S:
						Console.WriteLine($"Enter channel name:");
						var channelToSend = Console.ReadLine();
						Console.WriteLine($"Enter message:");
						var message = Console.ReadLine();
						messageController.SendMessage(new Message(message, channelToSend));
						break;
					case ConsoleKey.R:
						Console.WriteLine($"Enter channel name to listen:");
						var channelToListen = Console.ReadLine();
						messageController.ReceiveMessages(channelToListen);
						break;
				}
			}
		}
	}

}
