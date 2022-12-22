using FastPay.Payments.Application.Dto;
using FastPay.Payments.Infrastructure.Persistence;

namespace FastPay.Payments.Infrastructure.UnitTests.Persistence
{
    public class ProfileUserRepositoryTest
    {

        [Fact]
        public void GetProfileUserById() {
            var repo = new ProfileUserRepository();

            ProfileUserDto result = repo.GetProfileUserById(4);

            Assert.NotEqual(0, result.Id);
        }
    }
}