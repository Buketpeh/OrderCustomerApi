using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using OrderCustomerApi.Data.UnitOfWork.Interfaces;
using OrderCustomerApi.Entities;
using OrderCustomerApi.Service.Helpers;
using OrderCustomerApi.Service.Interfaces;
using OrderCustomerApi.Shared.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Service.Concretes
{
    public class LogService: ILog
    {
        private readonly IUnitOfWork _unitOfWork;
        public LogService( IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
           
            _unitOfWork = unitOfWork;

        }

        public string AddLog(string errorMessage,LogType logType, ExceptionPriority exceptionPriority, Exception exception = null)
        {

            var logGuid= Guid.NewGuid();
            _unitOfWork.GetRepository<Log>().Add(new Log
            {
              Guid = logGuid,
              CreatedAt = DateTime.Now,
              Message = errorMessage,
              Type = (int)logType,
              Priority = (int)exceptionPriority,
              StackTrace= exception?.StackTrace,
              MachineName = Environment.MachineName


            });
            _unitOfWork.SaveChanges();

            return logGuid.ToString();
        }

       
    }
}
