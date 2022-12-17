using System;
using FastPay.Profile.Application.Common.Interfaces;
using FastPay.Profile.Domain.Entities;
using MediatR;

namespace FastPay.Profile.Application.Contacts.Commands.CreateContact;

public class CreateContactCommand: IRequest<int>
{
	public string? Name { get; set; }
	public string? Phone { get; set; }
    public int UserId { get; set; }
}

public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
{
    private readonly IApplicationDbContext _context;


    public CreateContactCommandHandler(IApplicationDbContext context) {
        _context = context;
    }

    public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var entity = new Contact();

        entity.Name = request.Name;
        entity.Phone = request.Phone;
        entity.UserId = request.UserId;

        _context.Contacts.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}


