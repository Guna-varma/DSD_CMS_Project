using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class ExtrasController : Controller
    {

        private readonly IUnitOfWork repo;
        private readonly IWebHostEnvironment env;

        public ExtrasController(IUnitOfWork extrasRepository, IWebHostEnvironment environment)
        {
            repo = extrasRepository;
            env = environment;
        }


        public IActionResult Index()
        {
            List<Extras> extrasList = repo.Extras.GetAll().ToList();
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Extras> extrasList = repo.Extras.GetAll().ToList();
            return Json(new { data = extrasList });
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id <= 0)
            {
                // Create
                return View(new Extras());
            }

            Extras extras = repo.Extras.Get(u => u.Id == id);

            if (extras == null)
            {
                return NotFound("Extras with id: " + id + " is not found!");
            }

            if (extras == null && id.HasValue)
            {
                return NotFound("id: " + id + " is not found!");
            }

            return View(extras);
        }

        [HttpPost]
        public IActionResult Upsert(Extras extras,
                                    IFormFile? thumbIm,
                                    IFormFile? assetIm)
        {
            if (ModelState.IsValid) // Validations
            {
                string webRootPath = env.WebRootPath;

                // Handle main photo upload
                if (thumbIm != null)
                {
                    if (!IsFileExtensionValid(thumbIm.FileName, new[] { ".png", ".jpg", ".jpeg" }))
                    {
                        ModelState.AddModelError("thumbIm", "Only .png, .jpeg, .jpg files are allowed.");
                        return View(extras);
                    }

                    if (!IsFileSizeValid(thumbIm.Length, 20 * 1024 * 1024))
                    {
                        ModelState.AddModelError("thumbIm", "File size must be less than 20MB.");
                        return View(extras);
                    }

                    extras.Asset = ProcessUploadedFile(thumbIm, webRootPath, "AssetImage");
                }

                if (assetIm != null)
                {
                    if (!IsFileExtensionValid(assetIm.FileName, new[] { ".png", ".jpg", ".jpeg", ".mp4", ".pdf" }))
                    {
                        ModelState.AddModelError("assetIm", "Only .png, .jpeg, .jpg, .mp4 and .pdf files are allowed.");
                        return View(extras);
                    }

                    if (!IsFileSizeValid(assetIm.Length, 20 * 1024 * 1024))
                    {
                        ModelState.AddModelError("assetIm", "File size must be less than 20MB.");
                        return View(extras);
                    }

                    extras.Thumb = ProcessUploadedFile(assetIm, webRootPath, "ThumbImage");
                }

                if (extras.Id == null || extras.Id == 0)
                {
                    repo.Extras.Add(extras); // Add 
                    repo.Save(); // Save changes
                    TempData["success"] = "Created Successfully!";
                }
                else
                {
                    repo.Extras.Update(extras); // Update
                    repo.Save(); // Save changes
                    TempData["success"] = "Updated Successfully!";
                }

                return RedirectToAction("Index"); // Redirect to index action
            }

            return View(extras);
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

            string filePath = Path.Combine(webRootPath, "images", "Extras", uniqueFileName);

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

            return $"/images/extras/{uniqueFileName}";
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var extrasToBeDeleted = repo.Extras.Get(u => u.Id == id);
            if (extrasToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            // Delete the old asset image path
            DeleteImage(extrasToBeDeleted.Asset);

            // Delete the old thumb image path
            DeleteImage(extrasToBeDeleted.Thumb);

            repo.Extras.Remove(extrasToBeDeleted);
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
