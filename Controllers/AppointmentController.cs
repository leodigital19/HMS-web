using Microsoft.AspNetCore.Mvc;

namespace HMS_web.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
