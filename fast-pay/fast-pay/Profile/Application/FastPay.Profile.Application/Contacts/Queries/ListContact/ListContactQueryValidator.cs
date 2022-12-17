using System;
using FluentValidation;

namespace FastPay.Profile.Application.Contacts.Queries.ListContact
{
	public class ListContactQueryValidator: AbstractValidator<ListContactQuery>
	{
		public ListContactQueryValidator()
		{
			RuleFor(x => x.UserId).GreaterThan(0);
			RuleFor(x => x.Search).NotEmpty();
		}
	}
}

