using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GET_6.Shared
{
    public class Project
    {
        [Key]
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; } = string.Empty;

        public User? ProjectManager { get; set; }

        public string ProjectManagerUsername { get; set; } = string.Empty;

    }
}
