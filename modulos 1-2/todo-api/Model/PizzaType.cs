using System;
namespace todo_api.Model
{
	public class PizzaType
	{
		public int Id { get; set; }
		public string? Name { get; set; }

		public List<PizzaTypeIngrediente>? PizzaTypeIngredientes { get; set; }

	}
}

