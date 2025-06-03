using EmployeeMangment.Data;
using EmployeeMangment.Modules;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangment.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDBContext _context;
        public EmployeeRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int ID)
        {
            var employeeInDb = await _context.Employees.FindAsync(ID);
            if(employeeInDb == null)
            {
                throw new KeyNotFoundException($"Employee with ID {ID} not found.");
            }
            _context.Employees.Remove(employeeInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIDAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);    
            await _context.SaveChangesAsync();
        }
    }
}
