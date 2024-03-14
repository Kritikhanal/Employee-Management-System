using Employee_Management_System.Models;
using Employee_Management_System.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_System.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult AddEmployee()
        {
            var viewModel = new AddEmployeeViewModel();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployee(AddEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                Employee newEmployee = new Employee
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,    
                    ImageUrl = viewModel.ImageUrl,
                    Phone = viewModel.Phone,
                    Address = viewModel.Address,
                };
                _employeeRepository.AddEmployee(newEmployee);
            }
            return RedirectToAction("EmployeeList");

        }
        [HttpGet]
        public IActionResult EmployeeList()
        {

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel(_employeeRepository.AllEmployee);
            return View(employeeListViewModel);
        }

        //update ko lagi

        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);

            var editEmployee = new UpdateEmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Email = employee.Email,
                ImageUrl = employee.ImageUrl,
                Phone = employee.Phone,
                Address = employee.Address,
            };


            return View(editEmployee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEmployee(UpdateEmployeeViewModel model)
        {
            var employee = _employeeRepository.GetEmployeeById(model.EmployeeId);

            employee.Name = model.Name;
            employee.Email = model.Email;
            employee.ImageUrl = model.ImageUrl;
            employee.Phone = model.Phone;
            employee.Address = model.Address;

            _employeeRepository.UpdateEmployee(employee);
            return RedirectToAction("EmployeeList");
        }

        public IActionResult DeleteEmployee(int id)
        {

            _employeeRepository.DeleteEmployee(id);

            return RedirectToAction("EmployeeList");


        }

    }
}
