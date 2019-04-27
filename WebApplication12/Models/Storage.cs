using System;
using System.Collections.Generic;

namespace WebApplication12.Models
{
    public partial class Storage
    {
        public Storage()
        {
            Categoryitempattern = new HashSet<Categoryitempattern>();
            Privilege = new HashSet<Privilege>();
            Shelf = new HashSet<Shelf>();
        }

        public int StorageId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Categoryitempattern> Categoryitempattern { get; set; }
        public virtual ICollection<Privilege> Privilege { get; set; }
        public virtual ICollection<Shelf> Shelf { get; set; }
    }
}
