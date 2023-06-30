using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.Model.Models;
using Elfie.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class CarModelController : Controller
    {

        private readonly IUnitOfWork repo;
        private readonly IWebHostEnvironment env;

        public CarModelController(IUnitOfWork categoryRepository, IWebHostEnvironment environment)
        {
            repo = categoryRepository;
            env = environment;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<CarModel> carModelList = repo.CarModel.GetAll().ToList();
            return Json(new { data = carModelList });
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id <= 0)
            {
                // Create
                return View(new CarModel());
            }

            CarModel carModel = repo.CarModel.Get(u => u.Id == id);

            if (carModel == null)
            {
                return NotFound("Car Model with id: " + id + " is not found!");
            }

            if (carModel == null && id.HasValue)
            {
                return NotFound("id: " + id + " is not found!");
            }

            return View(carModel);
        }

        [HttpPost]
        public IActionResult Upsert(CarModel carModel, 
                                    IFormFile? carIm,
                                    IFormFile? frontAngleIm,
                                    IFormFile? backAngleIm,
                                    IFormFile? leftAngleIm,
                                    IFormFile? rightAngleIm,
                                    IFormFile? frontAngleLineIm,
                                    IFormFile? backAngleLineIm,
                                    IFormFile? leftAngleLineIm,
                                    IFormFile? rightAngleLineIm)
        {
            if (ModelState.IsValid) // Validations
            {
                string webRootPath = env.WebRootPath;

                // Handle main photo upload
                if (carIm != null)
                {
                    carModel.CarImage = ProcessUploadedFile(carIm, webRootPath, "carImage");
                }

                if (frontAngleIm != null)
                {
                    carModel.FrontAngleImage = ProcessUploadedFile(frontAngleIm, webRootPath, "frontAngleImage");
                }

                if (backAngleIm != null)
                {
                    carModel.BackAngleImage = ProcessUploadedFile(backAngleIm, webRootPath, "backAngleImage");
                }

                if (leftAngleIm != null)
                {
                    carModel.LeftAngleImage = ProcessUploadedFile(leftAngleIm, webRootPath, "leftAngleImage");
                }

                if (rightAngleIm != null)
                {
                    carModel.RightAngleImage = ProcessUploadedFile(rightAngleIm, webRootPath, "rightAngleImage");
                }

                if (frontAngleLineIm != null)
                {
                    carModel.FrontAngleLineImage = ProcessUploadedFile(frontAngleLineIm, webRootPath, "frontAngleLineImage");
                }

                if (backAngleLineIm != null)
                {
                    carModel.BackAngleLineImage = ProcessUploadedFile(backAngleLineIm, webRootPath, "backAngleLineImage");
                }

                if (leftAngleLineIm != null)
                {
                    carModel.LeftAngleLineImage = ProcessUploadedFile(leftAngleLineIm, webRootPath, "leftAngleLineImage");
                }

                if (rightAngleLineIm != null)
                {
                    carModel.RightAngleLineImage = ProcessUploadedFile(rightAngleLineIm, webRootPath, "rightAngleLineImage");
                }

                if (carModel.Id == null || carModel.Id == 0)
                {
                    repo.CarModel.Add(carModel); // Add employee details
                    repo.Save(); // Save changes
                    TempData["success"] = "Created Successfully!";
                }
                else
                {
                    repo.CarModel.Update(carModel); // Update employee details
                    repo.Save(); // Save changes
                    TempData["success"] = "Updated Successfully!";
                }

                return RedirectToAction("Index"); // Redirect to index action
            }
            
            return View(carModel);

        }

        private string ProcessUploadedFile(IFormFile file, string webRootPath, string fileNamePrefix)
        {
            // File type validation
            string[] allowedExtensions = { ".png", ".jpg", ".jpeg" };
            string fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension))
            {
                ModelState.AddModelError("File", "Only .png, .jpeg and .jpg files are allowed.");
                return null; // Return null or handle the error accordingly
            }

            // File size validation
            long maxFileSize = 1 * 1024 * 1024; // 1MB
            if (file.Length > maxFileSize)
            {
                ModelState.AddModelError("File", "File size must be less than 1MB.");
                return null; // Return null or handle the error accordingly
            }

            string uniqueFileName = $"{fileNamePrefix}_{Guid.NewGuid()}{fileExtension}";

            string filePath = Path.Combine(webRootPath, "images", "carModel", uniqueFileName);

            // Delete old image path
            if (!string.IsNullOrEmpty(filePath))
            {
                string oldImagePath = Path.Combine(webRootPath, filePath.TrimStart('/'));

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return $"/images/carModel/{uniqueFileName}";
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var carModelToBeDeleted = repo.CarModel.Get(u => u.Id == id);
            if (carModelToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            // Delete the car images
            DeleteImage(carModelToBeDeleted.CarImage);
            DeleteImage(carModelToBeDeleted.FrontAngleImage);
            DeleteImage(carModelToBeDeleted.BackAngleImage);
            DeleteImage(carModelToBeDeleted.LeftAngleImage);
            DeleteImage(carModelToBeDeleted.RightAngleImage);
            DeleteImage(carModelToBeDeleted.FrontAngleLineImage);
            DeleteImage(carModelToBeDeleted.BackAngleLineImage);
            DeleteImage(carModelToBeDeleted.LeftAngleLineImage);
            DeleteImage(carModelToBeDeleted.RightAngleLineImage);

            repo.CarModel.Remove(carModelToBeDeleted);
            repo.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });
        }

        private void DeleteImage(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                string filePath = Path.Combine(env.WebRootPath, imagePath.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
        }


       /* 
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var carModelToBeDeleted = repo.CarModel.Get(u => u.Id == id);
            if (carModelToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            repo.CarModel.Remove(carModelToBeDeleted);
            repo.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });
        } 
       */

    }
}