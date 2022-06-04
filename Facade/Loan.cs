using System;

namespace Facade
{
    internal class Loan
    {
        public bool HasGooLoans(Customer c)
        {
            Console.WriteLine("Istoric de creditare bun pentru: " + c.Name);
            return true;
        }
    }
}