using System;
namespace todo_api.Services
{
	public interface IEmailService
	{
		Task Send(string to, string message);
	}
}

