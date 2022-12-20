using System;
using FastPay.Payments.Application.Dto;

namespace FastPay.Payments.Application.Common.Interfaces
{
	public interface IProfileContactRepository
	{
		Task<ProfileContactDto> GetProfileContactById(int contactId);
	}
}

