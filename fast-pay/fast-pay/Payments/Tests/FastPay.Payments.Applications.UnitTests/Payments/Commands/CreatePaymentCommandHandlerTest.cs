using System;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using FastPay.Payments.Application.Common.Interfaces;
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
        //private IApplicationDbContext _context;
        //private readonly Mock<DbSet<Payment>> _mockSet;
        private readonly Mock<IProfileContactRepository> _mockProfileContactRepository;

        public CreatePaymentCommandHandlerTest()
		{
            _mockProfileContactRepository = MockProfileContactRepository.GetProfileContactRepository();

            //var data = new List<Payment>
            //{
            //    new Payment { UserId =1, ContactId=1, Amount=10, Comment="", ContactName="Contact 1" },
            //    new Payment {  UserId =1, ContactId=1, Amount=10, Comment="", ContactName="Contact 1"  },
            //    new Payment {  UserId =1, ContactId=1, Amount=10, Comment="", ContactName="Contact 1"  },
            //};

            //_mockSet = new Mock<DbSet<Payment>>();
            //_mockSet.As<IQueryable<Payment>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            //_mockSet.As<IQueryable<Payment>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            //_mockSet.As<IQueryable<Payment>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            //_mockSet.As<IQueryable<Payment>>().Setup(m => m.GetEnumerator()).Returns(() => data.AsQueryable().GetEnumerator());

            //_context = new Mock<IApplicationDbContext>();
            //_context.Setup(c => c.Payments).Returns(_mockSet.Object);

            //_mockSet.Setup(r => r.AddAsync(It.IsAny<Payment>(), It.IsAny<CancellationToken>()))
            //    .ReturnsAsync((Payment payment) =>
            //    {
            //        data.Add(payment);
            //        return payment;
            //    });

          


        }

        [Fact]
        public async void CreatePayment_OK() {

            var _context = await CreateContextAsync();

            var handler = new CreatePaymentCommandHandler(_context, _mockProfileContactRepository.Object);
          
            var request = new CreatePaymentCommand { UserId=1, ContactId=1, Comment="devolucion futbol", Amount=10 };

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.NotEqual(DateTime.Now, result.Date);

            

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

