using System;
using AutoMapper;
using FastPay.Payments.Application.Common.Mappings;
using FastPay.Payments.Domain.Entities;

namespace FastPay.Payments.Application.Payments.Queries.GetLastPayments
{
	public class GetLastPaymentDto: IMapFrom<Payment>
	{
		public int Id { get; set; }
		public string? Contact { get; set; }
        public DateTime Date { get; set; }
		public decimal Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Payment, GetLastPaymentDto>()
                .ForMember(d => d.Contact, s => s.MapFrom(s => s.ContactName));
        }
    }
}

