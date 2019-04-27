using System;
using System.Collections.Generic;

namespace WebApplication12.Models
{
    public partial class Item
    {
        public int ItemId { get; set; }
        public int ShelfId { get; set; }
        public int ItemPatterId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public byte? IsOpen { get; set; }

        public virtual Itempattern ItemPatter { get; set; }
        public virtual Shelf Shelf { get; set; }
    }
}
