using System;
namespace FastPay.Payments.Domain
{
	public class Calc
	{
		public int Sumar(int a, int b) {
			return a + b;
		}

        public int Restar(int a, int b)
        {
            return a + b;
        }

        public int Multiplicar(int a, int b)
        {
            return a * b;
        }

        public int Dividir(int a, int b)
        {
            if (b == 0) return 0;
            return a / b;
        }

        public int Resto(int a, int b)
        {
            return a % b;
        }
    }
}

