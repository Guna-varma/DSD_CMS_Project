using Microsoft.AspNetCore.Mvc;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class HealthCardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
