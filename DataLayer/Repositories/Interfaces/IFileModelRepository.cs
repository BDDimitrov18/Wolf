using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IFileModelRepository
    {
        public Task CreateFile(Files file);

        public List<Files> GetAllFiles();

        public Task<Files> getFile(int id);
    }
}
