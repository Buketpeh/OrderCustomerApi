using OrderCustomerApi.Shared.Core.Enum;
using OrderCustomerApi.Shared.Model.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Service.Interfaces
{
    public interface ILog
    {
        string AddLog(string errorMessage, LogType logType, ExceptionPriority exceptionPriority, Exception exception = null);
    }
}
