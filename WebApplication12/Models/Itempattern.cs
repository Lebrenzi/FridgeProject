using System;
using System.Collections.Generic;

namespace WebApplication12.Models
{
    public partial class Itempattern
    {
        public Itempattern()
        {
            Item = new HashSet<Item>();
        }

        public int ItemPatternId { get; set; }
        public int? CategoryItemPatternId { get; set; }
        public decimal? BarCode { get; set; }
        public string Unit { get; set; }
        public decimal? Size { get; set; }
        public string Name { get; set; }
        public decimal? Capacity { get; set; }
        public decimal? LongLife { get; set; }

        public virtual Categoryitempattern CategoryItemPattern { get; set; }
        public virtual ICollection<Item> Item { get; set; }
    }
}
