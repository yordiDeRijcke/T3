using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using T3.Core.Domain;

namespace T3.Web.Models
{
    public class BillCreateViewModel
    {
        #region Properties
        [Required (ErrorMessage = "{0} mag niet leeg zijn.")]
        [StringLength(50, ErrorMessage = "{0} mag niet meer dan 50 karakters bevatten.")]
        [Display(Name = "Klantnaam")]
        public string Client { get; set; }

        [StringLength(50, ErrorMessage = "{0} mag niet meer dan 150 karakters bevatten.")]
        public string Info { get; set; }

        [Required]
        public IList<Item> Items { get; set; }

        [Required]
        public IList<Employee> Employees { get; set; }
        #endregion
    }
}