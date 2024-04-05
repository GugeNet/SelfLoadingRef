namespace RefLoader
{
    public interface IStorage : IVRefStorage
    {
        void Put(params object[] objects);
    }
}