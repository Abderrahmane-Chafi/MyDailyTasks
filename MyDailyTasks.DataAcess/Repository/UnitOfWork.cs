using MyDailyTasks.DataAcess.Data;
using MyDailyTasks.DataAcess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDailyTasks.DataAcess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        
        public ITasksRepository Tasks { get; private set; }

        //public IApplicationUserRepository ApplicationUser { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Tasks = new TasksRepository(_db);
            //ApplicationUser = new ApplicationUserRepository(_db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
