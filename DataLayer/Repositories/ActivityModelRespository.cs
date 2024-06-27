using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ActivityModelRespository : IActivityModelRespository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public ActivityModelRespository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public async Task CreateActivity(Models.Activity activity)
        {
            _WolfDbContext.Activities.Add(activity);
            await _WolfDbContext.SaveChangesAsync();
        }

        public  List<DataAccessLayer.Models.Activity> FindLinkedActivity(Request request) { 
            return  _WolfDbContext.Activities.Where(opt => opt.RequestId == request.RequestId).ToList();
        }
    }
}
