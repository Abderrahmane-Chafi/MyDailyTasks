using MyDailyTasks.DataAcess.Data;
using MyDailyTasks.DataAcess.Repository.IRepository;
using MyDailyTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDailyTasks.DataAcess.Repository
{
    public class TasksRepository : Repository<Tasks>, ITasksRepository
    {
        private ApplicationDbContext _db;
        public TasksRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Tasks obj)
        {
            var objFromDb = _db.Tasks.FirstOrDefault(u => u.ID == obj.ID);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Status = obj.Status;
                objFromDb.Date = obj.Date;

            }
        }
    }
}
