using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaikaiPlus.Models
{
    public class ActionResultResponse
    {
        public int StatusCode { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }

        public ActionResultResponse(int statusCode, bool status, string message, string exception)
        {
            this.StatusCode = statusCode;
            this.Status = status;
            this.Message = message;
            this.Exception = exception;
        }

        public ActionResultResponse()
        {
            this.StatusCode = 0;
            this.Status = false;
            this.Message = "";
            this.Exception = "";
        }
    }
}