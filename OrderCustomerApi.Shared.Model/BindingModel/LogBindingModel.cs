using OrderCustomerApi.Shared.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Shared.Model.BindingModel
{
    public class LogBindingModel
    {

        public string ControllerName { get; set; }
        public string Message { get; set; }
        public int? ProfileId { get; set; }
        public int? SiteId { get; set; }
        public string TrackingCode { get; set; }
        public string RequestParams { get; set; }
        public string Source { get; set; }
        public LogType Type { get; set; }
        public ExceptionPriority Priority { get; set; }
        public string SourceMethodName { get; set; }
        public List<LogExceptionBindingModel> Exceptions { get; set; }
        public string Environment { get; set; }
    }
}
