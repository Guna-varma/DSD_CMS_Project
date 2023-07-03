using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.Model.Models;
using DSD_CMS.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class VariantController : Controller
    {
        private readonly IUnitOfWork repo;
        private readonly IWebHostEnvironment env;

        public VariantController(IUnitOfWork repository, IWebHostEnvironment environment)
        {
            repo = repository;
            env = environment;
        }

        public IActionResult Upsert(int? id)  // combining of 'Update' and 'Insert'.
        {
            VariantVm variantVm = new()
            {
                CarModelList = repo.CarModel.GetAll().Select(u => new SelectListItem
                {
                    Text = u.ModelName,
                    Value = u.Id.ToString()
                }),
                Variant = new Variant()
            };
            if (id == null || id == 0)
            {
                //create
                return View(variantVm);
            }
            else
            {
                //update
                variantVm.Variant = repo.Variant.Get(u => u.Id == id);
                return View(variantVm);
            }
        }

        [HttpPost]
        public IActionResult Upsert(VariantVm variantVm)
        {
            if (ModelState.IsValid) //validations
            {

                if (variantVm.Variant.Id == null || variantVm.Variant.Id == 0)
                {
                    repo.Variant.Add(variantVm.Variant); // add Product 

                    repo.Save(); //save
                    TempData["success"] = "Created Successfully!";
                }
                else
                {
                    repo.Variant.Update(variantVm.Variant); // add Product 

                    repo.Save(); //save
                    TempData["success"] = "Updated Successfully!";
                }

                return RedirectToAction("Index"); // add the data into db
            }

            else
            {
                variantVm.CarModelList = repo.CarModel.GetAll().Select(u => new SelectListItem
                {
                    Text = u.ModelName,
                    Value = u.Id.ToString()
                });
                return View(variantVm);
            }
        }

        public IActionResult Index()
        {
            List<Variant> variantList = repo.Variant.GetAll(includeProperties: "CarModel").ToList();
            return View(variantList);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Variant> VariantList = repo.Variant.GetAll(includeProperties: "CarModel").ToList();
            return Json(new { data = VariantList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var variantToBeDeleted = repo.Variant.Get(u => u.Id == id);
            if (variantToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            repo.Variant.Remove(variantToBeDeleted);
            repo.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });
        }

    }
}
