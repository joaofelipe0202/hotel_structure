using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_OOP
{
    public class NegativePriceException : Exception
    {
        public NegativePriceException() { }
        public NegativePriceException(string message) : base(message)
        {

        }
    }
}
