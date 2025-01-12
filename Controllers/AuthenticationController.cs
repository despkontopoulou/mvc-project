using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models; 
using System.Threading.Tasks;
namespace MVCProject.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly MVCProjContext _context;
        public AuthenticationController(MVCProjContext context)
        {
            _context = context;
        }
        //get:login
        public IActionResult Index()
        {
            return View();
        }


        //Post:Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user= await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                TempData["LoginMessage"] = "Invalid username";
                return RedirectToAction("Index", "Authentication");
            }

            bool isPasswordValid = VerifyPassword(password, user.PasswordHash);

            if (isPasswordValid)
            {
                //redirect and show message
                TempData["LoginMessage"] = "Login Succesfull";
                return RedirectToAction("Index", "Home");
            }

            TempData["LoginMessage"] = "Invalid credentials";
            return RedirectToAction("Index", "Authentication"); ;

        }
        public static bool VerifyPassword(string password, string passwordHash) {
            var passwordHasher = new PasswordHasher<object>();
            var result = passwordHasher.VerifyHashedPassword(null, passwordHash, password);
            return result == PasswordVerificationResult.Success;
        }
        //public static string HashPassword(string password)
        //{
        //    if (string.IsNullOrWhiteSpace(password))
        //    {
        //        throw new ArgumentException("Password cannot be null or empty", nameof(password));
        //    }

        //    var passwordHasher = new PasswordHasher<object>();
        //    return passwordHasher.HashPassword(null, password);
        //}
    }

}

