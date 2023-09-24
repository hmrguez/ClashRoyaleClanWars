namespace ClashRoyaleClanWarsAPI.Utils
{
    public class RequestResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public RequestResponse(T data, string message="OK", bool success = true)
        {
            Data = data;
            Message = message;
            Success = success;
        }
    }
}
