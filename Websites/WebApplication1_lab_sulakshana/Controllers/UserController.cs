using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System;
using WebApplication1.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {

        DatabaseOperations db = new DatabaseOperations();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserData loginData)
        {
            if(loginData != null)
            {
                if(loginData.UserName=="abc" && loginData.Password=="abc@123") {
                
                    return RedirectToAction("Index");
                }
                
            }
            return View();
        }

        public IActionResult RegisterUser()
        {
            return View();
        }


        [HttpPost]
        public IActionResult RegisterUser(CreateUser userData)
        {
            db.InsertUser(userData);
            return View();
        }
    }


}
