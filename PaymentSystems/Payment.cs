using System;

namespace ConsoleApp
{
    public class Payment
    {
        public decimal Amount{get;set;}
        public virtual string MakePayment()
        {
            //TODO hit the payment processing API
            return $"You paid ${this.Amount} in cash.";
        }
        public string SendConfirmation(string email)
        {
            return "You purchased several nice items.";
        }
        public string SendConfirmation(string email, bool digitalDownload)
        {
            return "Check your email for the downloadable book.";
        }
    }
}