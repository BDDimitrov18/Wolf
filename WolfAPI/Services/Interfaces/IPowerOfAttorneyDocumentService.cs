﻿using DataAccessLayer.Models;
using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IPowerOfAttorneyDocumentService
    {
        public Task<GetPowerOfAttorneyDocumentDTO> createPowerOfAttorneyDocument(CreatePowerOfAttorneyDocumentDTO powerOfAttorneyDocumentDTO);
    }
}