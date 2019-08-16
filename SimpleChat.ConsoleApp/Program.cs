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
			CommandsParser();
		}
		static void DrawMenu()
		{
			Console.Clear();
			Console.WriteLine("Hello! All commands are written below.");
			Console.WriteLine
				(
					$"Press {Environment.NewLine}" +
					$"\tE - to configure connection {Environment.NewLine}" +
					$"\tS - to send message {Environment.NewLine}" +
					$"\tL - to connect channel {Environment.NewLine}" +
					$"\tQ - to exit {Environment.NewLine}" +
					$"\tC - to clear console {Environment.NewLine}"
				);
		}

		private static void CommandsParser()
		{
			bool continueWorking = true;
			while (continueWorking)
			{
				var key = Console.ReadKey().Key;
				Console.WriteLine();
				switch (key)
				{
					case ConsoleKey.E:
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
						DrawMenu();
						messageController = new MessageController(hostName, port, virtualHost, userName, password);
						break;
					case ConsoleKey.S:
						Console.WriteLine($"Enter channel name:");
						var channelToSend = Console.ReadLine();
						Console.WriteLine($"Enter message:");
						var message = Console.ReadLine();
						messageController.SendMessage(new Message(message, channelToSend));
						break;
					case ConsoleKey.L:
						Console.WriteLine($"Enter channel name to listen:");
						var channelToListen = Console.ReadLine();
						messageController.ReceiveMessages(channelToListen);
						break;
					case ConsoleKey.Q:
						continueWorking = false;
						break;
					case ConsoleKey.C:
						DrawMenu();
						break;
				}
			}
		}
	}

}
