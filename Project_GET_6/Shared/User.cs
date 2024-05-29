using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GET_6.Shared
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public Role? Role { get; set; }

        public int? RoleId { get; set; }
    }
}
