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

        //public IActionResult Index()
        //{
        //    List<CarModel> carModelDetails = repo.CarModel.GetAll().ToList();
        //    return View(carModelDetails);
        //}

        [HttpGet]
        public IActionResult GetAll()
        {
            List<CarModel> carModelList = repo.CarModel.GetAll().ToList();
            return Json(new { data = carModelList });
        }

        public IActionResult Create()
        {
            CarModel carModel = new CarModel();
            return View(carModel);
        }

        [HttpPost]
        public IActionResult Create(CarModel carModel, IFormFile carImage, IFormFile frontAngleImage, IFormFile backAngleImage, IFormFile leftAngleImage, IFormFile rightAngleImage, IFormFile frontAngleLineImage, IFormFile backAngleLineImage, IFormFile leftAngleLineImage, IFormFile rightAngleLineImage)
        {
            if (ModelState.IsValid)
            {
                string wweRootPath = env.WebRootPath;

                // Process and save carImage
                if (carImage != null)
                {
                    string[] allowedImageExtensions = { ".png", ".jpg", ".jpeg" };
                    string carImageExtension = Path.GetExtension(carImage.FileName).ToLower();

                    if (!allowedImageExtensions.Contains(carImageExtension))
                    {
                        ModelState.AddModelError("CarImage", "Only .png, .jpeg, and .jpg files are allowed for the image.");
                        return View(carModel);
                    }

                    long maxImageFileSize = 1 * 1024 * 1024; // 2MB
                    if (carImage.Length > maxImageFileSize)
                    {
                        ModelState.AddModelError("CarImage", "Image file size must be less than 1MB.");
                        return View(carModel);
                    }

                    string carImageFileName = Guid.NewGuid().ToString() + carImageExtension;

                    string carImagePath = Path.Combine(wweRootPath, @"images\carModel\");

                    if (!string.IsNullOrEmpty(carModel.CarImage))
                    {
                        // Delete old image path
                        var oldImagePath = Path.Combine(wweRootPath, carModel.CarImage.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(carImagePath, carImageFileName), FileMode.Create))

                    {
                        carImage.CopyTo(fileStream);
                    }

                    carModel.CarImage = @"\images\carModel\" + carImageFileName;
                }

                // Process and save FrontAngleImage
                if (frontAngleImage != null)
                {
                    string[] allowedImageExtensions = { ".png", ".jpg", ".jpeg" };
                    string frontAngleImageExtension = Path.GetExtension(frontAngleImage.FileName).ToLower();

                    if (!allowedImageExtensions.Contains(frontAngleImageExtension))
                    {
                        ModelState.AddModelError("FrontAngleImage", "Only .png, .jpeg, and .jpg files are allowed for the image.");
                        return View(carModel);
                    }

                    long maxImageFileSize = 1 * 1024 * 1024; // 1MB
                    if (frontAngleImage.Length > maxImageFileSize)
                    {
                        ModelState.AddModelError("FrontAngleImage", "Image file size must be less than 1MB.");
                        return View(carModel);
                    }

                    string frontAngleImageFileName = Guid.NewGuid().ToString() + frontAngleImageExtension;

                    string frontAngleImagePath = Path.Combine(wweRootPath, frontAngleImageFileName);

                    if (!string.IsNullOrEmpty(carModel.FrontAngleImage))
                    {
                        // Delete old image path
                        string oldImagePath = Path.Combine(wweRootPath, carModel.FrontAngleImage.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(frontAngleImagePath, FileMode.Create))
                    {
                        frontAngleImage.CopyTo(fileStream);
                    }

                    carModel.FrontAngleImage = @"\images\carModel\" + frontAngleImageFileName;
                }

                // Process and save BackAngleImage
                if (backAngleImage != null)
                {
                    string[] allowedImageExtensions = { ".png", ".jpg", ".jpeg" };
                    string backAngleImageExtension = Path.GetExtension(backAngleImage.FileName).ToLower();

                    if (!allowedImageExtensions.Contains(backAngleImageExtension))
                    {
                        ModelState.AddModelError("BackAngleImage", "Only .png, .jpeg, and .jpg files are allowed for the image.");
                        return View(carModel);
                    }

                    long maxImageFileSize = 1 * 1024 * 1024; // 1MB
                    if (backAngleImage.Length > maxImageFileSize)
                    {
                        ModelState.AddModelError("BackAngleImage", "Image file size must be less than 1MB.");
                        return View(carModel);
                    }

                    string backAngleImageFileName = Guid.NewGuid().ToString() + backAngleImageExtension;

                    string backAngleImagePath = Path.Combine(wweRootPath, backAngleImageFileName);

                    if (!string.IsNullOrEmpty(carModel.BackAngleImage))
                    {
                        // Delete old image path
                        string oldImagePath = Path.Combine(wweRootPath, carModel.BackAngleImage.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(backAngleImagePath, FileMode.Create))
                    {
                        backAngleImage.CopyTo(fileStream);
                    }

                    carModel.BackAngleImage = @"\images\carModel\" + backAngleImageFileName;
                }

                // Process and save LeftAngleImage
                if (leftAngleImage != null)
                {
                    string[] allowedImageExtensions = { ".png", ".jpg", ".jpeg" };
                    string leftAngleImageExtension = Path.GetExtension(leftAngleImage.FileName).ToLower();

                    if (!allowedImageExtensions.Contains(leftAngleImageExtension))
                    {
                        ModelState.AddModelError("LeftAngleImage", "Only .png, .jpeg, and .jpg files are allowed for the image.");
                        return View(carModel);
                    }

                    long maxImageFileSize = 1 * 1024 * 1024; // 1MB
                    if (leftAngleImage.Length > maxImageFileSize)
                    {
                        ModelState.AddModelError("LeftAngleImage", "Image file size must be less than 1MB.");
                        return View(carModel);
                    }

                    string leftAngleImageFileName = Guid.NewGuid().ToString() + leftAngleImageExtension;

                    string leftAngleImagePath = Path.Combine(wweRootPath, leftAngleImageFileName);

                    if (!string.IsNullOrEmpty(carModel.LeftAngleImage))
                    {
                        // Delete old image path
                        string oldImagePath = Path.Combine(wweRootPath, carModel.LeftAngleImage.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(leftAngleImagePath, FileMode.Create))
                    {
                        leftAngleImage.CopyTo(fileStream);
                    }

                    carModel.LeftAngleImage = @"\images\carModel\" + leftAngleImageFileName;
                }

                // Process and save RightAngleImage
                if (rightAngleImage != null)
                {
                    string[] allowedImageExtensions = { ".png", ".jpg", ".jpeg" };
                    string rightAngleImageExtension = Path.GetExtension(rightAngleImage.FileName).ToLower();

                    if (!allowedImageExtensions.Contains(rightAngleImageExtension))
                    {
                        ModelState.AddModelError("RightAngleImage", "Only .png, .jpeg, and .jpg files are allowed for the image.");
                        return View(carModel);
                    }

                    long maxImageFileSize = 1 * 1024 * 1024; // 1MB
                    if (rightAngleImage.Length > maxImageFileSize)
                    {
                        ModelState.AddModelError("RightAngleImage", "Image file size must be less than 1MB.");
                        return View(carModel);
                    }

                    string rightAngleImageFileName = Guid.NewGuid().ToString() + rightAngleImageExtension;

                    string rightAngleImagePath = Path.Combine(wweRootPath, rightAngleImageFileName);

                    if (!string.IsNullOrEmpty(carModel.RightAngleImage))
                    {
                        // Delete old image path
                        string oldImagePath = Path.Combine(wweRootPath, carModel.RightAngleImage.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(rightAngleImagePath, FileMode.Create))
                    {
                        rightAngleImage.CopyTo(fileStream);
                    }

                    carModel.RightAngleImage = @"\images\carModel\" + rightAngleImageFileName;
                }

                // Process and save FrontAngleLineImage
                if (frontAngleLineImage != null)
                {
                    string[] allowedImageExtensions = { ".png", ".jpg", ".jpeg" };
                    string frontAngleLineImageExtension = Path.GetExtension(frontAngleLineImage.FileName).ToLower();

                    if (!allowedImageExtensions.Contains(frontAngleLineImageExtension))
                    {
                        ModelState.AddModelError("FrontAngleLineImage", "Only .png, .jpeg, and .jpg files are allowed for the image.");
                        return View(carModel);
                    }

                    long maxImageFileSize = 1 * 1024 * 1024; // 1MB
                    if (frontAngleLineImage.Length > maxImageFileSize)
                    {
                        ModelState.AddModelError("FrontAngleLineImage", "Image file size must be less than 1MB.");
                        return View(carModel);
                    }

                    string frontAngleLineImageFileName = Guid.NewGuid().ToString() + frontAngleLineImageExtension;

                    string frontAngleLineImagePath = Path.Combine(wweRootPath, frontAngleLineImageFileName);

                    if (!string.IsNullOrEmpty(carModel.FrontAngleLineImage))
                    {
                        // Delete old image path
                        string oldImagePath = Path.Combine(wweRootPath, carModel.FrontAngleLineImage.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(frontAngleLineImagePath, FileMode.Create))
                    {
                        frontAngleLineImage.CopyTo(fileStream);
                    }

                    carModel.FrontAngleLineImage = @"\images\carModel\" + frontAngleLineImageFileName;
                }

                // Process and save BackAngleLineImage
                if (backAngleLineImage != null)
                {
                    string[] allowedImageExtensions = { ".png", ".jpg", ".jpeg" };
                    string backAngleLineImageExtension = Path.GetExtension(backAngleLineImage.FileName).ToLower();

                    if (!allowedImageExtensions.Contains(backAngleLineImageExtension))
                    {
                        ModelState.AddModelError("BackAngleLineImage", "Only .png, .jpeg, and .jpg files are allowed for the image.");
                        return View(carModel);
                    }

                    long maxImageFileSize = 1 * 1024 * 1024; // 1MB
                    if (backAngleLineImage.Length > maxImageFileSize)
                    {
                        ModelState.AddModelError("BackAngleLineImage", "Image file size must be less than 1MB.");
                        return View(carModel);
                    }

                    string backAngleLineImageFileName = Guid.NewGuid().ToString() + backAngleLineImageExtension;

                    string backAngleLineImagePath = Path.Combine(wweRootPath, backAngleLineImageFileName);

                    if (!string.IsNullOrEmpty(carModel.BackAngleLineImage))
                    {
                        // Delete old image path
                        string oldImagePath = Path.Combine(wweRootPath, carModel.BackAngleLineImage.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(backAngleLineImagePath, FileMode.Create))
                    {
                        backAngleLineImage.CopyTo(fileStream);
                    }

                    carModel.BackAngleLineImage = @"\images\carModel\" + backAngleLineImageFileName;
                }

                // Process and save LeftAngleLineImage
                if (leftAngleLineImage != null)
                {
                    string[] allowedImageExtensions = { ".png", ".jpg", ".jpeg" };
                    string leftAngleLineImageExtension = Path.GetExtension(leftAngleLineImage.FileName).ToLower();

                    if (!allowedImageExtensions.Contains(leftAngleLineImageExtension))
                    {
                        ModelState.AddModelError("LeftAngleLineImage", "Only .png, .jpeg, and .jpg files are allowed for the image.");
                        return View(carModel);
                    }

                    long maxImageFileSize = 1 * 1024 * 1024; // 1MB
                    if (leftAngleLineImage.Length > maxImageFileSize)
                    {
                        ModelState.AddModelError("LeftAngleLineImage", "Image file size must be less than 1MB.");
                        return View(carModel);
                    }

                    string leftAngleLineImageFileName = Guid.NewGuid().ToString() + leftAngleLineImageExtension;

                    string leftAngleLineImagePath = Path.Combine(wweRootPath, leftAngleLineImageFileName);

                    if (!string.IsNullOrEmpty(carModel.LeftAngleLineImage))
                    {
                        // Delete old image path
                        string oldImagePath = Path.Combine(wweRootPath, carModel.LeftAngleLineImage.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(leftAngleLineImagePath, FileMode.Create))
                    {
                        leftAngleLineImage.CopyTo(fileStream);
                    }

                    carModel.LeftAngleLineImage = @"\images\carModel\" + leftAngleLineImageFileName;
                }

                // Process and save RightAngleLineImage
                if (rightAngleLineImage != null)
                {
                    string[] allowedImageExtensions = { ".png", ".jpg", ".jpeg" };
                    string rightAngleLineImageExtension = Path.GetExtension(rightAngleLineImage.FileName).ToLower();

                    if (!allowedImageExtensions.Contains(rightAngleLineImageExtension))
                    {
                        ModelState.AddModelError("RightAngleLineImage", "Only .png, .jpeg, and .jpg files are allowed for the image.");
                        return View(carModel);
                    }

                    long maxImageFileSize = 1 * 1024 * 1024; // 1MB
                    if (rightAngleLineImage.Length > maxImageFileSize)
                    {
                        ModelState.AddModelError("RightAngleLineImage", "Image file size must be less than 1MB.");
                        return View(carModel);
                    }

                    string rightAngleLineImageFileName = Guid.NewGuid().ToString() + rightAngleLineImageExtension;

                    string rightAngleLineImagePath = Path.Combine(wweRootPath, rightAngleLineImageFileName);

                    if (!string.IsNullOrEmpty(carModel.RightAngleLineImage))
                    {
                        // Delete old image path
                        string oldImagePath = Path.Combine(wweRootPath, carModel.RightAngleLineImage.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(rightAngleLineImagePath, FileMode.Create))
                    {
                        rightAngleLineImage.CopyTo(fileStream);
                    }

                    carModel.RightAngleLineImage = @"\images\carModel\" + rightAngleLineImageFileName;
                }

                repo.CarModel.Add(carModel);
                repo.Save();

                TempData["success"] = "Car Model Created Successfully!";

                return RedirectToAction("Index");
            }

            return View(carModel);
        }

    }
}