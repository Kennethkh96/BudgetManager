using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetManager.Models
{
    public class Budget
    {
        [Required(ErrorMessage = "Purpose is required")]
        [StringLength(100, ErrorMessage = "Purpose has a max length of 100 characters")]
        public string Purpose { get; set; }

        [DisplayName("Accounting year")]
        [Required(ErrorMessage = "Accounting year is required")]
        [Range(0000, 9999, ErrorMessage = "Must be a year")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Must be 4 digits")]
        public string AccountingYear { get; set; }

        [DisplayName("Budget title")]
        [Required(ErrorMessage = "Budget title is required")]
        [StringLength(100, ErrorMessage = "Budget title has a max length of 100 characters")]
        public string BudgetTitle { get; set; }

        [DisplayName("Visibilty")]
        [Required(ErrorMessage = "Visibility is required")]
        public int FK_VisibilityId { get; set; }

        [DisplayName("Interval")]
        [Required(ErrorMessage = "Interval is required")]
        public string FK_IntervalTitle { get; set; }

    }
}