using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.Model;
using WebApplication3.Repository.Contracts;

namespace WebApplication3.Repository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Employee> _employeeTable = null;

        public EmployeeRepository()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017");
            _database = _mongoClient.GetDatabase("OfficeDb");
            _employeeTable = _database.GetCollection<Employee>("Employees");

        }

        public string Delete(string employeeId)
        {
            _employeeTable.DeleteOne(x => x.Id == employeeId);
            return "Deleted";
        }

        public Employee Get(string employeeId)
        {
            return _employeeTable.Find(x => x.Id == employeeId).FirstOrDefault();
        }

        public List<Employee> Gets()
        {
            return _employeeTable.Find(FilterDefinition<Employee>.Empty).ToList();
        }

        public Employee Save(Employee employee)
        {
            var empObj = _employeeTable.Find(x => x.Id == employee.Id).FirstOrDefault();
            if (empObj == null)
            {
                _employeeTable.InsertOne(employee);
            }
            else
            {
                _employeeTable.ReplaceOne(x => x.Id == employee.Id, employee);
            }
            return employee;
        }
    }
}
