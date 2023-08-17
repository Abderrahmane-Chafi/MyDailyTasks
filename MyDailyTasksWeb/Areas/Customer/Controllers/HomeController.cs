using Microsoft.AspNetCore.Mvc;
using MyDailyTasks.DataAcess.Repository.IRepository;
using MyDailyTasks.Models.ViewModels;
using MyDailyTasksWeb.Models;
using System.Diagnostics;

namespace MyDailyTasksWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            HomeVM homevm = new()
            {
                usersCount = _unitOfWork.ApplicationUser.GetAll().Count()
            };
            return View(homevm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}