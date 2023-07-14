using DSD_CMS.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSD_CMS_Project.Areas.Customer.Controllers
{
    public class LoginController : Controller
    {
        // Simulated database with hashed passwords
        private static readonly List<Login> Users = new List<Login>
        {
            new Login { userName = "user1", password = "12345" }, // Hash of "password1"
            new Login { userName = "user2", password = "123456" }, // Hash of "password2"
            // Add more users as needed
        };

        private static string HashPassword(string password)
        {
            // In this example, we are returning the password in plain text.
            // Remember that storing passwords in plain text is not secure and is strongly discouraged.
            return password;
        }


        [HttpPost]
        [Route("api/login")]
        public IActionResult Login([FromBody] Login user)
        {
            if (user == null || string.IsNullOrEmpty(user.userName) || string.IsNullOrEmpty(user.password))
            {
                return BadRequest("Username and password are required.");
            }

            var existingUser = Users.FirstOrDefault(u => u.userName == user.password);

            if (existingUser == null || existingUser.password != HashPassword(user.password))
            {
                return Unauthorized();
            }

            // Here you can generate a token using a proper authentication mechanism (e.g., JWT) and return it to the client.
            // For simplicity, we'll just return a simple message for successful login.
            return Ok("Login successful!");
        }
    }
}