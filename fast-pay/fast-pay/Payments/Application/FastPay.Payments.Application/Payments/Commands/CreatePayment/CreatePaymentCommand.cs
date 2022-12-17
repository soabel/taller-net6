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
	public DateTime Date { get; set; }
}


public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePaymentCommandHandler(IApplicationDbContext context) {
        _context = context;
    }

    public async Task<int> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Payment
        {
            UserId = request.UserId,
            ContactId = request.ContactId,
            Amount = request.Amount,
            Comment = request.Comment,
            Date = request.Date
        };

        _context.Payments.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
