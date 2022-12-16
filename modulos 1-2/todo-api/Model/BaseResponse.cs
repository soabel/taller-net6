using System;
using System.Net;

namespace todo_api.Model
{
    public class BaseResponse<T>
    {
        public int Status { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public bool Succeeded { get; set; }
        public string[]? Errors { get; set; }

        public BaseResponse()
        {
        }

        public BaseResponse(T data, string message)
        {
            Status = (int)HttpStatusCode.OK;
            Message = message;
            Data = data;
            Succeeded = true;
            Errors = null;
        }

        public BaseResponse(T data)
        {
            Status = (int)HttpStatusCode.OK;
            Message = string.Empty;
            Data = data;
            Succeeded = true;
            Errors = null;
        }
    }
}

