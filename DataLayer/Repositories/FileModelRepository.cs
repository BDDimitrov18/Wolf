using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class FileModelRepository : IFileModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public FileModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public async Task CreateFile(Files file) { 
            _WolfDbContext.files.Add(file);
            await _WolfDbContext.SaveChangesAsync();
        }
    }
}
