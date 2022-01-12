using System.Collections.Generic;
using WebApplication3.Model;

namespace WebApplication3.Repository.Contracts
{
    public interface IEmployeeRepository
    {
        Employee Save(Employee employee);
        Employee Get(string employeeId);
        List<Employee> Gets();
        string Delete(string employeeId);
    }
}
