using HMS_web.Data;
using HMS_web.Models;
using HMS_web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMS_web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDBContext mvcDBContext;
        public EmployeesController(MVCDBContext mvcDBContext)
        {
            this.mvcDBContext = mvcDBContext;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await mvcDBContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Add(AddEmployees addEmployeesRequest)
        {
            var employees = new Employee()
            {
                Id = Guid.NewGuid(),
                EmployeeType = addEmployeesRequest.EmployeeType,
                Name = addEmployeesRequest.Name,
                Surname = addEmployeesRequest.Surname,
                Phone = addEmployeesRequest.Phone,
                Email = addEmployeesRequest.Email,
                MaritalStatus = addEmployeesRequest.MaritalStatus,
                DOB = addEmployeesRequest.DOB,
                Address = addEmployeesRequest.Address,
            };
            await mvcDBContext.Employees.AddAsync(employees);
            await mvcDBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var employee = await mvcDBContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if(employee == null)
            {
                var viewModel = new UpdateEmployee()
                {
                    EmployeeType = employee.EmployeeType,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    Phone = employee.Phone,
                    Email = employee.Email,
                    MaritalStatus = employee.MaritalStatus,
                    DOB = employee.DOB,
                    Address = employee.Address,
                };
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }
    }
}
