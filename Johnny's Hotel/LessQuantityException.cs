using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_OOP
{
    public class LessQuantityException : Exception
    {
        public LessQuantityException() { }
        public LessQuantityException(string message) : base(message)
        {

        }
    }
}
