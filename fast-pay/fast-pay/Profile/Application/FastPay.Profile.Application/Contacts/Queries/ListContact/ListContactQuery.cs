using System;
using AutoMapper;
using FastPay.Profile.Application.Common.Interfaces;
using FastPay.Profile.Application.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FastPay.Profile.Application.Contacts.Queries.ListContact;

public class ListContactQuery: IRequest<List<ContactDto>>
{
    public string? Search { get; set; }
    public int UserId { get; set; }
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
            .Where(x => x.UserId == request.UserId)
            .Where(x => (request.Search != null && x.Name!.Contains(request.Search!)) ||
                        (request.Search != null && x.Phone!.Contains(request.Search!)))
            .Select(x => new ContactDto { Id = x.Id, Name = x.Name, Phone = x.Phone })
            .ToListAsync(cancellationToken);

    }
}
