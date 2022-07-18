using App.Infrastructure.Base;
using App.Infrastructure.Database;
using App.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories
{

    public interface ILogsGeneralRepository : IBaseRepository<LogsGeneral>
    {
        List<LogsGeneral> GetAllSinBase();
    }
    public class LogsGeneralRepository:BaseRepository<LogsGeneral>, ILogsGeneralRepository
    {
        public LogsGeneralRepository(DataContext database) : base(database)
        {

        }

        public List<LogsGeneral> GetAllSinBase() 
        {
            return _table.ToList();
        }
    }
}
