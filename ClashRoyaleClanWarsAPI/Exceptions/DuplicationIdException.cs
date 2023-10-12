namespace ClashRoyaleClanWarsAPI.Exceptions
{
    public class DuplicationIdException:Exception
    {
        public DuplicationIdException() : base("Ids already exist. You are trying to add an existing key") { }
    }
}
