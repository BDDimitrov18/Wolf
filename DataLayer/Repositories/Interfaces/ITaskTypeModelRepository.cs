﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface ITaskTypeModelRepository
    {
        public Task AddTaskTypes(List<TaskType> taskTypes);


    }
}
