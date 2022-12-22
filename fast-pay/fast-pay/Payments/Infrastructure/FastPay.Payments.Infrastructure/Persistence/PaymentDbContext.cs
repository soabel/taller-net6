using System;
using FastPay.Payments.Application.Common.Interfaces;
using FastPay.Payments.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastPay.Payments.Infrastructure.Persistence;

public class PaymentDbContext : DbContext, IApplicationDbContext
{

    public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
        : base(options)
    {
    }

    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("payment");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Amount).HasColumnType("decimal(18,2)");

        });

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}


