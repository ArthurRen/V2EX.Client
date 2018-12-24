using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2EX.Client.ViewModels.Infrastructure
{
    public interface IAwareViewInitialize
    {
        void OnViewInitialize(object view);
    }
}
