
namespace RefLoader
{
    public class Storage : IStorage
    {
        private List<object> list = new();

        public T? Get<T>(string id) where T : IIdentifiable
        {
            return list.OfType<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Put(params object[] objects)
        {
            list.AddRange(objects.OfType<IIdentifiable>());
        }
    }
}