using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_Assessment_2
{
    public class ZeroSideException : Exception
    {
        // custom exception for when a die has zero sides


        // below are the 3 common constructors for the exception
        // https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
        public ZeroSideException()
        {

        }
        public ZeroSideException(string message) : base(message)
        {

        }
        public ZeroSideException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

