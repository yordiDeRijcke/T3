using System;
using System.Collections.Generic;
using T3.Core.Domain;

namespace T3.Web.Models
{
    public class BillIndexViewModel
    {
        #region Properties
        public List<Bill> Bills { get; set; }
        public List<Employee> Employees { get; set; }
        #endregion
    }
}
