using System;
using FastPay.Payments.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FastPay.Payments.Application.Payments.Queries.GetLastPayments;

public class GetLastPaymentsQuery : IRequest<List<GetLastPaymentDto>>
{
	public int UserId { get; set; }
	public int Length { get; set; }
}

public class GetLastPaymentsQueryHandler : IRequestHandler<GetLastPaymentsQuery, List<GetLastPaymentDto>>
{
    private readonly IApplicationDbContext _context;

    public GetLastPaymentsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<List<GetLastPaymentDto>> Handle(GetLastPaymentsQuery request, CancellationToken cancellationToken)
    {
        return _context.Payments
            .Where(x => x.UserId == request.UserId)
            .Select(x => new GetLastPaymentDto { Id = x.Id, Contact = "", Amount = x.Amount, Date = x.Date })
            .ToListAsync(cancellationToken);
    }
}



