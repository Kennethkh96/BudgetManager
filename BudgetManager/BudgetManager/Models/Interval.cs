using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManager.Models
{
    public class Interval
    {
        public string IntervalTitle { get; set; }
        public int IntervalValue { get; set; }

        public Interval(string title, int value)
        {
            IntervalTitle = title;
            IntervalValue = value;
        }
    }
}