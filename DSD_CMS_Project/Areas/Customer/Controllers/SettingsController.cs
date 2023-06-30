using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class SettingsController : Controller
    {

        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IUnitOfWork repo;

        private readonly IWebHostEnvironment env;

        public SettingsController(IUnitOfWork repository)
        {
            repo = repository;
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id <= 0)
            {
                // Create
                return View(new Settings());
            }

            Settings settings = repo.Settings.Get(u => u.Id == id);

            if (settings == null)
            {
                return NotFound("Settings with id: " + id + " is not found!");
            }

            if (settings == null && id.HasValue)
            {
                return NotFound("id: " + id + " is not found!");
            }

            return View(settings);
        }

        [HttpPost]
        public IActionResult Upsert(Settings settings)
        {
            if (ModelState.IsValid)
            {
                if (settings.Id > 0)
                {
                    repo.Settings.Update(settings);
                    TempData["success"] = "Updated Successfully!";
                }
                else
                {
                    repo.Settings.Add(settings);
                    TempData["success"] = "Created Successfully!";
                }

                repo.Save();
                return RedirectToAction("Index");
            }

            return View(settings);
        }


        public IActionResult Index()
        {
            List<Settings> settingsList = repo.Settings.GetAll().ToList();
            return View(settingsList);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Settings> settingsList = repo.Settings.GetAll().ToList();

            return Json(new { data = settingsList });
        }

        public IActionResult Remove(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            Settings settingsFromDb = repo.Settings.Get(u => u.Id == id);
            if (settingsFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(settingsFromDb);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var settingsToBeDeleted = repo.Settings.Get(u => u.Id == id);
            if (settingsToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            repo.Settings.Remove(settingsToBeDeleted);
            repo.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });

        }

    }
}
