using EmployeeDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeDemo.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            return View("Index", _employees);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.ID = _employees.Count;
            return View(employeeViewModel);
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", employeeViewModel);
            }

            _employees.Add(employeeViewModel);

            return RedirectToAction("Index");
        }

        // GET: Employees/Edit
        public ActionResult Edit(int employeeID)
        {
            EmployeeViewModel employeeViewModel = _employees[employeeID];
            return View("Edit", employeeViewModel);
        }

        // POST: Employees/Edit
        [HttpPost]
        public ActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", employeeViewModel);
            }
                
            _employees[employeeViewModel.ID] = employeeViewModel;

            return RedirectToAction("Index");
        }

        private static List<EmployeeViewModel> _employees = new List<EmployeeViewModel>();
    }
}
