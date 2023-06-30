using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class HealthCardController : Controller
    {

        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IUnitOfWork repo;

        private readonly IWebHostEnvironment env;

        public HealthCardController(IUnitOfWork healthRepository)
        {
            repo = healthRepository;
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id <= 0)
            {
                // Create
                return View(new HealthCard());
            }

            HealthCard healthCard = repo.HealthCard.Get(u => u.Id == id);

            if (healthCard == null)
            {
                return NotFound("Health Card with id: " + id + " is not found!");
            }

            if (healthCard == null && id.HasValue)
            {
                return NotFound("id: " + id + " is not found!");
            }

            return View(healthCard);
        }

        [HttpPost]
        public IActionResult Upsert(HealthCard healthCard)
        {
            if (ModelState.IsValid)
            {
                if (healthCard.Id > 0)
                {
                    repo.HealthCard.Update(healthCard);
                    TempData["success"] = "Updated Successfully!";
                }
                else
                {
                    repo.HealthCard.Add(healthCard);
                    TempData["success"] = "Created Successfully!";
                }

                repo.Save();
                return RedirectToAction("Index");
            }

            return View(healthCard);
        }


        public IActionResult Index()
        {
            List<HealthCard> healthCardList = repo.HealthCard.GetAll().ToList();
            return View(healthCardList);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<HealthCard> healthCardList = repo.HealthCard.GetAll().ToList();

            return Json(new { data = healthCardList });
        }

        public IActionResult Remove(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            HealthCard healthCardFromDb = repo.HealthCard.Get(u => u.Id == id);
            if (healthCardFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(healthCardFromDb);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var healthCardToBeDeleted = repo.HealthCard.Get(u => u.Id == id);
            if (healthCardToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            repo.HealthCard.Remove(healthCardToBeDeleted);
            repo.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });

        }

    }
}
