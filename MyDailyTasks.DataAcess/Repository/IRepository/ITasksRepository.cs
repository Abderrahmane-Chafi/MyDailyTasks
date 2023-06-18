using MyDailyTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDailyTasks.DataAcess.Repository.IRepository
{
    public interface ITasksRepository:IRepository<Tasks>
    {
        void Update(Tasks obj);

    }
}
