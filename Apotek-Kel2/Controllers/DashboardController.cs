using Microsoft.AspNetCore.Mvc;

namespace Apotek_Kel2.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
