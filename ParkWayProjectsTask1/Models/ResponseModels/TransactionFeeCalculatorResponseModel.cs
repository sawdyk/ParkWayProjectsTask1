using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkWayProjectsTask1.Models.ResponseModels
{
    public class TransactionFeeCalculatorResponseModel
    {
        public System.Net.HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public string TransferAmount { get; set; }
        public string Charge { get; set; }
    }
}
