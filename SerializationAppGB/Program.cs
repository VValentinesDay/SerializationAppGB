using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace SerializationAppGB
{
  
    public class Program
    {
        static void Main(string[] args)
        {

            var jsonEx = """{"Users":[{"id":"1","name":"","email":"","birthday":"2022, 06, 30"},{"id":"1","name":"","email":"","birthday":"2022, 06, 30"},{"id":"1","name":"","email":"","birthday":"2022, 06, 30"}]}""";

            ConvertJsonToXml(jsonEx);
        }

        static void ConvertJsonToXml(string json)
        {
            var users = JsonSerializer.Deserialize<Users>(json);
            var serializer = new XmlSerializer(typeof(Users));

            try
            {
                serializer.Serialize(Console.Out, users);
                Console.WriteLine($"'\n'Исходная строка: '\n' {json} '\n' преобразована в XML");
            }
            catch (Exception ex) { Console.WriteLine("Ошибка преобразования"); }
        }

        public class User
        {
            public string id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public DateOnly birthday { get; set; }

        }

        public class Users
        {
            public List<User> UsersList { get; set; }
        }
    }
}
