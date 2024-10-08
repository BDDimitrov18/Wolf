﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IDocumentPlot_DocumentOwnerRelashionshipModelRepository
    {
        public Task AddRelashionship(DocumentPlot_DocumentOwnerRelashionship relashionship);
        public Task<DocumentPlot_DocumentOwnerRelashionship> FindById(int id);

        public List<DocumentPlot_DocumentOwnerRelashionship> GetLinked(List<Plot> plots);

        public Task<bool> deleteRelashionship(DocumentPlot_DocumentOwnerRelashionship relashionship, DocumentPlot_DocumentOwnerRelashionship plotOwner);
        public Task<bool> EditRelashionship(DocumentPlot_DocumentOwnerRelashionship relashionship);
        public Task<List<DocumentPlot_DocumentOwnerRelashionship>> FetchLinkedRelashionships(Plot plot);
    }
}
