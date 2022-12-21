using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    private readonly IMapper _mapper;

    public GetLastPaymentsQueryHandler(IApplicationDbContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);
    

    public Task<List<GetLastPaymentDto>> Handle(GetLastPaymentsQuery request, CancellationToken cancellationToken)
    {
       
        return _context.Payments
            .Where(x => x.UserId == request.UserId)
            .AsNoTracking()
            .ProjectTo<GetLastPaymentDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}



