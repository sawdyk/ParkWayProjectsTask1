using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkWayProjectsTask1.Models
{
    public class ChargesModel
    {
        public IList<fees> fees { get; set; }
    }
    public class fees
    {
        public long minAmount { get; set; }
        public long maxAmount { get; set; }
        public long feeAmount { get; set; }
    }
}
