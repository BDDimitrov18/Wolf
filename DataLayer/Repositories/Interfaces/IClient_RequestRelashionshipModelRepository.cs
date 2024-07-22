using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IClient_RequestRelashionshipModelRepository
    {
        public List<Client_RequestRelashionship> Add(Request request, List<Client> clients);

        public Task<bool> OnRequestDeleteAsync(Request request);

        public Task<bool> OnDeleteClients(List<Client_RequestRelashionship> clients);

    }
}
