using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppPortal.Contracts;

namespace WebAppPortal.Main.Models
{
    public class ModuleStatusModel
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool IsAlive { get; set; }
        public string ErrorMessage { get; set; }

        public ModuleStatusModel(string name, string url)
        {
            Name = name;
            Url = url;
            ErrorMessage = "Module Not Loaded";
        }

        public ModuleStatusModel(ModuleInfo moduleInfo, string url)
        {
            Name = moduleInfo.Name;
            FullName = moduleInfo.FullName;
            Description = moduleInfo.Description;
            Url = url;
            IsAlive = true;
        }
    }
}