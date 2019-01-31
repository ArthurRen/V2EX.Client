using System;

namespace V2EX.CommonLib.Utils
{
    public static class Preconditions
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
