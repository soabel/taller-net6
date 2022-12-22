using System;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using FastPay.Payments.Application.Common.Interfaces;
using FastPay.Payments.Application.Dto;
using FastPay.Payments.Application.Payments.Commands.CreatePayment;
using FastPay.Payments.Applications.UnitTests.Mocks;
using FastPay.Payments.Domain.Entities;
using FastPay.Payments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace FastPay.Payments.Applications.UnitTests.Payments.Commands
{
	public class CreatePaymentCommandHandlerTest
	{

        private readonly Mock<IProfileContactRepository> _mockProfileContactRepository;

        public CreatePaymentCommandHandlerTest()
		{
            //_mockProfileContactRepository = MockProfileContactRepository.GetProfileContactRepository();

            var mockResult = new Mock<IProfileContactRepository>();

            var contact = new ProfileContactDto
            {
                Id = 1,
                Name = "Carlos",
                Phone = "999999999"
            };

            mockResult.Setup(x => x.GetProfileContactById(It.IsAny<int>()))
                    .ReturnsAsync(contact);


            _mockProfileContactRepository = mockResult;

        }

        [Fact]
        public async void CreatePayment_OK() {


            //ARRANGE
            var _context = await CreateContextAsync();

            var handler = new CreatePaymentCommandHandler(_context, _mockProfileContactRepository.Object);
          
            var request = new CreatePaymentCommand { UserId=1, ContactId=1, Comment="devolucion futbol", Amount=10 };

            //ACT
            var result = await handler.Handle(request, CancellationToken.None);


            //ASSERT

            //Assert.NotEqual(0, result.Id);
            //Assert.NotEqual(DateTime.Now, result.Date);
            //Assert.NotNull(result.ContactName);

            result.Id.ShouldNotBe(0);
            result.Date.ShouldNotBe(DateTime.Now);
            result.ContactName.ShouldNotBeNull();



        }

        private async Task<IApplicationDbContext> CreateContextAsync()
        {
            var dbName = $"AuthorPostsDb_{DateTime.Now.ToFileTimeUtc()}";
            var dbContextOptions = new DbContextOptionsBuilder<PaymentDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;


            PaymentDbContext context = new PaymentDbContext(dbContextOptions);
            await PopulateDataAsync(context);
            return context;
        }

        private async Task PopulateDataAsync(PaymentDbContext context)
        {

            var payments = new List<Payment>
            {
                new Payment { UserId =1, ContactId=1, Amount=10, Comment="", ContactName="Contact 1" },
                new Payment {  UserId =1, ContactId=2, Amount=10, Comment="", ContactName="Contact 2"  },
                new Payment {  UserId =1, ContactId=3, Amount=10, Comment="", ContactName="Contact 3"  },
            };

            await context.Payments.AddRangeAsync(payments);
            await context.SaveChangesAsync();
        }


    }
}

