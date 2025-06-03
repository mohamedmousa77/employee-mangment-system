using EmployeeMangment.Modules;

namespace EmployeeMangment.Repositories
    
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task <Employee?> GetEmployeeByIDAsync (int id);

        Task AddEmployeeAsync (Employee employee);
        Task UpdateEmployeeAsync (Employee employee);

        Task DeleteEmployeeAsync (int ID);
    }
}
