using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class InsideInventoryController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IUnitOfWork repo;

        private readonly IWebHostEnvironment env;

        public InsideInventoryController(IUnitOfWork insideInventoryRepository)
        {
            repo = insideInventoryRepository;
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id <= 0)
            {
                // Create
                return View(new InsideInventory());
            }

            InsideInventory insideInv = repo.InsideInventory.Get(u => u.Id == id);

            if (insideInv == null)
            {
                return NotFound("Inside Inventory with id: " + id + " is not found!");
            }

            if (insideInv == null && id.HasValue)
            {
                return NotFound("id: " + id + " is not found!");
            }

            return View(insideInv);
        }

        [HttpPost]
        public IActionResult Upsert(InsideInventory insideInv)
        {
            if (ModelState.IsValid)
            {
                if (insideInv.Id > 0)
                {
                    repo.InsideInventory.Update(insideInv);
                    TempData["success"] = "Updated Successfully!";
                }
                else
                {
                    repo.InsideInventory.Add(insideInv);
                    TempData["success"] = "Created Successfully!";
                }

                repo.Save();
                return RedirectToAction("Index");
            }

            return View(insideInv);
        }


        public IActionResult Index()
        {
            List<InsideInventory> insideInvList = repo.InsideInventory.GetAll().ToList();
            return View(insideInvList);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<InsideInventory> insideInvList = repo.InsideInventory.GetAll().ToList();

            return Json(new { data = insideInvList });
        }

        public IActionResult Remove(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            InsideInventory insideInvFromDb = repo.InsideInventory.Get(u => u.Id == id);
            if (insideInvFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(insideInvFromDb);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var inventoryToBeDeleted = repo.InsideInventory.Get(u => u.Id == id);
            if (inventoryToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            repo.InsideInventory.Remove(inventoryToBeDeleted);
            repo.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });
        }

    }

}

