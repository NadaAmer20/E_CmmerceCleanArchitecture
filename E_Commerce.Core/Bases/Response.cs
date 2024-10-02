using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Bases
{
     
        public class Response<T>
        {
            public Response()
            {

            }
            public Response(T data, string message = null)
            {
                Succeeded = true;
                Message = message;
                Data = data;
            }
                 public Response(string message, bool succeeded)
            {
                Succeeded = succeeded;
                Message = message;
            }

        // Factory method for failed responses
        public static Response<T> Failure(string message)
        {
            return new Response<T> { Succeeded = false, Message = message };
        }
        public static Response<T> Success(T data, string message = null)
        {
            return new Response<T> { Succeeded = true, Data = data, Message = message };
        }

        public HttpStatusCode StatusCode { get; set; }
            public object Meta { get; set; }

            public bool Succeeded { get; set; }
            public string Message { get; set; }
            public List<string> Errors { get; set; }
            //public Dictionary<string, List<string>> ErrorsBag { get; set; }
            public T Data { get; set; }     
        public Response(string message)
            {
                Succeeded = false;
                Message = message;
            }
  
        }

     
}
