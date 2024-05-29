using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GET_6.Shared
{
    public class ProjectTask
    {
        [Key]
        public int ProjectTaskId { get; set; }

        public int Status { get; set; } = 0;

        public double Progress { get; set; } = 0;

        public DateTime Deadline { get; set; }

        public string Description { get; set; } = string.Empty;

        public Project? ParentProject { get; set; }

        public string? ParentProjectProjectCode { get; set; }
        public User? Assignee { get; set; }

        public string? AssigneeUsername { get; set; } 
    }
}
