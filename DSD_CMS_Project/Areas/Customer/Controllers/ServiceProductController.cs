using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class ServiceProductController : Controller
    {

        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IUnitOfWork repo;

        private readonly IWebHostEnvironment env;

        public ServiceProductController(IUnitOfWork repository)
        {
            repo = repository;
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id <= 0)
            {
                // Create
                return View(new ServiceProduct());
            }

            ServiceProduct serviceProduct = repo.ServiceProduct.Get(u => u.Id == id);

            if (serviceProduct == null)
            {
                return NotFound("Service Product with id: " + id + " is not found!");
            }

            if (serviceProduct == null && id.HasValue)
            {
                return NotFound("id: " + id + " is not found!");
            }

            return View(serviceProduct);
        }

        [HttpPost]
        public IActionResult Upsert(ServiceProduct serviceProduct)
        {
            if (ModelState.IsValid)
            {
                if (serviceProduct.Id > 0)
                {
                    repo.ServiceProduct.Update(serviceProduct);
                    TempData["success"] = "Updated Successfully!";
                }
                else
                {
                    repo.ServiceProduct.Add(serviceProduct);
                    TempData["success"] = "Created Successfully!";
                }

                repo.Save();
                return RedirectToAction("Index");
            }

            return View(serviceProduct);
        }


        public IActionResult Index()
        {
            List<ServiceProduct> serviceProductList = repo.ServiceProduct.GetAll().ToList();
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ServiceProduct> serviceProductList = repo.ServiceProduct.GetAll().ToList();

            return Json(new { data = serviceProductList });
        }

        public IActionResult Remove(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            ServiceProduct serviceProductFromDb = repo.ServiceProduct.Get(u => u.Id == id);
            if (serviceProductFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(serviceProductFromDb);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var spToBeDeleted = repo.ServiceProduct.Get(u => u.Id == id);
            if (spToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            repo.ServiceProduct.Remove(spToBeDeleted);
            repo.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });

        }

    }

}
