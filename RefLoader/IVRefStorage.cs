namespace RefLoader
{
    public interface IVRefStorage
    {
        T? Get<T>(string id) where T : IIdentifiable;
    }
}