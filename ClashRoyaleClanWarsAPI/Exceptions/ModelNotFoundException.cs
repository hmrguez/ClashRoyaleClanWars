namespace ClashRoyaleClanWarsAPI.Exceptions
{
    public class ModelNotFoundException<T> : Exception
    {
        public ModelNotFoundException():base(string.Format("{0} not found", nameof(T)))
        { }
    }
}
