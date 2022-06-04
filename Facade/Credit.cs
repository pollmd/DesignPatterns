using System;

namespace Facade
{
    internal class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine("Credit nevalid pentru: " + c.Name);
            return false;
        }
    }
}