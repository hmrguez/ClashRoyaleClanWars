namespace ClashRoyaleClanWarsAPI.Utils
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        public LoginResponse(string token, DateTime expiration)
        {
            this.Token = token;
            this.Expiration = expiration;
        }
    }
}
