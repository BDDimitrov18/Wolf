﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IPowerOfAttorneyModelRepository
    {
        public Task CreatePowerOfAttorney(PowerOfAttorneyDocument powerOfattorney);
        public Task<bool> EditPowerOfAttorney(PowerOfAttorneyDocument powerOfAttorneyDocument);
    }
}
