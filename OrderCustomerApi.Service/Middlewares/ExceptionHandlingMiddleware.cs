using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderCustomerApi.Service.Interfaces;
using OrderCustomerApi.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Service.Middlewares
{
    public class ExceptionHandlingMiddleware
    {

        private readonly RequestDelegate next;

        private readonly ILog _log;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILog log)
        {
            this.next = next;
            this._log  = log;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await Handle(context, exception, _log);
            }
        }

        private static Task Handle(HttpContext context, Exception exception, ILog _log)
        {
            
                var trackCode = _log.AddLog(exception.Message.ToString(), Shared.Core.Enum.LogType.Error, Shared.Core.Enum.ExceptionPriority.Critical);

                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync(JsonConvert.SerializeObject(
                    new ServiceResult
                    {
                        Success = false,
                        Message = String.Format("Beklenmeyen bir hata oluştu! Hata Kodu : {0}", trackCode)
                    }));
            


        }
    }
}
