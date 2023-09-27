namespace ClashRoyaleClanWarsAPI.Dtos
{
    public class RegisterUserModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
