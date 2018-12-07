using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using T3.Core.Repositories;

namespace T3.Web.Controllers
{
    [Authorize]
    public class BillController : Controller
    {
        #region Properties
        private readonly IBillRepository _billRepository;
        #endregion

        #region Constructor
        public BillController(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }
        #endregion

        public IActionResult Index()
        {
            return View(_billRepository.GetAllWithEI());
        }
    }
}
