using System.Net;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Responses.Errors
{
    public class NotFoundErrorResponse : ErrorResponseBase
    {
        protected override int StatusCode
        {
            get => (int)HttpStatusCode.NotFound;
        }

        public string EntityName { get; set; }
    }
}
