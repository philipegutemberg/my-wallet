using System.Net;

namespace ExternalServices.Kinvo.Models
{
    internal record ErrorResponse
    {
        public int Id { get; init; }
        public int Code { get; init; }
        public string Message { get; init; } = "";
        public int StatusCode { get; init; }

        public HttpStatusCode GetStatusCode() => (HttpStatusCode)StatusCode;
    }
}