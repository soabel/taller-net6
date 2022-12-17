using System;
using System.Collections.Generic;
using FastPay.Payments.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastPay.Payments.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Payment> Payments { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}


