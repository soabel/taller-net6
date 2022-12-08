using System;
using Microsoft.EntityFrameworkCore;

namespace todo_api.Model
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
        {
        }

        public DbSet<TodoItem> TodoItem { get; set; }
        public DbSet<User>  User{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.ToTable("TodoDemo");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
                entity.Property(x => x.Name).HasColumnName("FullName");
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}

