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
            List<CreateUser> users =db.GetUsers();
            return View(users);
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

        public IActionResult UserDetails(string id)
        {
            CreateUser user=db.GetSingleUser(id);
            return View(user);
        }



        [HttpGet]
        public IActionResult EditUser(string id) 
        {
            CreateUser user = db.GetSingleUser(id);
            return View(user);
        }



        [HttpPost]
        public IActionResult EditUser(string id, CreateUser user)
        {
            db.UpdateUser(id, user);

            return RedirectToAction("Index");
            
           
        }

        
        public ActionResult DeleteUser(string id)
        {
            db.DeleteUser(id);
           
            return RedirectToAction("Index");


        }

        //[HttpPost]
        //public ActionResult DeleteUser(string id,CreateUser user)
        //{
        //    db.DeleteUser(id);
        //    return RedirectToAction("Index");
        
        //}
    }


}
