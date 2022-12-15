using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo_api.Model
{
    public class TodoItem
    {

        public int Id { get; set; }
        //[Required]
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        [NotMapped]
        public List<String>? Details { get; set; }
    }
}

