using EmployeeManager.Data;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            EmpoyeeModel _empoyeeModel = new EmpoyeeModel();
            return View(_empoyeeModel);
        }
        [HttpPost]
        public IActionResult Index(EmpoyeeModel _empoyeeModel)
        {
            EmployeeContext _employeeContext = new EmployeeContext();
            var status = _employeeContext.EmployeeLogin.Where(m => m.LoginId == _empoyeeModel.LoginId && m.Password == _empoyeeModel.Pasword).FirstOrDefault();
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                return RedirectToAction("SuccessPage", "Home");
            }
            return View(_empoyeeModel);
        }
        public IActionResult SuccessPage()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
