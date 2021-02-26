using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkWayProjectsTask1.Models
{
    public class GenericResponseModel
    {
        public System.Net.HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
