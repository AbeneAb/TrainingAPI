using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Seed
{
    public class BaseAuditModel
    {
        public Guid Guid { get; protected set; }
        public bool IsActive { get;  set; }
        public DateTime CreatedDate { get;  set; }
        public Guid CreatedByUser { get;  set; }
    }
}
