using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> Index();

        // get any specific todo
        Employee Details(int Id);

        // add todo into the list
        Employee Create(Employee newEmployee);

        // update todo in the list
        Employee Edit(int employeeId, Employee newEmployee);

        // delete 
        Employee Delete(int employeeId);
    }
}
