namespace ClashRoyaleClanWarsAPI.Utils
{
    public class RequestResponse<T> where T : class
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public RequestResponse(T data = null!, string message="OK", bool success = true)
        {
            Data = data;
            Message = message;
            Success = success;
        }
    }
}
