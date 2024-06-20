using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RequestModelRepository : IRequestModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public RequestModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public void Add(List<Request> requests)
        {
            foreach (var request in requests)
            {
                _WolfDbContext.Requests.Add(request);
                _WolfDbContext.SaveChanges();
            }
        }

        public IEnumerable<Request> GetAll()
        {
            return _WolfDbContext.Requests.ToList();
        }
    }
}
