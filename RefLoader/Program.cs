using System.Text.Json;

namespace RefLoader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storage = new Storage();

            storage.Put(new Company { Id = "cs", Name = "Consid", Location = "Oslo" });

            VRef.StoreIn(storage);

            var json = @"
                {""Name"":""Konsulent"",
                    ""Person"":{""Id"":""gg"",""Name"":""Geir"",""Age"":54},
                    ""Company"":{""Id"":""cs""}
                }
            ";

            var r = JsonSerializer.Deserialize<Role>(json);

            Console.WriteLine("Json of original graph:");
            Console.WriteLine(json);
            Console.WriteLine();

            var c2 = storage.Get<Company>("cs");

            Console.WriteLine("Company from storage serialized");
            Console.WriteLine(JsonSerializer.Serialize(c2));
            Console.WriteLine();

            var r2 = JsonSerializer.Deserialize<Role>(json);

            Company c3 = r2.Company;

            Console.WriteLine("Company from deserialization and typed reference");
            Console.WriteLine(JsonSerializer.Serialize(c3));
            Console.WriteLine();

            var c4 = r2.Company;

            Console.WriteLine("Company from deserialization and untyped reference");
            Console.WriteLine(JsonSerializer.Serialize(c4));
            Console.WriteLine();
        }
    }
}
