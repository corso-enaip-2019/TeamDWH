using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppPortal.Contracts
{
    public interface IModule
    {
        ModuleInfo GetInfo();
    }
}
