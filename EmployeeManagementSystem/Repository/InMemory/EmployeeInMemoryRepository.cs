using EmployeeManagementSystem.Models;
using System.Net.Mail;
using System.Numerics;
using System.Xml.Linq;

namespace EmployeeManagementSystem.Repository.InMemory
{
    public class EmployeeInMemoryRepository : IEmployeeRepository
    {
        static List<Employee> employees = new List<Employee>();
        static EmployeeInMemoryRepository()
        {
            employees.Add(new Employee(1, "John Doe", DateTime.Now, "test@gmail.com", "09123456789", 1));
            employees.Add(new Employee(2, "Mac Doe", DateTime.Now, "Mac@gmail.com", "09124456789", 2));
        }
        public List<Employee> Index()
        {
            return employees;
        }

        // get any specific todo
        public Employee Details(int Id)
        {
            return employees.FirstOrDefault(x => x.Id == Id);
        }

        // add todo into the list
        public Employee Create(Employee newEmployee)
        {
            newEmployee.Id = employees.Max(x => x.Id) + 1; // max id of your list
            employees.Add(newEmployee);
            return newEmployee;
        }

        // update todo in the list
        public Employee Edit(int employeeId, Employee newEmployee)
        {
            var oldEmployee = employees.Find(x => x.Id == employeeId);
            if (oldEmployee == null)
                return null;
            employees.Remove(oldEmployee);
            employees.Add(newEmployee);
            return newEmployee;
        }

        // delete 
        public Employee Delete(int employeeId)
        {
            var oldEmployee = employees.Find(x => x.Id == employeeId);
            if (oldEmployee == null)
                return null;
            employees.Remove(oldEmployee);
            return oldEmployee;
        }
    }
}
