using System;

namespace Facade
{
    class Customer 
    {
        private string name;
        public string Name { get { return name; } }

        public Customer(string name)
        {
            this.name = name;
        }

    }

    class Mortgage 
    {
        Bank bank = new Bank();
        Loan loan = new Loan();
        Credit credit = new Credit();

        public bool IsEligible(Customer cust, int amount)
        {
            var bankValidation = bank.HasSuficientSavings(cust);
            var loanValidation = loan.HasGooLoans(cust);
            var creditValidation = credit.HasGoodCredit(cust);

            if (bankValidation && loanValidation && creditValidation)
                return true;
            else
                return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Mortgage mortgage = new Mortgage();
            Customer cust = new Customer("Ion Suruceanu");

            string eligible = mortgage.IsEligible(cust, 125000)? "eligibil": "neeligibil";

            Console.WriteLine($"----- {cust.Name} este {eligible}");
        }
    }
}
