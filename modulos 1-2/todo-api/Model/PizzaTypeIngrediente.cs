using System;
namespace todo_api.Model
{
	public class PizzaTypeIngrediente
	{
		public int Id { get; set; }
		public int PizzaTypeId { get; set; }
		public int IngredienteId { get; set; }

		public PizzaType? PizzaType { get; set; }
		public Ingrediente? Ingrediente { get; set; }

	}
}

