﻿using System;
using FastPay.Profile.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastPay.Profile.Application.Common.Interfaces
{
	public interface IApplicationDbContext
	{
        DbSet<Contact> Contacts { get; }
        DbSet<User> Users { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

