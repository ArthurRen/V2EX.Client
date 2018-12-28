using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2EX.Client.Utils
{
    public static class FuncUtil
    {
#if DEBUG
        public static T GetFuncExecuteTime<T>(Func<T> func, out double milliseconds)
        {
            var start = DateTime.Now;
            var result = func.Invoke();
            milliseconds = (DateTime.Now - start).TotalMilliseconds;
            return result;
        }
#endif
    }
}
