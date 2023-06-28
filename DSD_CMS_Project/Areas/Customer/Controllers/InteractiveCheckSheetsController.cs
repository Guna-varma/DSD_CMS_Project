using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class InteractiveCheckSheetsController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IUnitOfWork repo;

        private readonly IWebHostEnvironment env;

        public InteractiveCheckSheetsController(IUnitOfWork interactiveCSRepository)
        {
            repo = interactiveCSRepository;
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id <= 0)
            {
                // Create
                return View(new InteractiveChecksheets());
            }

            InteractiveChecksheets inCS = repo.InteractiveCS.Get(u => u.Id == id);

            if (inCS == null)
            {
                return NotFound("Interactive checksheets with id: " + id + " is not found!");
            }

            if (inCS == null && id.HasValue)
            {
                return NotFound("id: " + id + " is not found!");
            }

            return View(inCS);
        }

        [HttpPost]
        public IActionResult Upsert(InteractiveChecksheets inCS)
        {
            if (ModelState.IsValid)
            {
                if (inCS.Id > 0)
                {
                    repo.InteractiveCS.Update(inCS);
                    TempData["success"] = "Updated Successfully!";
                }
                else
                {
                    repo.InteractiveCS.Add(inCS);
                    TempData["success"] = "Created Successfully!";
                }

                repo.Save();
                return RedirectToAction("Index");
            }

            return View(inCS);
        }


        public IActionResult Index()
        {
            List<InteractiveChecksheets> inCSList = repo.InteractiveCS.GetAll().ToList();
            return View(inCSList);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<InteractiveChecksheets> inCSList = repo.InteractiveCS.GetAll().ToList();

            return Json(new { data = inCSList });
        }

        public IActionResult Remove(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            InteractiveChecksheets inCSFromDb = repo.InteractiveCS.Get(u => u.Id == id);
            if (inCSFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(inCSFromDb);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var deptToBeDeleted = repo.InteractiveCS.Get(u => u.Id == id);
            if (deptToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            repo.InteractiveCS.Remove(deptToBeDeleted);
            repo.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });
        }

    }
}
