using SimpleChat.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.BLL.Interfaces
{
	public interface IMessageController
	{
		void ReConfigureController(string host, int port, string virtualHost, string userName, string userPassword);
		void SendMessage(Message message);
		void SendMessages(IList<Message> messages);
		void ReceiveMessages(string chanelToListen);
	}
}
