using System;
namespace FastPay.Payments.Domain.Entities
{
	public class Payment
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int ContactId { get; set; }
		public decimal Amount { get; set; }
		public string? Comment { get; set; }
		public DateTime Date { get; set; }

	}
}

