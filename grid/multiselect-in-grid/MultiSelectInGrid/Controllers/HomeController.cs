﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiSelectInGrid.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
namespace MultiSelectInGrid.Controllers
{
    public class HomeController : Controller
    {
        private NorthwindRepository repository = new NorthwindRepository();

        public ActionResult Index()
        {
            ViewData["territories"] = repository.Territories;

            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(repository.Employees.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateEmployee(employee);
            }

            return Json(new[] { employee }.ToDataSourceResult(new DataSourceRequest(), ModelState));
        }

        public ActionResult Create(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                employee.EmployeeID = repository.CreateEmployee(employee);
            }

            return Json(new[] { employee }.ToDataSourceResult(new DataSourceRequest(), ModelState));
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
