namespace ClashRoyaleClanWarsAPI.Domain.Exceptions.Auth
{
    public class RoleNotFoundException : Exception
    {
        public RoleNotFoundException(string role) : base($"Role {role} does not exist")
        {
        }
    }
}
