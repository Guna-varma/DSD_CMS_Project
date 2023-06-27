using Microsoft.AspNetCore.Mvc;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class FeedbackQuestionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
