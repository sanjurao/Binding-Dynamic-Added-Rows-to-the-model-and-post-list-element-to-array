using EmployeeDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeDemo.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            return View("Index", _customer);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.ID = _customer.Count;
            return View(customerViewModel);
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", customerViewModel);
            }

            _customer.Add(customerViewModel);

            return RedirectToAction("Index");
        }

        // GET: Employees/Edit
        public ActionResult Edit(int employeeID)
        {
            CustomerViewModel customerViewModel = _customer[employeeID];
            return View("Edit", customerViewModel);
        }

        // POST: Employees/Edit
        [HttpPost]
        public ActionResult Edit(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", customerViewModel);
            }
                
            _customer[customerViewModel.ID] = customerViewModel;

            return RedirectToAction("Index");
        }

        private static List<CustomerViewModel> _customer = new List<CustomerViewModel>();
    }
}
