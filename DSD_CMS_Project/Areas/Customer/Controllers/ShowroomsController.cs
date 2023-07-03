using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.Model.Models;
using DSD_CMS.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class ShowroomsController : Controller
    {
        private readonly IUnitOfWork repo;
        private readonly IWebHostEnvironment env;

        public ShowroomsController(IUnitOfWork repository, IWebHostEnvironment environment)
        {
            repo = repository;
            env = environment;
        }

        public IActionResult Upsert(int? id)  // combining of 'Update' and 'Insert'.
        {
            ShowroomsVm showroomsVm = new()
            {
                DealersList = repo.Dealers.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DealerName,
                    Value = u.Id.ToString()
                }),
                Showrooms = new Showrooms()
            };
            if (id == null || id == 0)
            {
                //create
                return View(showroomsVm);
            }
            else
            {
                //update
                showroomsVm.Showrooms = repo.Showrooms.Get(u => u.Id == id);
                return View(showroomsVm);
            }
        }

        [HttpPost]
        public IActionResult Upsert(ShowroomsVm showroomsVm)
        {
            if (ModelState.IsValid) //validations
            {

                if (showroomsVm.Showrooms.Id == null || showroomsVm.Showrooms.Id == 0)
                {
                    repo.Showrooms.Add(showroomsVm.Showrooms); // add Product 

                    repo.Save(); //save
                    TempData["success"] = "Created Successfully!";
                }
                else
                {
                    repo.Showrooms.Update(showroomsVm.Showrooms); // add Product 

                    repo.Save(); //save
                    TempData["success"] = "Updated Successfully!";
                }

                return RedirectToAction("Index"); // add the data into db
            }

            else
            {
                showroomsVm.DealersList = repo.Dealers.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DealerName,
                    Value = u.Id.ToString()
                });
                return View(showroomsVm);
            }

        }

        public IActionResult Index()
        {
            List<Showrooms> showroomsList = repo.Showrooms.GetAll(includeProperties: "DealerName").ToList();
            return View(showroomsList);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Showrooms> showroomsList = repo.Showrooms.GetAll(includeProperties: "DealerName").ToList();
            return Json(new { data = showroomsList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var showroomsToBeDeleted = repo.Showrooms.Get(u => u.Id == id);
            if (showroomsToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            repo.Showrooms.Remove(showroomsToBeDeleted);
            repo.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });
        }

    }
}
