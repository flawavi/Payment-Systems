using System;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var paymentType = args[0];
            if (paymentType == "p")
            {
                var paypalpayment = new PayPalPayment
                {
                    Email = args[1],
                    Password = args[2],
                    Amount = Convert.ToDecimal(args[3])

                };

                Console.WriteLine(paypalpayment.MakePayment());
            }
            if (paymentType == "c")
            {
                var creditcardpayment = new CreditCardPayment
                {
                    CreditCardNumber = args[1],
                    Amount = Convert.ToDecimal(args[2])
                };
                Console.WriteLine(creditcardpayment.MakePayment());
            }
        }
    }
}
