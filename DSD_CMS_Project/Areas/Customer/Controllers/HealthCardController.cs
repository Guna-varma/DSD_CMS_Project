using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class HealthCardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HealthCardController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id <= 0)
            {
                // Create
                return View(new HealthCard());
            }

            HealthCard healthCard = _unitOfWork.HealthCard.Get(u => u.Id == id);

            if (healthCard == null)
            {
                return NotFound("Health Card with id: " + id + " is not found!");
            }

            return View(healthCard);
        }

        [HttpPost]
        public IActionResult Upsert(HealthCard healthCard)
        {
            if (ModelState.IsValid)
            {
                if (healthCard.Id > 0)
                {
                    _unitOfWork.HealthCard.Update(healthCard);
                    TempData["success"] = "Updated Successfully!";
                }
                else
                {
                    _unitOfWork.HealthCard.Add(healthCard);
                    TempData["success"] = "Created Successfully!";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(healthCard);
        }

        public IActionResult Index()
        {
            List<HealthCard> healthCardList = _unitOfWork.HealthCard.GetAll().ToList();
            return View(healthCardList);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<HealthCard> healthCardList = _unitOfWork.HealthCard.GetAll().ToList();

            return Json(new { data = healthCardList });
        }

        public IActionResult Remove(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound("No Id is found");
            }

            HealthCard healthCardFromDb = _unitOfWork.HealthCard.Get(u => u.Id == id);
            if (healthCardFromDb == null)
            {
                return NotFound("id: " + id + " is not found!");
            }

            return View(healthCardFromDb);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var healthCardToBeDeleted = _unitOfWork.HealthCard.Get(u => u.Id == id);
            if (healthCardToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            _unitOfWork.HealthCard.Remove(healthCardToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });
        }

        public IActionResult ExportToExcel()
        {
            try
            {
                // Set EPPlus license context
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                // Retrieve data from the database
                List<HealthCard> healthCardList = _unitOfWork.HealthCard.GetAll().ToList();

                // Check if data is available
                if (healthCardList.Count == 0)
                {
                    TempData["error"] = "No data available for export.";
                    return RedirectToAction("Index");
                }

                // Create the Excel package
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    // Create a new sheet for health card data
                    var worksheet = excelPackage.Workbook.Worksheets.Add("HealthCardData");

                    // Set the column headers
                    worksheet.Cells[1, 1].Value = "SR#";
                    worksheet.Cells[1, 2].Value = "Customer";
                    worksheet.Cells[1, 3].Value = "Mileage";
                    worksheet.Cells[1, 4].Value = "Tread depth";
                    worksheet.Cells[1, 5].Value = "Brake pad";
                    worksheet.Cells[1, 6].Value = "Brake disc";
                    worksheet.Cells[1, 7].Value = "Battery";

                    // Populate the data rows
                    int row = 2;
                    foreach (var healthCard in healthCardList)
                    {
                        worksheet.Cells[row, 1].Value = healthCard.Sr;
                        worksheet.Cells[row, 2].Value = healthCard.Customer;
                        worksheet.Cells[row, 3].Value = healthCard.Mileage;
                        worksheet.Cells[row, 4].Value = healthCard.TreadDepth;
                        worksheet.Cells[row, 5].Value = healthCard.Breakpad;
                        worksheet.Cells[row, 6].Value = healthCard.BreakDisc;
                        worksheet.Cells[row, 7].Value = healthCard.Battery;

                        row++;
                    }

                    // Prepare the Excel file content
                    byte[] excelBytes = excelPackage.GetAsByteArray();
                    string fileName = "HealthCardData.xlsx";
                    string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                    // Return the Excel file
                    return File(excelBytes, contentType, fileName);
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your requirements
                TempData["error"] = "An error occurred while exporting data to Excel: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

    }
}
