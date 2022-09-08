using HMS_web.Data;
using HMS_web.Models.Domain;
using HMS_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMS_web.Controllers
{
    public class PatientsController : Controller
    {
        private readonly MVCDBContext mvcDBContext;
        public PatientsController(MVCDBContext mvcDBContext)
        {
            this.mvcDBContext = mvcDBContext;
        }
        public async Task<IActionResult> Index()
        {
            var patient = await mvcDBContext.Patients.ToListAsync();
            return View(patient);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPatients addPatientsRequest)
        {
            var patients = new Patients()
            {
                Id = Guid.NewGuid(),
                Name = addPatientsRequest.Name,
                Surname = addPatientsRequest.Surname,
                Phone = addPatientsRequest.Phone,
                Email = addPatientsRequest.Email,
                MaritalStatus = addPatientsRequest.MaritalStatus,
                DOB = addPatientsRequest.DOB,
                Address = addPatientsRequest.Address,
            };
            await mvcDBContext.Patients.AddAsync(patients);
            await mvcDBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var patients = await mvcDBContext.Patients.FirstOrDefaultAsync(x => x.Id == id);

            if (patients == null)
            {
                var viewModel = new UpdatePatients()
                {
                    Name = patients.Name,
                    Surname = patients.Surname,
                    Phone = patients.Phone,
                    Email = patients.Email,
                    MaritalStatus = patients.MaritalStatus,
                    DOB = patients.DOB,
                    Address = patients.Address,
                };
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }
    }
}