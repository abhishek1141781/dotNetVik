using Microsoft.AspNetCore.Mvc;

namespace Abhishek_Web_MVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
