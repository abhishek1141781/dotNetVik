using b1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace b1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        public ActionResult Index()
        {
            return View(DbOperations.GetAllEmployees());
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(DbOperations.GetEmployee(id));
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                DbOperations.EditEmployee(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
