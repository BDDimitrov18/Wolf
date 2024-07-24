using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PlotModelRespository : IPlotModelRepository
    {

        private WolfDbContext _WolfDbContext { get; set; }

        public PlotModelRespository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }
        public async Task Add(Plot plot)
        {
            var existingPlot = await _WolfDbContext.Plots
        .FirstOrDefaultAsync(p => p.PlotNumber == plot.PlotNumber);

            if (existingPlot != null)
            {
                plot.PlotId = existingPlot.PlotId;
                plot.RegulatedPlotNumber = existingPlot.RegulatedPlotNumber;
                plot.neighborhood = existingPlot.neighborhood;
                plot.City = existingPlot.City;
                plot.Municipality = existingPlot.Municipality;
                plot.Street = existingPlot.Street;
                plot.StreetNumber = existingPlot.StreetNumber;
                plot.designation = existingPlot.designation;
                plot.locality = existingPlot.locality;
            }
            else
            {
                _WolfDbContext.Plots.Add(plot);
                await _WolfDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Plot>> GetLinkedPlotsToActivty(int activityId) {
            var activity = _WolfDbContext.Activities
                .Include(a => a.ActivityPlots)
                    .ThenInclude(ap => ap.Plot)
                .FirstOrDefault(a => a.ActivityId == activityId);

            if (activity == null)
            {
                // Handle the case where the activity is not found
                return new List<Plot>();
            }

            var plots = activity.ActivityPlots.Select(ap => ap.Plot).ToList();
            return plots;
        }

        public async Task<bool> EditPlot(Plot plot)
        {
            // Find the existing plot in the database
            var existingPlot = await _WolfDbContext.Plots.FirstOrDefaultAsync(p => p.PlotId == plot.PlotId);

            // If the plot is found, update its properties
            if (existingPlot != null)
            {
                existingPlot.PlotNumber = plot.PlotNumber;
                existingPlot.RegulatedPlotNumber = plot.RegulatedPlotNumber;
                existingPlot.neighborhood = plot.neighborhood;
                existingPlot.City = plot.City;
                existingPlot.Municipality = plot.Municipality;
                existingPlot.Street = plot.Street;
                existingPlot.StreetNumber = plot.StreetNumber;
                existingPlot.designation = plot.designation;
                existingPlot.locality = plot.locality;

                try
                {
                    // Save the changes to the database
                    await _WolfDbContext.SaveChangesAsync();
                    return true; // Indicate that the operation was successful
                }
                catch (Exception ex)
                {
                    // Log the exception (logging not shown here)
                    // Handle the exception as needed
                    return false; // Indicate that the operation failed
                }
            }
            else
            {
                return false; // Indicate that the plot was not found
            }
        }
    }
}
