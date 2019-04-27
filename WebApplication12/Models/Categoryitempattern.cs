using System;
using System.Collections.Generic;

namespace WebApplication12.Models
{
    public partial class Categoryitempattern
    {
        public Categoryitempattern()
        {
            Itempattern = new HashSet<Itempattern>();
        }

        public int CategoryItemPatternId { get; set; }
        public int StorageId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal CurrentQuantity { get; set; }
        public decimal? ExpectedQuantity { get; set; }
        public decimal? ShopingFrequency { get; set; }

        public virtual Storage Storage { get; set; }
        public virtual ICollection<Itempattern> Itempattern { get; set; }
    }
}
