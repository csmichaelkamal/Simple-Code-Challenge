namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Responses.Errors
{
    public abstract class ErrorResponseBase
    {
        protected abstract int StatusCode { get; }
    }
}
