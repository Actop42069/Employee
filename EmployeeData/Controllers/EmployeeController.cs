using EmployeeData.DAL;
using EmployeeData.Models;
using EmployeeData.Models.DBEntites;
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
                        DateOfBirth = employee.DateOfBirth,
                        Email = employee.Email,
                        Salary = employee.Salary
                    };
                    employeeList.Add(EmployeeViewModelcs);
                }
                return View(employeeList);
            }
            return View(employeeList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModelcs employeeData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        FirstName = employeeData.FirstName,
                        LastName = employeeData.LastName,
                        DateOfBirth = employeeData.DateOfBirth,
                        Email = employeeData.Email,
                        Salary = employeeData.Salary
                    };
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Thanks for entering your crucial information.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Milena bhai milena";
                    return View();
                }
            }
            catch (Exception ex)
            { 
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == Id);
            if(employee != null)
            {
                var employeeView = new EmployeeViewModelcs()
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DateOfBirth = employee.DateOfBirth,
                    Email = employee.Email,
                    Salary = employee.Salary
                };
				return View(employeeView);
			}
            else
            {
                TempData["errorMessage"] = $"Employee detail not available with the Id: {Id}";
            }
            
        }
    }
}
