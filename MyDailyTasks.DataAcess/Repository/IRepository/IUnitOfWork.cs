using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDailyTasks.DataAcess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITasksRepository Tasks { get; }
        IApplicationUserRepository ApplicationUser { get; }
        void Save();
    }
}
