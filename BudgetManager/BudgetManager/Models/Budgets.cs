using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManager.Models
{
    public class Budgets
    {
        public string Purpose { get; set; }
        public string AccountingYear { get; set; }
        public string BudgetTitle { get; set; }
        public int FK_VisibilityId { get; set; }
        public string FK_IntervalTitle { get; set; }

    }
}