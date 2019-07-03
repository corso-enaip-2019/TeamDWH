using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplication.Models
{
    public interface IModule
    {
        ModuleInfo GetInfo();
    }
}
