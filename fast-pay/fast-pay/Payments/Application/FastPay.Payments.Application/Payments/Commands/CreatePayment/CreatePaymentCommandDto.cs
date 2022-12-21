using System;
namespace FastPay.Payments.Application.Payments.Commands.CreatePayment
{
	public class CreatePaymentCommandDto
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ContactId { get; set; }
        public decimal Amount { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; }
        public string? ContactName { get; set; }
    }
}

