using DSD_CMS.DataAccess.Repository.IRepository;
using DSD_CMS.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class UsersController : Controller
    {

        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IUnitOfWork repo;

        private readonly IWebHostEnvironment env;

        public UsersController(IUnitOfWork repository)
        {
            repo = repository;
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id <= 0)
            {
                // Create
                return View(new Users());
            }

            Users users = repo.Users.Get(u => u.Id == id);

            if (users == null)
            {
                return NotFound("User with id: " + id + " is not found!");
            }

            if (users == null && id.HasValue)
            {
                return NotFound("id: " + id + " is not found!");
            }

            return View(users);
        }

        [HttpPost]
        public IActionResult Upsert(Users users)
        {
            if (ModelState.IsValid)
            {
                if (users.Id > 0)
                {
                    repo.Users.Update(users);
                    TempData["success"] = "Updated Successfully!";
                }
                else
                {
                    repo.Users.Add(users);
                    TempData["success"] = "Created Successfully!";
                }

                repo.Save();
                return RedirectToAction("Index");
            }

            return View(users);
        }


        public IActionResult Index()
        {
            List<Users> usersList = repo.Users.GetAll().ToList();
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Users> usersList = repo.Users.GetAll().ToList();

            return Json(new { data = usersList });
        }

        public IActionResult Remove(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            Users usersFromDb = repo.Users.Get(u => u.Id == id);
            if (usersFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(usersFromDb);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var usersToBeDeleted = repo.Users.Get(u => u.Id == id);
            if (usersToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            repo.Users.Remove(usersToBeDeleted);
            repo.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });

        }

    }
}
