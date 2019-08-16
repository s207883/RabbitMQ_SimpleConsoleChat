using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChat.DAL.Models
{
	public class Message
	{
		private string message;
		private string channel;
		public byte[] GetBytes => Encoding.UTF8.GetBytes(message);

		public string Channel { get => channel; set => channel = value; }

		public Message(IConvertible message, IConvertible channel)
		{
			this.message = Convert.ToString(message);
			this.channel = Convert.ToString(channel);
		}
	}
}
