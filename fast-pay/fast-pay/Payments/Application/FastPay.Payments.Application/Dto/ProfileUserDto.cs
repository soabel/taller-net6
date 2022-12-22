using System;
namespace FastPay.Payments.Application.Dto
{
	public class ProfileUserDto
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public decimal Saldo { get; set; }
	}
}

