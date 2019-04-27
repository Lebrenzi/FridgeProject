using System;
using System.Collections.Generic;

namespace WebApplication12.Models
{
    public partial class Shelf
    {
        public Shelf()
        {
            Item = new HashSet<Item>();
        }

        public int ShelfId { get; set; }
        public int StorageId { get; set; }
        public int ShelfTypeId { get; set; }
        public string Name { get; set; }
        public decimal? Capacity { get; set; }

        public virtual Shelftype ShelfType { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual ICollection<Item> Item { get; set; }
    }
}
