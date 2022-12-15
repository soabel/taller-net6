using System;
using FluentValidation;
using todo_api.Model;

namespace todo_api.Validations
{
	public class TodoItemValidation: AbstractValidator<TodoItem>
	{
		public TodoItemValidation()
		{
            RuleFor(t => t.Name).NotNull().WithMessage("El nombre no pude ser nulo.");
			RuleFor(t => t.UserId).NotNull().GreaterThan(0);
			RuleFor(t => t.Details).NotNull().WithMessage("El detalle de tareas no pude ser nulo")
				.Must(d => d != null && d.Count > 1).WithMessage("Debe contener al menos 2 sub-tareas")
				.Must(d => d != null && d.All(s => s.Length >= 10)).WithMessage("Las sub-tareas debe tener al menos 10 caracteres");
        }
	}
}

