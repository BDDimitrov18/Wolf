using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfClient.Services.Interfaces
{
    public interface IAdminClient
    {
        public void SetToken(string token);

        public Task AddEmployee(CreateEmployeeDTO employee);
    }

   
}
