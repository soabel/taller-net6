using System;
using AutoMapper;
using FastPay.Profile.Application.Common.Interfaces;
using FastPay.Profile.Application.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FastPay.Profile.Application.Contacts.Queries.ListContact;

public class ListContactQuery: IRequest<List<ContactDto>>
{
		
}

public class ListContactQueryHandler : IRequestHandler<ListContactQuery, List<ContactDto>>
{
    private readonly IApplicationDbContext _context;


    public ListContactQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<List<ContactDto>> Handle(ListContactQuery request, CancellationToken cancellationToken)
    {
        return _context.Contacts
            .Select(x => new ContactDto { Id = x.Id, Name = x.Name, Phone = x.Phone })
            .ToListAsync(cancellationToken);

    }
}
