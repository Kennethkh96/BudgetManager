using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Models;

namespace BudgetManager.Database.interfaces
{
    interface IDbContext
    {
        ICollection<Visibility> GetVisibiltys();
        ICollection<Interval> GetIntervals();

        int CreateBudget(Budget budget);
    }
}
