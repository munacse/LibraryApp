using LibraryApp.Mongo.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Mongo.Interfaces
{
    public interface IEmployeeRepository
    {
        Task AddEmployee(Employee item);

        Task<IEnumerable<Employee>> GetAllEmployees();

        Task<Employee> GetEmployee(int id);
    }
}
