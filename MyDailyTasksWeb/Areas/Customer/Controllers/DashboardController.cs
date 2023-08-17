using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyDailyTasks.DataAcess.Repository.IRepository;
using MyDailyTasks.Models;
using MyDailyTasks.Models.ViewModels;
using System.Security.Claims;

namespace MyDailyTasksWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            var claimsIDentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIDentity.FindFirst(ClaimTypes.NameIdentifier);

            DashboardVM dashboardVM = new()
            {
                TotalTasks = _unitOfWork.Tasks.GetAll(u => u.ApplicationUserId == claim.Value).Count(),
                CompletedTasks = _unitOfWork.Tasks.GetAll(u => u.ApplicationUserId == claim.Value && u.Status == "Done").Count(),
                UncompletedTasks = _unitOfWork.Tasks.GetAll(u => u.ApplicationUserId == claim.Value && u.Status == "Undone").Count(),
                LastThreeTasks = _unitOfWork.Tasks
                .GetAll(u => u.ApplicationUserId == claim.Value)
                .OrderByDescending(task => task.ID) // Assuming Id is the primary key or an auto-incrementing ID
                .Take(3)
                .ToList()


            };

            return View(dashboardVM);
        }
    }
}
