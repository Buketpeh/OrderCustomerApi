using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Entities
{
    public class Log
    {
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Message { get; set; }
        public int Type { get; set; }
        public string StackTrace { get; set; }
        public int Priority { get; set; }
        public string LocaleIpAdsress { get; set; }
        public string RemoteIpAddress { get; set; }
        public string Url { get; set; }
        public string MachineName { get; set; }
    }
}
