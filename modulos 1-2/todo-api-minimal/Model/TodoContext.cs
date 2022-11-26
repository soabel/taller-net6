using System;
using Microsoft.EntityFrameworkCore;

namespace todo_api_minimal.Model
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
        {
        }

        public DbSet<TodoItem> TodoItem { get; set; }

    }
}

