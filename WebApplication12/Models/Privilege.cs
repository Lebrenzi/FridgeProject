using System;
using System.Collections.Generic;

namespace WebApplication12.Models
{
    public partial class Privilege
    {
        public int PrivilegeId { get; set; }
        public int UserId { get; set; }
        public int StorageId { get; set; }
        public int AccessTypeId { get; set; }

        public virtual Accesstype AccessType { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual User User { get; set; }
    }
}
