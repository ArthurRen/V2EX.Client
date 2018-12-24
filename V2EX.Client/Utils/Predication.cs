using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace V2EX.Client.Utils
{
    public static class Predication
    {
        public static void CheckNotNull(object value)
        {
            if(value == null)
                throw new ArgumentNullException(nameof(value));
        }

        public static void IsTrue(bool expression)
        {
            if (!expression)
                throw new ArgumentException(nameof(expression));
        }
    }
}
