using System;
using FastPay.Profile.Application.Common.Interfaces;
using FastPay.Profile.Application.Contacts.Queries.ListContact;
using FastPay.Profile.Application.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FastPay.Profile.Application.Contacts.Queries.GetContact;

public class GetContactQuery : IRequest<GetContactDto>
{
	public int Id { get; set; }
}

public class GetContactQueryHandler : IRequestHandler<GetContactQuery, GetContactDto>
{
    private readonly IApplicationDbContext _context;

    public GetContactQueryHandler(IApplicationDbContext context) {
        _context = context;
    }

    public async Task<GetContactDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Contacts.FirstAsync(x=>x.Id==request.Id);

        return new GetContactDto { Id = entity.Id, Name = entity.Name};

    }

}


