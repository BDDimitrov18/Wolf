﻿using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class Activity_PlotRelashionshipModelRepository : IActivity_PlotRelashionshipModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public Activity_PlotRelashionshipModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public async Task Add(Activity_PlotRelashionship relashionship) {
            _WolfDbContext.Activity_PlotRelashionships.Add(relashionship);
            await _WolfDbContext.SaveChangesAsync();
        }

        public async Task<bool> OnActivityDeleteAsync(Activity activity, List<Activity_PlotRelashionship> deletedRelashionships)
        {
            try
            {
                // Find the Activity_PlotRelashionships that have the same ActivityId as the provided activity
                var activityPlotRelationshipsToDelete = await _WolfDbContext.Activity_PlotRelashionships
                    .Where(ap => ap.ActivityId == activity.ActivityId)
                    .ToListAsync();

                
                if (activityPlotRelationshipsToDelete.Any())
                {
                    deletedRelashionships = new List<Activity_PlotRelashionship>(activityPlotRelationshipsToDelete);
                    _WolfDbContext.Activity_PlotRelashionships.RemoveRange(activityPlotRelationshipsToDelete);
                    var affectedRows = await _WolfDbContext.SaveChangesAsync();

                    // Check if any rows were affected
                    return affectedRows > 0;
                }

                // If no activity plot relationships were found to delete, return true (indicating no work to do)
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (implementation depends on your logging framework)
                // Example: _logger.LogError(ex, "An error occurred while deleting activity plot relationships");

                // Return false to indicate failure
                return false;
            }
        }


        public async Task<bool> OnPlotRelashionshipRemove(Activity_PlotRelashionship relashionship)
        {
            try
            {
                
                if (relashionship != null)
                {
                    _WolfDbContext.Activity_PlotRelashionships.Remove(relashionship);
                    var affectedRows = await _WolfDbContext.SaveChangesAsync();

                    return true;
                }

                // If no activity plot relationships were found to delete, return true (indicating no work to do)
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }
    }
}
