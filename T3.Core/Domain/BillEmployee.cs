using System;
using System.Collections.Generic;
using System.Text;

namespace T3.Core.Domain
{
    public class BillEmployee
    {
        public int BillId { get; set; }
        public Bill Bill { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
