using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Shared.Enums
{
    public enum OrderStatus
    {
        Pending = 1,
        Accepted = 2,
        Rejected = 3,
        Processing = 4,
        Shipped = 5,
        Cancelled = 6,
        Refunded = 7,
    }
}
