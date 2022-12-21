using System;
using FastPay.Payments.Application.Common.Interfaces;
using FastPay.Payments.Domain.Entities;
using MediatR;

namespace FastPay.Payments.Application.Payments.Commands.CreatePayment;

public class CreatePaymentCommand: IRequest<CreatePaymentCommandDto>
{
	public int UserId { get; set; }
	public int ContactId { get; set; }
	public decimal Amount { get; set; }
	public string? Comment { get; set; }
}


public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatePaymentCommandDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IProfileContactRepository _contactRepository;

    public CreatePaymentCommandHandler(IApplicationDbContext context, IProfileContactRepository contactRepository) {
        _context = context;
        _contactRepository = contactRepository;
    }

    public async Task<CreatePaymentCommandDto> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {

        var entity = new Payment
        {
            UserId = request.UserId,
            ContactId = request.ContactId,
            Amount = request.Amount,
            Comment = request.Comment
        };

        await _context.Payments.AddAsync(entity, cancellationToken);

        entity.Date = DateTime.Now;

        //Call to Profile contact

        var contact =  await _contactRepository.GetProfileContactById(request.ContactId);
        entity.ContactName = contact.Name;

        await _context.SaveChangesAsync(cancellationToken);

        var result = new CreatePaymentCommandDto
        {
            Id = entity.Id,
            UserId = entity.UserId,
            ContactId = entity.ContactId,
            Amount = entity.Amount,
            Comment = entity.Comment,
            ContactName = entity.ContactName,
            Date = entity.Date
        };
            

        return result;
    }
}
