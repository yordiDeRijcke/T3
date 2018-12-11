using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using T3.Core.Repositories;

namespace T3.Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        #region Properties
        private readonly IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructor
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            return View(_employeeRepository.GetAll());
        }

        public IActionResult GetEmployees()
        {
            return Json(_employeeRepository.GetAll());
        }
        #endregion
    }
}
