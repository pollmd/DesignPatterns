using System;

namespace Facade
{
    internal class Bank
    {
        public bool HasSuficientSavings(Customer c) {
            Console.WriteLine("Verifica datele bancare pentru: "+c.Name);
            return true;
        }
    }
}