using MyApp.DB.DBOperation;
using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebAppEntityFramework.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository repository = null;
        public EmployeeController()
        {
            repository = new EmployeeRepository();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel empModel)
        {
            if (ModelState.IsValid)
            {
                int createdId = repository.AddNewEmployee(empModel);
                if (createdId > 0)
                {
                    ModelState.Clear();
                    ViewBag.successMessage = "Data Added Sucessfully";
                    return RedirectToAction("GetAllEmployeesData");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult GetAllEmployeesData()
        {
            var result = repository.GetAllEmployees();
            return View(result);
        }
        [HttpGet]
        public ActionResult GetEmployee(int id)
        {
            var result1 = repository.GetEmployees(id);
            return View(result1);
        }
    }
}