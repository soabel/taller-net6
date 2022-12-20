using System;
using FastPay.Payments.Application.Common.Interfaces;
using FastPay.Payments.Domain.Entities;
using MediatR;

namespace FastPay.Payments.Application.Payments.Commands.CreatePayment;

public class CreatePaymentCommand: IRequest<int>
{
	public int UserId { get; set; }
	public int ContactId { get; set; }
	public decimal Amount { get; set; }
	public string? Comment { get; set; }
}


public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IProfileContactRepository _contactRepository;

    public CreatePaymentCommandHandler(IApplicationDbContext context, IProfileContactRepository contactRepository) {
        _context = context;
        _contactRepository = contactRepository;
    }

    public async Task<int> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Payment
        {
            UserId = request.UserId,
            ContactId = request.ContactId,
            Amount = request.Amount,
            Comment = request.Comment
        };

        _context.Payments.Add(entity);
        entity.Date = DateTime.Now;

        //Call to Profile contact

        var contact =  await _contactRepository.GetProfileContactById(request.ContactId);
        entity.ContactName = contact.Name;

        await _context.SaveChangesAsync(cancellationToken);


        return entity.Id;
    }
}
