﻿using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IPlotService
    {
        public Task<GetPlotDTO> CreatePlot(CreatePlotDTO plot);
    }
}