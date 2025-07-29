using itemTracker.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskForTrackItem.Models.Models;

namespace itemTracker.BLL
{
    public class LogService
    {
        private readonly ItemLogRepository _logRepo = new ItemLogRepository();

        public List<ItemLog> GetAllLogs()
        {
            return _logRepo.GetLogs();
        }
    }
}
