using System;
using FastPay.Profile.Application.Common.Interfaces;
using FastPay.Profile.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastPay.Profile.Infrastructure.Persistence
{
    public class ProfileDbContext : DbContext, IApplicationDbContext
    {
        public ProfileDbContext(DbContextOptions<ProfileDbContext> options)
        : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<User> Users  {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
            });

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

