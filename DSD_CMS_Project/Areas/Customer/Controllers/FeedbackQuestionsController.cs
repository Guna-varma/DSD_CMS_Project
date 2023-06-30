using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class FeedbackQuestionsController : Controller
    {

        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IUnitOfWork repo;

        private readonly IWebHostEnvironment env;

        public FeedbackQuestionsController(IUnitOfWork interactiveCSRepository)
        {
            repo = interactiveCSRepository;
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id <= 0)
            {
                // Create
                return View(new FeedbackQuestions());
            }

            FeedbackQuestions feedbackQuestions = repo.FeedbackQuestions.Get(u => u.Id == id);

            if (feedbackQuestions == null)
            {
                return NotFound("Feedback Question with id: " + id + " is not found!");
            }

            if (feedbackQuestions == null && id.HasValue)
            {
                return NotFound("id: " + id + " is not found!");
            }

            return View(feedbackQuestions);
        }

        [HttpPost]
        public IActionResult Upsert(FeedbackQuestions feedbackQuestions)
        {
            if (ModelState.IsValid)
            {
                if (feedbackQuestions.Id > 0)
                {
                    repo.FeedbackQuestions.Update(feedbackQuestions);
                    TempData["success"] = "Updated Successfully!";
                }
                else
                {
                    repo.FeedbackQuestions.Add(feedbackQuestions);
                    TempData["success"] = "Created Successfully!";
                }

                repo.Save();
                return RedirectToAction("Index");
            }

            return View(feedbackQuestions);
        }


        public IActionResult Index()
        {
            List<FeedbackQuestions> feedbackQuestionsList = repo.FeedbackQuestions.GetAll().ToList();
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<FeedbackQuestions> feedbackQuestionsList = repo.FeedbackQuestions.GetAll().ToList();

            return Json(new { data = feedbackQuestionsList });
        }

        public IActionResult Remove(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            FeedbackQuestions feedbackQuestionsFromDb = repo.FeedbackQuestions.Get(u => u.Id == id);
            if (feedbackQuestionsFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(feedbackQuestionsFromDb);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var fqToBeDeleted = repo.FeedbackQuestions.Get(u => u.Id == id);
            if (fqToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            repo.FeedbackQuestions.Remove(fqToBeDeleted);
            repo.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });

        }

    }
}
