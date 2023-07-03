using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class ApplicationImagesController : Controller
    {

        private readonly IUnitOfWork repo;
        private readonly IWebHostEnvironment env;

        public ApplicationImagesController(IUnitOfWork appImageRepository, IWebHostEnvironment environment)
        {
            repo = appImageRepository;
            env = environment;
        }


        public IActionResult Index()
        {
            List<ApplicationImages> applicationImagesList = repo.ApplicationImages.GetAll().ToList();
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationImages> applicationImagesList = repo.ApplicationImages.GetAll().ToList();
            return Json(new { data = applicationImagesList });
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id <= 0)
            {
                // Create
                return View(new ApplicationImages());
            }

            ApplicationImages applicationImages = repo.ApplicationImages.Get(u => u.Id == id);

            if (applicationImages == null)
            {
                return NotFound("Application Image with id: " + id + " is not found!");
            }

            if (applicationImages == null && id.HasValue)
            {
                return NotFound("id: " + id + " is not found!");
            }

            return View(applicationImages);
        }

        [HttpPost]
        public IActionResult Upsert(ApplicationImages applicationImages,
                                    IFormFile? uploadAssetIm,
                                    IFormFile? uploadThumbIm)
        {
            if (ModelState.IsValid) // Validations
            {
                string webRootPath = env.WebRootPath;

                // Handle main photo upload
                if (uploadAssetIm != null)
                {
                    if (!IsFileExtensionValid(uploadAssetIm.FileName, new[] { ".png", ".jpg", ".jpeg", ".mp4", ".mov", ".m4v" }))
                    {
                        ModelState.AddModelError("uploadAssetIm", "Only .png, .jpeg, .jpg, .mp4, .mov, and .m4v files are allowed.");
                        return View(applicationImages);
                    }

                    if (!IsFileSizeValid(uploadAssetIm.Length, 20 * 1024 * 1024))
                    {
                        ModelState.AddModelError("uploadAssetIm", "File size must be less than 20MB.");
                        return View(applicationImages);
                    }

                    applicationImages.UploadAsset = ProcessUploadedFile(uploadAssetIm, webRootPath, "AssetImage");
                }

                if (uploadThumbIm != null)
                {
                    if (!IsFileExtensionValid(uploadThumbIm.FileName, new[] { ".png", ".jpg", ".jpeg" }))
                    {
                        ModelState.AddModelError("uploadThumbIm", "Only .png, .jpeg, and .jpg files are allowed.");
                        return View(applicationImages);
                    }

                    if (!IsFileSizeValid(uploadThumbIm.Length, 20 * 1024 * 1024))
                    {
                        ModelState.AddModelError("uploadThumbIm", "File size must be less than 20MB.");
                        return View(applicationImages);
                    }

                    applicationImages.UploadThumbImage = ProcessUploadedFile(uploadThumbIm, webRootPath, "ThumbImage");
                }

                if (applicationImages.Id == null || applicationImages.Id == 0)
                {
                    repo.ApplicationImages.Add(applicationImages); // Add 
                    repo.Save(); // Save changes
                    TempData["success"] = "Created Successfully!";
                }
                else
                {
                    repo.ApplicationImages.Update(applicationImages); // Update 
                    repo.Save(); // Save changes
                    TempData["success"] = "Updated Successfully!";
                }

                return RedirectToAction("Index"); // Redirect to index action
            }

            return View(applicationImages);
        }

        private bool IsFileExtensionValid(string fileName, string[] allowedExtensions)
        {
            string fileExtension = Path.GetExtension(fileName).ToLower();
            return allowedExtensions.Contains(fileExtension);
        }

        private bool IsFileSizeValid(long fileSize, long maxFileSize)
        {
            return fileSize <= maxFileSize;
        }

        private string ProcessUploadedFile(IFormFile file, string webRootPath, string fileNamePrefix)
        {
            string uniqueFileName = $"{fileNamePrefix}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            string filePath = Path.Combine(webRootPath, "images", "ApplicationImages", uniqueFileName);

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

            return $"/images/applicationImages/{uniqueFileName}";
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var applicationImageToBeDeleted = repo.ApplicationImages.Get(u => u.Id == id);
            if (applicationImageToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            // Delete the old asset image path
            DeleteImage(applicationImageToBeDeleted.UploadAsset);

            // Delete the old thumb image path
            DeleteImage(applicationImageToBeDeleted.UploadThumbImage);

            repo.ApplicationImages.Remove(applicationImageToBeDeleted);
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

    }
}
