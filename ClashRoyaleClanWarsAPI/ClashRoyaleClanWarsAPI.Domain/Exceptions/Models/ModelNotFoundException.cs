namespace ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;

public class ModelNotFoundException : Exception
{
    public ModelNotFoundException(string name) : base($"{name} not found")
    { }
}
