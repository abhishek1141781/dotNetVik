﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCFinalBasic.Models;

namespace MVCFinalBasic.Controllers
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
                // below is not a constructor of student
                Student s = new Student { StudentNo = stud.StudentNo, Name = stud.Name, Divison = stud.Divison, Branch = stud.Branch, EmailId = stud.EmailId};
                DatabaseOperations.AddStudent(stud);
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
        public ActionResult Edit(Student stud)
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
