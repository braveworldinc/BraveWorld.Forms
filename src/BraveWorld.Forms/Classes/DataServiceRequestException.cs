using System.Net;
using System.Net.Http;

namespace BraveWorld.Forms.Classes
{
    public class DataServiceRequestException : HttpRequestException
    {
        public HttpStatusCode StatusCode { get; set; }


        public DataServiceRequestException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public DataServiceRequestException(HttpResponseMessage httpResponse) : base(httpResponse.ReasonPhrase)
        {
            StatusCode = httpResponse.StatusCode;
        }


        public override string ToString() => $"{StatusCode}: {Message}";
    }
}
