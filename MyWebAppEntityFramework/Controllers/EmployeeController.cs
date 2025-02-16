using MyApp.DB.DBOperation;
using MyApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
                    RedirectToAction("GetAllEmployeesData");
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = repository.GetEmployees(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id, EmployeeModel emp)
        {
            if (ModelState.IsValid)
            {
                bool isResult = repository.UpdateEmployee(id, emp);
                if (isResult)
                {
                    return RedirectToAction("GetAllEmployeesData");
                }
            }
            return View(emp);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var result = repository.GetEmployees(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Delete(int id, EmployeeModel emp)
        {
            bool result = repository.DeleteEmployee(id);
            return RedirectToAction("GetAllEmployeesData");

        }

        [HttpGet]
        public ActionResult GetEmployeeByJquery()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetEmployeeDataByJquery()
        {
            var result = repository.GetAllEmployees().FirstOrDefault();
            var jsonData = JsonConvert.SerializeObject(result);
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult PostEmployeeData(EmployeeModel emp)
        {
            return Json(emp, JsonRequestBehavior.AllowGet);
        }

    }
}