namespace ClashRoyaleClanWarsAPI.Exceptions
{
    public class IdNotFoundException<T> : Exception
    {
        public IdNotFoundException(int id) :base(string.Format("{0}: Id {1} does not exist", typeof(T), id))
        {}
    }
}
