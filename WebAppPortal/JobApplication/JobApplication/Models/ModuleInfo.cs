using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;


namespace JobApplication.Models
{
    [DataContract]
    public class ModuleInfo
    {
        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public string FullName { get; set; }

        [DataMember]
        [Required]
        public string Description { get; set; }

    }
}
