using System.Text.Json.Serialization;

namespace RefLoader
{
    public class VRef<T> : VRef, IIdentifiable where T : IIdentifiable
    {
        private T? value;

        public string Id { get; private set; }

        [JsonConstructor]
        public VRef(string Id)
        {
            this.Id = Id;
        }

        public VRef(T v)
        {
            value = v;
            Id = v.Id;
        }

        public static implicit operator T?(VRef<T> vref)
        {
            vref.value ??= storage.Get<T>(vref.Id);
            return vref.value; 
        }

        public static implicit operator VRef<T>?(T? value)
        {
            return (value == null) ? null : new VRef<T>(value);
        }
    }

    public abstract class VRef
    {
        protected static IVRefStorage storage;

        public static void StoreIn(IVRefStorage storage) { VRef.storage = storage; }
    }
}