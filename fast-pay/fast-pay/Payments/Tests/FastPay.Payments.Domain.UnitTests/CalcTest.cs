using System;
namespace FastPay.Payments.Domain.UnitTests
{
	public class CalcTest
	{

		[Fact]
		public void Sumar_OK() {
			//ARRANGE
			var calc = new Calc();

			//ACT
			var result = calc.Sumar(4, 5);

			//ASSERT
			Assert.Equal(9, result);
		}

        //[Theory]
        //[InlineData(3,4)]
        //[InlineData(2, 4)]
        //[InlineData(1, 4)]
        //[InlineData(6, 4)]
        [Fact]
        public void Dividir_OK()
        {
            //ARRANGE
            var calc = new Calc();

            //ACT
            var result = calc.Dividir(4, 1);

            //ASSERT
            Assert.Equal(4, result);
        }

        [Fact]
        public void Dividir_Por_Cero()
        {
            //ARRANGE
            var calc = new Calc();

            //ACT
            var result = calc.Dividir(4, 0);

            //ASSERT
            Assert.Equal(0, result);
        }
    }
}

