using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo_api.Model
{

	//[Table("User")]
	public class User
	{
		//[Key]
		public int Id { get; set; }
		//[Column("FullName")]
		public string? Name { get; set; }
		public string? Email { get; set; }

		public List<TodoItem>? TodoItems { get; set; }

	}
}

