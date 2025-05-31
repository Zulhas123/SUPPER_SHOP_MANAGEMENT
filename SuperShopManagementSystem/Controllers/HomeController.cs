using Microsoft.AspNetCore.Mvc;
using SuperShopManagementSystem.Models;
using System.Diagnostics;

namespace SuperShopManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult GetCookie()
        {

            if (User.Identity.IsAuthenticated)
            {

                string userEmail = User.Identity.Name;


                return RedirectToAction("Index", "Home");
            }
            else
            {

                return null;
            }
        }

        public IActionResult Index()
        {
            var currentUser = GetCookie();

            if (currentUser != null)
            {

                return View();

            }
            return Redirect("/Identity/Account/Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Logout()
        {
            // Clear authentication-related cookies
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            // Redirect to the login page
            return Redirect("/Identity/Account/Login");
        }
    }
}
