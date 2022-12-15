using System;
namespace todo_api.Configuration
{
	public class EmailSettings
	{
		public string? Server { get; set; }
		public int Port { get; set; }
		public bool UseSSL { get; set; }
	}
}

