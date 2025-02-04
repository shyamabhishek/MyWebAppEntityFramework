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
                repository.AddNewEmployee(empModel);

            }
            return View();
        }
    }
}