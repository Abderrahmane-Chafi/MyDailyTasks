using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyDailyTasks.DataAcess.Repository.IRepository;
using MyDailyTasks.Models;

namespace MyDailyTasksWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminDataController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminDataController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS
        public IActionResult GetAll() {
            IEnumerable<ApplicationUser> users = _unitOfWork.ApplicationUser.GetAll();
            return Json(new { data = users });
        }
        #endregion
    }
}
