using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication3.Model
{
    [BsonIgnoreExtraElements]
    public class Employee
    {
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public decimal Salary { get; set; }
    }
}
