using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_OOP
{
    public class NoProductInStockException : Exception
    {
        public NoProductInStockException() { }
        public NoProductInStockException(string message) : base(message)
        {

        }
    }
}
