using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IActivityModelRespository
    {
        public Task CreateActivity(Activity activity);
        public List<DataAccessLayer.Models.Activity> FindLinkedActivity(Request request);

        public Task<Activity> GetActivity(int id);
    }
}
