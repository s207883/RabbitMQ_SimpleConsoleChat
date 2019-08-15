using SimpleChat.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.BLL.Interfaces
{
	public interface IMessageController
	{
		Task ReConfigureControllerAsync(string host, string port, string virtualHost, string userName, string userPassword);
		Task SendMessageAsync(Message message);
		Task SendMessagesAsync(IList<Message> messages);
		Task<List<Message>> ReceiveMessagesAsync();
	}
}
