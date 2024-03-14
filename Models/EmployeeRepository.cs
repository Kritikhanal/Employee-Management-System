using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementSystemDbContext _employeeManagementSystemDbContext;

        public EmployeeRepository(EmployeeManagementSystemDbContext employeeManagementSystemDbContext)
        {

            _employeeManagementSystemDbContext = employeeManagementSystemDbContext;
        }
        

       
       
    public void AddEmployee(Employee employee)
        {

            _employeeManagementSystemDbContext.Employees.Add(employee);
            _employeeManagementSystemDbContext.SaveChanges();
        }

        public IEnumerable<Employee> AllEmployee
        {
            get
            {
                return _employeeManagementSystemDbContext.Employees;
            }
        }
        //yeha samma

        //edit ko lagi
        public Employee? GetEmployeeById(int employeeId)
        {

            return _employeeManagementSystemDbContext.Employees.FirstOrDefault(p => p.EmployeeId == employeeId);
        }

        public void UpdateEmployee(Employee employee)
        {

            var employeePart = _employeeManagementSystemDbContext.Employees.FirstOrDefault(p => p.EmployeeId == employee.EmployeeId);
            if (employeePart == null)
            {
                throw new ArgumentException("employee not found");
            }


            employeePart.Name = employee.Name;
            employeePart.Email = employee.Email;
            employeePart.ImageUrl = employee.ImageUrl;
            employeePart.Phone = employee.Phone;
            employeePart.Address = employee.Address;

            _employeeManagementSystemDbContext.Entry(employeePart).State = EntityState.Modified;
            _employeeManagementSystemDbContext.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {

            var employee = _employeeManagementSystemDbContext.Employees.Find(id);

            if (employee == null)
            {
                throw new ArgumentException("Employee not found");
            }


            _employeeManagementSystemDbContext.Employees.Remove(employee);
            _employeeManagementSystemDbContext.SaveChanges();

        }
    }


}
