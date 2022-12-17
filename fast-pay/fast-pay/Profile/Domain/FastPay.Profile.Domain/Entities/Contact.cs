using System;
namespace FastPay.Profile.Domain.Entities
{
	public class Contact
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Phone { get; set; }
		public int UserId { get; set; }
	}
}

