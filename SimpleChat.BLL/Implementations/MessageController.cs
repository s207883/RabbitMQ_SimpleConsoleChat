using SimpleChat.BLL.Interfaces;
using SimpleChat.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.BLL.Implementations
{
	class MessageController : IMessageController
	{
		public Task<List<Message>> ReceiveMessagesAsync()
		{
			throw new NotImplementedException();
		}

		public Task ReConfigureControllerAsync(string host, string port, string virtualHost, string userName, string userPassword)
		{
			throw new NotImplementedException();
		}

		public Task SendMessageAsync(Message message)
		{
			throw new NotImplementedException();
		}

		public Task SendMessagesAsync(IList<Message> messages)
		{
			throw new NotImplementedException();
		}
	}
}
