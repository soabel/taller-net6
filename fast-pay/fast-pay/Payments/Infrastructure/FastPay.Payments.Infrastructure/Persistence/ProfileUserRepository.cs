using System;
using FastPay.Payments.Application.Dto;

namespace FastPay.Payments.Infrastructure.Persistence
{
	public class ProfileUserRepository
	{
		public ProfileUserRepository()
		{
		}

        public ProfileUserDto GetProfileUserById(int v)
        {
            return new ProfileUserDto();
        }
    }
}

