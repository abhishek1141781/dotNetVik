using System.Data;
using System.Data.Common;
using AbhishekBasicMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AbhishekBasicMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public ActionResult Index()
        {
            return View(DatabaseOperations.GetAllStudents());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(DatabaseOperations.GetStudent(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student stud)
        {
            try
            {
                Student s = new Student { StudId = stud.StudId, Name = stud.Name, Email = stud.Email, City = stud.City };
                DatabaseOperations.AddStudent(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(DatabaseOperations.GetStudent(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student stud)
        {
            try
            {
                DatabaseOperations.EditStudent(stud);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(DatabaseOperations.GetStudent(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Student stud)
        {
            try
            {
                DatabaseOperations.DeleteStudent(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
