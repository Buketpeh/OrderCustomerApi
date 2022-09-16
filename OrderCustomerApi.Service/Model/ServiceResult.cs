using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Service.Model
{
    public class ServiceResult<T> : ServiceResult
    {
        public ServiceResult()
        {
        }

        public ServiceResult(string message, bool success, HttpStatusCode status)
            : base(message, success,status)
        {
        }

        public ServiceResult(string message, bool success, T data, HttpStatusCode status)
            : base(message, success,status)
        {
            Data = data;
            Status = status;
        }

        public T Data { get; set; }
    }

    public class ServiceResult
    {

        public ServiceResult()
        {
        }


        public ServiceResult(string message, bool success, HttpStatusCode status)
        {
            Success = success;
            Message = message;
            Status = status;
        }

        public static ServiceResult GetFailedResult(string errorMessage, HttpStatusCode status)
        {
            ServiceResult result = new ServiceResult();
            result.Success = false; 
            result.Message = errorMessage;
            result.Status = status;
            return result;
        }

        public static ServiceResult GetSuccessResult<T>(T data, HttpStatusCode status)
        {
            ServiceResult<T> result = new ServiceResult<T>();
            result.Success = true;
            result.Data = data;
            result.Status = status;
            return result;
        }

        public static ServiceResult GetSuccessResult(HttpStatusCode status)
        {
            ServiceResult result = new ServiceResult();
            result.Message = "OK";
            result.Success = true;
            result.Status = status;
            return result;
        }

        public bool Success { get; set; }
        public HttpStatusCode Status { get; set; }

        public string Messsage { set { Message = value; } }

        public string Message { get; set; }

        public string Data { get; set; }

        public bool ShouldSerializeMesssage()
        {
            return false;
        }
    }
}
