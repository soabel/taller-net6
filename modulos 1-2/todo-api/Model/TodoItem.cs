﻿using System;
namespace todo_api.Model
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}

