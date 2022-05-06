using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_Assessment_2
{
    public class ZeroDiceException : Exception
    {
        // custom exception for when the number of dice is zero


        // below are the 3 common constructors for the exception
        // https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
        public ZeroDiceException()
        {

        }
        public ZeroDiceException(string message) : base(message)
        {

        }
        public ZeroDiceException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
