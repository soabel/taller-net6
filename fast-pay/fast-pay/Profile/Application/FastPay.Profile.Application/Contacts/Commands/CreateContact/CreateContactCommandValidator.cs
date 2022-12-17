using System;
using FluentValidation;

namespace FastPay.Profile.Application.Contacts.Commands.CreateContact
{
	public class CreateContactCommandValidator: AbstractValidator<CreateContactCommand>
	{
		public CreateContactCommandValidator()
		{
            RuleFor(v => v.Name)
				.NotEmpty()
				.MinimumLength(3);
			
        }
	}
}

