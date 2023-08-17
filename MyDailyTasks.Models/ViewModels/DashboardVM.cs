using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDailyTasks.Models.ViewModels
{
    public class DashboardVM
    {
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int UncompletedTasks { get; set; }
        [ValidateNever]
        public IEnumerable<Tasks> LastThreeTasks { get; set; }
    }
}
