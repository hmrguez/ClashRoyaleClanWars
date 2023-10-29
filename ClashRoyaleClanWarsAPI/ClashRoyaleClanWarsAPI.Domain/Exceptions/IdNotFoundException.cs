namespace ClashRoyaleClanWarsAPI.Domain.Exceptions;

public class IdNotFoundException<T> : Exception
{
    public IdNotFoundException(params T[] ids) : base("Id " + String.Join(",", ids) + " does not exist")
    { }

}
