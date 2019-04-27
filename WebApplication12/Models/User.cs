using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication12.Models
{
    public partial class User
    {
        public User()
        {
            Privilege = new HashSet<Privilege>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Privilege> Privilege { get; set; }
    }
}
