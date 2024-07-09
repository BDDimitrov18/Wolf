﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface ItaskModelRepository
    {
        public Task createTask(WorkTask task);

        public Task<bool> DeleteOnActivityAsync(Activity activity);

        public Task<bool> DeleteTasks(List<WorkTask> tasks);
    }
}
