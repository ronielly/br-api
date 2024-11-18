using System.Dynamic;
using System.Net;

namespace BrApi.Dtos
{
    public class Response<T> where T : class
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public T? Data { get; set; }
        public ExpandoObject? Error { get; set; }
    }
}