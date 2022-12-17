using System;
using FluentValidation;

namespace FastPay.Payments.Application.Payments.Commands.CreatePayment
{
	public class CreatePaymentCommandValidator: AbstractValidator<CreatePaymentCommand>
	{
		public CreatePaymentCommandValidator()
		{
			RuleFor(x => x.UserId).NotEmpty();
			RuleFor(x => x.ContactId).NotEmpty();
			RuleFor(x => x.Amount).NotEmpty().GreaterThan(0M);
		}
	}
}

