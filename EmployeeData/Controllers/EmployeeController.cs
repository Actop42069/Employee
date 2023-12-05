using EmployeeData.DAL;
using EmployeeData.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeData.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;
        public EmployeeController(EmployeeDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
			List<EmployeeViewModelcs> employeeList = new List<EmployeeViewModelcs>();

			if (employees != null)
            {
                foreach(var employee in employees)
                {
                    var EmployeeViewModelcs = new EmployeeViewModelcs()
                    {
                        Id = employee.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Email = employee.Email,
                        Salary = employee.Salary
                    };
                    employeeList.Add(EmployeeViewModelcs);
                }
                return View(employeeList);
            }
            return View(employeeList);
        }
    }
}
