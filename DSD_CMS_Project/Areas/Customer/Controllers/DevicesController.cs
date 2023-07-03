using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.Model.Models;
using DSD_CMS.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IUnitOfWork repo;
        private readonly IWebHostEnvironment env;

        public DevicesController(IUnitOfWork repository, IWebHostEnvironment environment)
        {
            repo = repository;
            env = environment;
        }

        public IActionResult Upsert(int? id)  // combining of 'Update' and 'Insert'.
        {
            DevicesVm devicesVm = new()
            {
                DealersList = repo.Dealers.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DealerName,
                    Value = u.Id.ToString()
                }),

                ShowroomsList = repo.Showrooms.GetAll().Select(u => new SelectListItem
                {
                    Text = u.ShowroomName,
                    Value = u.Id.ToString()
                }),
                Devices = new Devices()
            };
            if (id == null || id == 0)
            {
                //create
                return View(devicesVm);
            }
            else
            {
                //update
                devicesVm.Devices = repo.Devices.Get(u => u.Id == id);
                return View(devicesVm);
            }
        }

        [HttpPost]
        public IActionResult Upsert(DevicesVm devicesVm)
        {
            if (ModelState.IsValid) //validations
            {

                if (devicesVm.Devices.Id == null || devicesVm.Devices.Id == 0)
                {
                    repo.Devices.Add(devicesVm.Devices); // add Product 

                    repo.Save(); //save
                    TempData["success"] = "Created Successfully!";
                }
                else
                {
                    repo.Devices.Update(devicesVm.Devices); // add Product 

                    repo.Save(); //save
                    TempData["success"] = "Updated Successfully!";
                }

                return RedirectToAction("Index"); // add the data into db
            }

            else
            {
                devicesVm.DealersList = repo.Dealers.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DealerName,
                    Value = u.Id.ToString()
                });

                devicesVm.ShowroomsList = repo.Showrooms.GetAll().Select(u => new SelectListItem
                {
                    Text = u.ShowroomName,
                    Value = u.Id.ToString()
                });

                return View(devicesVm);
            }

        }

        public IActionResult Index()
        {
            List<Devices> devicesList = repo.Devices.GetAll(includeProperties: "Dealer,Showroom").ToList();
            return View(devicesList);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Devices> devicesList = repo.Devices.GetAll(includeProperties: "Dealer,Showroom").ToList();
            return Json(new { data = devicesList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var devicesToBeDeleted = repo.Devices.Get(u => u.Id == id);
            if (devicesToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            repo.Devices.Remove(devicesToBeDeleted);
            repo.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });
        }

    }
}
