using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SimpleChat.BLL.Interfaces;
using SimpleChat.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChat.BLL.Implementations
{
	public class MessageController : IMessageController
	{
		private ConnectionFactory connectionFactory;
		private IConnection connection;
		private IModel channel;

		public MessageController(string hostName, int port, string virtualHost, string userName, string password)
		{
			ReConfigureController(hostName, port, virtualHost, userName, password);
		}

		public MessageController()
		{
			SetDefaultConfig();
		}

		private void SetDefaultConfig()
		{
			var jsonConfiguration = new ConfigurationBuilder()
				.SetBasePath(Environment.CurrentDirectory)
				.AddJsonFile("conf.json").Build();

			var host = jsonConfiguration.GetSection("host").Value;
			var port = jsonConfiguration.GetSection("port").Value;
			var virtualHost = jsonConfiguration.GetSection("virtualHost").Value;
			var userName = jsonConfiguration.GetSection("userName").Value;
			var password = jsonConfiguration.GetSection("password").Value;

			connectionFactory = new ConnectionFactory()
			{
				HostName = host,
				Port = int.Parse(port),
				VirtualHost = virtualHost,
				UserName = userName,
				Password = password
			};
		}

		public void ReceiveMessages(string chanelToListen)
		{
			connection = connectionFactory.CreateConnection();
			channel = connection.CreateModel();

			channel.QueueDeclare(chanelToListen, false, false, false, null);

			var consumer = new EventingBasicConsumer(channel);
			consumer.Received += (model, ea) =>
			{
				var body = ea.Body;
				var message = Encoding.UTF8.GetString(body);
				Console.WriteLine(" [x] Received {0}", message);
			};
			channel.BasicConsume(chanelToListen, true, consumer);

		}

		public void ReConfigureController(string hostName, int port, string virtualHost, string userName, string password)
		{
			connectionFactory = new ConnectionFactory()
			{
				HostName = hostName,
				Port = port,
				VirtualHost = virtualHost,
				UserName = userName,
				Password = password
			};
		}

		public void SendMessage(Message message)
		{
			using (var connection = connectionFactory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(message.Channel, false, false, false, null);

				var messageBytes = message.GetBytes;

				channel.BasicPublish("", message.Channel, null, messageBytes);
			}
			Console.WriteLine("Message sending success!");

		}

		public void SendMessages(IList<Message> messages)
		{
			foreach (var message in messages)
			{
				SendMessage(message);
			}
		}
	}
}
