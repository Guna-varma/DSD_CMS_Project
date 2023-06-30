using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class DealersController : Controller
    {

        private readonly IUnitOfWork repo;


        private readonly IWebHostEnvironment env;

        public DealersController(IUnitOfWork dealerRepository)
        {
            repo = dealerRepository;
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id <= 0)
            {
                // Create
                return View(new Dealers());
            }

            Dealers dealers = repo.Dealers.Get(u => u.Id == id);

            if (dealers == null)
            {
                return NotFound("Service Product with id: " + id + " is not found!");
            }

            if (dealers == null && id.HasValue)
            {
                return NotFound("id: " + id + " is not found!");
            }

            return View(dealers);
        }

        [HttpPost]
        public IActionResult Upsert(Dealers dealers)
        {
            if (ModelState.IsValid)
            {
                if (dealers.Id > 0)
                {
                    repo.Dealers.Update(dealers);
                    TempData["success"] = "Updated Successfully!";
                }
                else
                {
                    repo.Dealers.Add(dealers);
                    TempData["success"] = "Created Successfully!";
                }

                repo.Save();
                return RedirectToAction("Index");
            }

            return View(dealers);
        }


        public IActionResult Index()
        {
            List<Dealers> dealersList = repo.Dealers.GetAll().ToList();
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Dealers> dealersList = repo.Dealers.GetAll().ToList();

            return Json(new { data = dealersList });
        }

        public IActionResult Remove(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            Dealers dealersFromDb = repo.Dealers.Get(u => u.Id == id);
            if (dealersFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(dealersFromDb);
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var dealersToBeDeleted = repo.Dealers.Get(u => u.Id == id);
            if (dealersToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            repo.Dealers.Remove(dealersToBeDeleted);
            repo.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });

        }


    }
}