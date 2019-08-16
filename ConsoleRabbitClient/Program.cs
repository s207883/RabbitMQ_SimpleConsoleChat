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
			messageController = new MessageController();
			DrawMenu();
		}
		static void DrawMenu()
		{
			Console.WriteLine("What need to do?");
			Console.WriteLine
				(
					$"Press {Environment.NewLine}" +
					$"\tC - to configure connection {Environment.NewLine}" +
					$"\tS - to send message {Environment.NewLine}" +
					$"\tR - to connect channel {Environment.NewLine}" +
					$"\tE - to exit {Environment.NewLine}"
				);
			bool continueWorking = true;
			while (continueWorking)
			{
				var key = Console.ReadKey().Key;
				Console.WriteLine();
				switch (key)
				{
					case ConsoleKey.C:
						Console.WriteLine($"Enter host name:");
						var hostName = Console.ReadLine();
						Console.WriteLine($"Enter port:");
						int.TryParse(Console.ReadLine(), out int port);
						Console.WriteLine($"Enter virtual host (default '/'):");
						var virtualHost = Console.ReadLine();
						Console.WriteLine($"Enter user name:");
						var userName = Console.ReadLine();
						Console.WriteLine($"Enter password");
						var password = Console.ReadLine();
						messageController = new MessageController(hostName,port,virtualHost,userName,password);
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
					case ConsoleKey.E:
						continueWorking = false;
						break;
				}
			}
		}
	}

}
