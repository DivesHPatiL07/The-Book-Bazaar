
using EntityBase;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context;

        public HomeController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            User onj = new User();
            return View();
        }
        [HttpPost]
        public IActionResult Login(User User)
        {

            var myUser = context.Users.Where(x =>  x.Email == User.Email && x.Password == User.Password).FirstOrDefault(); 
            if(myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.Email);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
