using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdoNetCRUD.Data.AdoNetQueries
{
    public interface IEmployeeService
    {
        Task<bool> CreateEmployee(Employee employee);
        Task<bool> DeleteEmployee(string id);
        Task<bool> EditEmployee(string id, Employee employee);
        Task<List<Employee>> GetEmployees();
        Task<Employee> SingleEmployee(string id);
    }
}