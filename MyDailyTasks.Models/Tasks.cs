using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDailyTasks.Models
{
    public class Tasks
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
        public string Status { get; set; } 
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
