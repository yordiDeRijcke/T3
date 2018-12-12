﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using T3.Core.Repositories;
using T3.Web.Models;

namespace T3.Web.Controllers
{
    [Authorize]
    public class BillController : Controller
    {
        #region Properties
        private readonly IBillRepository _billRepository;
        private readonly IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructor
        public BillController(IBillRepository billRepository, IEmployeeRepository employeeRepository)
        {
            _billRepository = billRepository;
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            BillIndexViewModel bivm = new BillIndexViewModel
            {
                Bills = _billRepository.GetAllWithEmployees(),
                Employees = _employeeRepository.GetAll()
            };

            return View(bivm);
        }
        #endregion
    }
}
