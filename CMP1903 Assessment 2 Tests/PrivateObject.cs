using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_Assessment_2_Tests
{

    // class copied from https://gist.github.com/skalinets/1c4e5dbb4e86bd72bf491675901de5ad
    // used to access a private object in .net core
    public class PrivateObject
    {
        private readonly object o;

        public PrivateObject(object o)
        {
            this.o = o;
        }

        public object Invoke(string methodName, params object[] args)
        {
            var methodInfo = o.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (methodInfo == null)
            {
                throw new Exception($"Method'{methodName}' not found is class '{o.GetType()}'");
            }
            return methodInfo.Invoke(o, args);
        }
    }
}
