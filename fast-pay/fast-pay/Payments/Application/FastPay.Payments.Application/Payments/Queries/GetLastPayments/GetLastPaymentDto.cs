using System;
namespace FastPay.Payments.Application.Payments.Queries.GetLastPayments
{
	public class GetLastPaymentDto
	{
		public int Id { get; set; }
		public string? Contact { get; set; }
		public DateTime Date { get; set; }
		public decimal Amount { get; set; }
	}
}

