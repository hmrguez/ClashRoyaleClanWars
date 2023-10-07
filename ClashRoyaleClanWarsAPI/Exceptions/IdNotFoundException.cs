namespace ClashRoyaleClanWarsAPI.Exceptions
{
    public class IdNotFoundException<T, U> : Exception
    {
        public IdNotFoundException(U id) :base(string.Format("{0}: Id {1} does not exist", typeof(T), id))
        {}
        public IdNotFoundException() : base($"{typeof(T)}: Ids do not exist")
        { }

    }
}
