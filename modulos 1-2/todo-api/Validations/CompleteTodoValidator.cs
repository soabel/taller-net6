using System;
using FluentValidation;
using todo_api.Dto;

namespace todo_api.Validations
{
	public class CompleteTodoValidator : AbstractValidator<CompleteTodoItemDto>
    {
		public CompleteTodoValidator()
		{
			RuleFor(x => x.Id).NotNull().GreaterThan(0);
			RuleFor(x => x.IsComplete).NotNull();
		}
	}
}

