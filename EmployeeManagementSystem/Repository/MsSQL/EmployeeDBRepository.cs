using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository.MsSQL
{
    public class EmployeeDBRepository : IEmployeeRepository
    {
        EmployeeDbContext _dbContext;
        public EmployeeDBRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Employee Create(Employee newEmployee)
        {
            _dbContext.Add(newEmployee);
            // CUD operation you need to save the details -> Commit
            _dbContext.SaveChanges();
            return newEmployee;
        }

        public Employee Delete(int employeeId)
        {
            var employee = Details(employeeId);
            if (employee != null)
            {
                _dbContext.Employee.Remove(employee);
                _dbContext.SaveChanges();
            }
            return  employee;
        }

        public Employee Details(int Id)
        {
            return _dbContext.Employee.AsNoTracking().ToList().FirstOrDefault(t => t.Id == Id);
        }

        public Employee Edit(int employeeId, Employee newEmployee)
        {
            _dbContext.Employee.Update(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }

        public List<Employee> Index()
        {
            return _dbContext.Employee.AsNoTracking().ToList();
        }
    }
}
