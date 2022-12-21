using System;
using FastPay.Payments.Application.Common.Interfaces;
using FastPay.Payments.Application.Dto;
using Moq;

namespace FastPay.Payments.Applications.UnitTests.Mocks
{
	public static class MockProfileContactRepository
	{
		public static Mock<IProfileContactRepository> GetProfileContactRepository() {

			var mockResult = new Mock<IProfileContactRepository>();

			var contact = new ProfileContactDto
			{
				Id = 1,
				Name = "Carlos",
				Phone = "999999999"
			};

        mockResult.Setup(x => x.GetProfileContactById(It.IsAny<int>()))
				.ReturnsAsync(contact);

			return mockResult;
		}
    }
}

