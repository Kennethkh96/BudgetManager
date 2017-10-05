using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManager.Models
{
    public class Visibility
    {
        public int Id { get; private set; }
        public string VisibilityTitle { get; set; }
        public string Description { get; set; }

        public Visibility(string title, string desc, int id)
        {
            VisibilityTitle = title;
            Description = desc;
            Id = id;
        }
    }
}