using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using MyDailyTasks.DataAcess.Repository;
using MyDailyTasks.DataAcess.Repository.IRepository;
using MyDailyTasks.Models;
using MyDailyTasks.Models.ViewModels;

namespace MyDailyTasksWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class TasksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TasksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? Id)
        {
            var Nt = new SelectListItem { Text = " Undone", Value = " Undone" };
            var d = new SelectListItem { Text = " Done", Value = " Done" };

            TasksViewModel taskVM = new()
            {
                Tasks = new(),
                TasksList = new SelectListItem[] { Nt, d }
            };
            if (Id == null || Id == 0)
            {
                return View(taskVM);
            }
            else
            {
                taskVM.Tasks = _unitOfWork.Tasks.GetFirstOrDefault(u => u.ID == Id);
                return View(taskVM);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TasksViewModel obj)
        {

            if (ModelState.IsValid)
            {
                if (obj.Tasks.ID == 0)
                {
                    _unitOfWork.Tasks.Add(obj.Tasks);
                    TempData["success"] = "Task created successfully";
                }
                else
                {
                    _unitOfWork.Tasks.Update(obj.Tasks);
                    TempData["success"] = "Task updated successfully";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll(string filter)
        {
            IEnumerable<Tasks> tasksList = _unitOfWork.Tasks.GetAll();

            switch (filter) {
                case "Done":
                    tasksList=tasksList.Where(u => u.Status == "Done");
                    break;
                case "Undone":
                    tasksList=tasksList.Where(u => u.Status == "Undone");
                    break;
                default:
                    break;
            }
            return Json(new { data = tasksList });
        }
        //POST
        [HttpDelete]
        public IActionResult Delete(int? Id)
        {
            var Obj = _unitOfWork.Tasks.GetFirstOrDefault(u => u.ID == Id);
            if (Obj == null)
            {
                return Json(new { success = false, message = "Error when deleting" });
            }

            _unitOfWork.Tasks.Remove(Obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleting successfully" });

        }
        #endregion
    }
}
