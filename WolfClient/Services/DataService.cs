using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WolfClient.Services.Interfaces;
using WolfClient.ViewModels;

namespace WolfClient.Services
{
    public class DataService : IDataService
    {

        private CompositeDataDTO compositeData { get; set; }
        private GetRequestDTO _selectedRequest { get; set; }
        private List<GetClientDTO> _clientDTOs { get; set; }

        private List<GetEmployeeDTO> _employeeDTOs { get; set; }

        private List<GetActivityTypeDTO> _activityTypesDTOs { get; set; }

        private List<EKTVIewModel> _ektViewModels { get; set; }

        public List<GetClientDTO> _selectedClients { get; set; }

        public List<ActivityViewModel> _selectedActivity { get; set; }

        public List<GetPlotDTO> _selectedPlotsRequestMenuService { get; set; }

        public List<OwnershipViewModel> _selectedOwnershipRequestMenu { get; set; }

        public DataService()
        {
            compositeData = new CompositeDataDTO();
            compositeData._fetchedLinkedClients = new List<RequestWithClientsDTO>();
            compositeData.linkedDocuments = new List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>();
            _clientDTOs = new List<GetClientDTO>();
            _employeeDTOs = new List<GetEmployeeDTO>();
            _selectedClients = new List<GetClientDTO>();
            _selectedActivity = new List<ActivityViewModel>();
        }

        public void SetSelectedClients(List<GetClientDTO> getClients)
        {
            _selectedClients = getClients;
        }

        public List<GetTaskDTO> getTasksFromViewModel() {
            List<GetTaskDTO> tasks = new List<GetTaskDTO>();
            foreach (var link in compositeData._fetchedLinkedClients) { 
                if(link.requestDTO.RequestId == _selectedRequest.RequestId) {
                    foreach (var activity in link.activityDTOs) {
                        foreach (var selectedActivity in _selectedActivity) {
                            if (activity.ActivityId == selectedActivity.ActivityId) {
                                foreach (var task in activity.Tasks) {
                                    if (task.TaskId == selectedActivity.TaskId)
                                    {
                                        tasks.Add(task);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return tasks;
        }

        private void removeCertainTask() { 
            
        }
        public List<GetActivityDTO> OnTasksDelete(List<GetTaskDTO> taskDTOs)
        {
            List<GetActivityDTO> activityDTOs = new List<GetActivityDTO>();

            foreach (var link in compositeData._fetchedLinkedClients)
            {
                if (link.requestDTO.RequestId == _selectedRequest.RequestId)
                {
                    foreach (var activity in link.activityDTOs)
                    {
                        List<GetTaskDTO> tasksToRemove = new List<GetTaskDTO>();

                        foreach (var task in activity.Tasks)
                        {
                            foreach (var taskDTO in taskDTOs)
                            {
                                if (task.TaskId == taskDTO.TaskId)
                                {
                                    tasksToRemove.Add(task);
                                }
                            }
                        }

                        foreach (var task in tasksToRemove)
                        {
                            activity.Tasks.Remove(task);
                        }

                        if (activity.Tasks.Count == 0)
                        {
                            activity.Tasks = null;
                            activityDTOs.Add(activity);
                        }
                    }
                }
            }

            return activityDTOs;
        }

        public void DeleteActivities(List<GetActivityDTO> activityDTOs)
        {
            foreach (var link in compositeData._fetchedLinkedClients)
            {
                if (link.requestDTO.RequestId == _selectedRequest.RequestId)
                {
                    // Create a list to hold the activities to be removed
                    var activitiesToRemove = new List<GetActivityDTO>();

                    // Iterate over the activities and collect the ones to be removed
                    foreach (var activity in link.activityDTOs)
                    {
                        foreach (var activityDto in activityDTOs)
                        {
                            if (activity.ActivityId == activityDto.ActivityId)
                            {
                                activitiesToRemove.Add(activity);
                                break;
                            }
                        }
                    }

                    // Remove the collected activities from the original list
                    foreach (var activityToRemove in activitiesToRemove)
                    {
                        link.activityDTOs.Remove(activityToRemove);
                    }
                }
            }
        }

        public List<GetClientDTO> getSelectedCLients() {
            return _selectedClients;
        }

        public List<GetClientDTO> getLinkedClients() { 
            foreach(var link in compositeData._fetchedLinkedClients) {
                if (link.requestDTO.RequestId == _selectedRequest.RequestId) {
                    return link.clientDTOs;
                }    
            }
            return null;
        }

        public void addPlotOwnerRelashionship(GetDocumentPlot_DocumentOwnerRelashionshipDTO relashionshipDTO) {
            compositeData.linkedDocuments.Add(relashionshipDTO);
        }

        public void setPlotOwnersRelashionships(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipsDTO) {
            compositeData.linkedDocuments = relashionshipsDTO;
        }
        public List<EKTVIewModel> GetEKTViewModels() {
            return _ektViewModels;
        }

        public void SetEKTViewModels(List<EKTVIewModel> listEKT) {
            _ektViewModels = listEKT;
        }

        public void SetFetchedLinkedRequests(List<RequestWithClientsDTO> linkedRequests) {
            compositeData._fetchedLinkedClients = linkedRequests;
        }

        public List<RequestWithClientsDTO> GetFetchedLinkedRequests() {
            return compositeData._fetchedLinkedClients;
        }

        public void AddSingleRequest(RequestWithClientsDTO linkedRequest) {
            compositeData._fetchedLinkedClients.Add(linkedRequest);
        }

        public void AddMultipleRequests(List<RequestWithClientsDTO> linkedRequests) {
            compositeData._fetchedLinkedClients.AddRange(linkedRequests);
        }

        public void SetActivityTypes(List<GetActivityTypeDTO> activityTypeDTOs)
        {
            _activityTypesDTOs = activityTypeDTOs;
        }

        public List<GetActivityTypeDTO> GetActivityTypeDTOs() {
            return _activityTypesDTOs;
        }

        public List<GetEmployeeDTO> GetEmployees() {
            return _employeeDTOs;
        }

        public void SetEmployees(List<GetEmployeeDTO> employees) {
            _employeeDTOs = employees;
        }

        public void AddSingleEmployee(GetEmployeeDTO employeeDTO) {
            _employeeDTOs.Add(employeeDTO);
        }

        public void AddMultipleEmployees(List<GetEmployeeDTO> employeeDTOs) {
            _employeeDTOs.AddRange(employeeDTOs);
        }

        public void SetSelectedRequest(GetRequestDTO getRequestDTO) {
            _selectedRequest = getRequestDTO;
        }

        public GetRequestDTO GetSelectedRequest()
        {
            return _selectedRequest;
        }

        public void AddActivityToTheList(GetActivityDTO activityDTO) {
            var ChosenLink = compositeData._fetchedLinkedClients.Where(opt => opt.requestDTO.RequestId == _selectedRequest.RequestId).FirstOrDefault();
            if (ChosenLink.activityDTOs?.Count() > 0)
            {
                ChosenLink.activityDTOs.Add(activityDTO);
            }
            else { 
                ChosenLink.activityDTOs = new List<GetActivityDTO> { activityDTO };
            }
        }

        public void OnClientsRequestDelete() {
            foreach(var link in compositeData._fetchedLinkedClients) {
                if (link.requestDTO.RequestId == _selectedRequest.RequestId)
                {
                    foreach (var client in _selectedClients)
                    {
                        link.clientDTOs.Remove(client);
                    }
                }
            }
        }
        public void ReplaceActivity(GetActivityDTO activityDTO) {
            var ChosenLink = compositeData._fetchedLinkedClients.Where(opt => opt.requestDTO.RequestId == _selectedRequest.RequestId).FirstOrDefault();
            int br = 0;
            foreach (GetActivityDTO link in ChosenLink.activityDTOs)
            {
                if (link.ActivityId == activityDTO.ActivityId) {
                    ChosenLink.activityDTOs[br] = activityDTO;
                    break;
                }
                br++;
            }
        }
        public RequestWithClientsDTO GetSelectedLinkedRequest()
        {
            foreach (var link in compositeData._fetchedLinkedClients) {
                if (link.requestDTO.RequestId == _selectedRequest.RequestId) {
                    return link;
                }
            }
            return null;
        }

        public List<GetPlotDTO> GetSelectedPlots()
        {
            List<GetPlotDTO> plotDTOs = new List<GetPlotDTO>();
            var selected = GetSelectedLinkedRequest();
            if (selected.activityDTOs?.Count() > 0)
            {
                foreach (var activity in selected.activityDTOs)
                {
                    if (activity.Plots.Count() > 0)
                    {
                        foreach (var plot in activity.Plots)
                        {
                            if (!plotDTOs.Any(p => p.PlotId == plot.PlotId))
                            {
                                plotDTOs.Add(plot);
                            }
                        }
                    }
                }
            }
            return plotDTOs;
        }

        public List<GetPlotDTO> GetSelectedPlotsFilterActivity(GetActivityDTO activityDTO)
        {
            List<GetPlotDTO> plotDTOs = new List<GetPlotDTO>();
            var selected = GetSelectedLinkedRequest();
            if (selected.activityDTOs?.Count() > 0)
            {
                foreach (var activity in selected.activityDTOs)
                {
                    if (activity.ActivityId == activityDTO.ActivityId)
                    {
                        if (activity.Plots.Count() > 0)
                        {
                            foreach (var plot in activity.Plots)
                            {
                                if (!plotDTOs.Any(p => p.PlotId == plot.PlotId))
                                {
                                    plotDTOs.Add(plot);
                                }
                            }
                        }
                    }
                }
            }
            return plotDTOs;
        }
        public List<GetPlotDTO> GetAllPlots(){
            List<GetPlotDTO> plotDTOs = new List<GetPlotDTO>();
            foreach (var link in compositeData._fetchedLinkedClients) { 
                if(link.activityDTOs?.Count() > 0)
                foreach(var activity in link.activityDTOs)
                {
                        if (activity.Plots.Count() > 0)
                        {
                            foreach (var plot in activity.Plots)
                            {
                                plotDTOs.Add(plot);
                            }
                        }
                }
            }
            return plotDTOs;
        }

        public List<GetDocumentOfOwnershipDTO> getAllDocuments()
        {
            List<GetDocumentOfOwnershipDTO> documents = new List<GetDocumentOfOwnershipDTO>();
            foreach (var relashionship in compositeData.linkedDocuments) {
                if (!documents.Contains(relashionship.DocumentPlot.documentOfOwnership)) {
                    documents.Add(relashionship.DocumentPlot.documentOfOwnership);
                }
            }
            return documents;
        }   

        public List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> GetLinkedPlotOwnerRelashionships()
        {
            List<GetPlotDTO> selectedPlots = GetSelectedPlots();
            List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs = new List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>();
            var selectedPlotIds = selectedPlots.Select(p => p.PlotId).ToHashSet();
            foreach (var relashionship in compositeData.linkedDocuments)
            {
                if (selectedPlotIds.Contains(relashionship.DocumentPlot.Plot.PlotId))
                {
                    relashionshipDTOs.Add(relashionship);
                }
            }
            return relashionshipDTOs;
        }

        public List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> GetLinkedPlotOwnerRelashionshipsFilterActivity(GetActivityDTO activityDTO)
        {
            List<GetPlotDTO> selectedPlots = GetSelectedPlotsFilterActivity(activityDTO);
            List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs = new List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>();
            var selectedPlotIds = selectedPlots.Select(p => p.PlotId).ToHashSet();
            foreach (var relashionship in compositeData.linkedDocuments)
            {
                if (selectedPlotIds.Contains(relashionship.DocumentPlot.Plot.PlotId))
                {
                    relashionshipDTOs.Add(relashionship);
                }
            }
            return relashionshipDTOs;
        }
        public List<GetDocumentOfOwnershipDTO> GetDocumentsFromPlots(GetPlotDTO plot) {
            List<GetDocumentOfOwnershipDTO> documentOfOwnershipDTOs = new List<GetDocumentOfOwnershipDTO>();
            foreach (var relashionship in compositeData.linkedDocuments) {
                if (relashionship.DocumentPlot.PlotId == plot.PlotId) {
                    documentOfOwnershipDTOs.Add(relashionship.DocumentPlot.documentOfOwnership); 
                }
            }
            return documentOfOwnershipDTOs;
        }

        public List<GetPowerOfAttorneyDocumentDTO> GetPowerOfAttorneyFromPlots(GetPlotDTO plot) {
            List<GetPowerOfAttorneyDocumentDTO> powerOfAttorneyDocumentDTOs = new List<GetPowerOfAttorneyDocumentDTO>();
            foreach (var plotOwner in compositeData.linkedDocuments) {
                if (plotOwner.DocumentPlot.Plot.PlotId == plot.PlotId) {
                    powerOfAttorneyDocumentDTOs.Add(plotOwner.powerOfAttorneyDocumentDTO);
                }
            }
            return powerOfAttorneyDocumentDTOs;
        }

        public void OnRequestDelete() { 
           foreach(var link in compositeData._fetchedLinkedClients) {
                if (link.requestDTO.RequestId == _selectedRequest.RequestId) {
                    compositeData._fetchedLinkedClients.Remove(link);
                    break;
                }     
           }
        }

        public List<GetRequestDTO> getRequests()
        {
            List<GetRequestDTO> requestDTOs = new List<GetRequestDTO>();
            foreach (var link in compositeData._fetchedLinkedClients) {
                requestDTOs.Add(link.requestDTO);
            }
            return requestDTOs;
        }

        public void SetSelectedActivityViews(List<ActivityViewModel> activityViewModels) { 
            _selectedActivity = activityViewModels;
        }

        public void SetSelectedPlotsOnRequestMenu(List<GetPlotDTO> plots)
        {
            _selectedPlotsRequestMenuService = plots;
        }

        public List<GetActivity_PlotRelashionshipDTO> getActivity_PlotRelashionshipDTOs(List<GetPlotDTO> plots) {
            List<GetActivity_PlotRelashionshipDTO> relashionshipDTOs = new List<GetActivity_PlotRelashionshipDTO>();
            foreach (var plot in plots) {
                foreach (var link in compositeData._fetchedLinkedClients)
                {
                    if (link.activityDTOs?.Count() > 0)
                        foreach (var activity in link.activityDTOs)
                        {
                            foreach (var activityPlot in activity.Plots)
                            {
                                if (activityPlot.PlotId == plot.PlotId) { 
                                    GetActivity_PlotRelashionshipDTO getActivity_PlotRelashionshipDTO = new GetActivity_PlotRelashionshipDTO() { 
                                        ActivityId = activity.ActivityId,
                                        PlotId = plot.PlotId,
                                    };
                                    relashionshipDTOs.Add(getActivity_PlotRelashionshipDTO);
                                    break;
                                }
                            }
                        }
                }
            }
            return relashionshipDTOs;
        }

        public List<GetPlotDTO> getSelectedPlotsOnRequestMenu() {
            return _selectedPlotsRequestMenuService;
        }

        public void RemovePlots(List<GetPlotDTO> plots)
        {
            // Check if the plots list is null before proceeding
            if (plots == null)
            {
                throw new ArgumentNullException(nameof(plots), "The list of plots cannot be null.");
            }

            foreach (var link in compositeData._fetchedLinkedClients)
            {
                if (link.requestDTO.RequestId == _selectedRequest.RequestId)
                {
                    if (link.activityDTOs.Count > 0)
                    {
                        foreach (var activity in link.activityDTOs)
                        {
                            if (activity.Plots.Count > 0)
                            {
                                // Create a list to store plots that need to be removed
                                var plotsToRemove = new List<GetPlotDTO>();

                                foreach (var plotDto in activity.Plots)
                                {
                                    // Check if the current plotDto and its PlotId are not null
                                    if (plotDto != null && plotDto.PlotId != null)
                                    {
                                        // Check if the current plotId matches any plotId in the plots list
                                        if (plots.Any(p => p != null && p.PlotId == plotDto.PlotId))
                                        {
                                            plotsToRemove.Add(plotDto);
                                        }
                                    }
                                }

                                // Remove the plots that are in the plotsToRemove list
                                foreach (var plotToRemove in plotsToRemove)
                                {
                                    activity.Plots.Remove(plotToRemove);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void SetSelectedOwnershipViewModelsRequestMenu(List<OwnershipViewModel> ownershipViewModels) {
            _selectedOwnershipRequestMenu = ownershipViewModels;
        }

        public List<OwnershipViewModel> GetSelectedOwnershipViewModelsRequestMenu() {
            return _selectedOwnershipRequestMenu;
        }

        public void RemovePlotOwnerRelashionships(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs) {
            foreach (var relashionship in relashionshipDTOs) {
                compositeData.linkedDocuments.Remove(relashionship);
            }
        }

        public GetDocumentPlot_DocumentOwnerRelashionshipDTO GetPlotOwnerById(int id) {
            foreach (var relashionship in compositeData.linkedDocuments) {
                if (relashionship.Id == id) {
                    return relashionship;
                }
            }
            return null;
        }

        public List<GetPowerOfAttorneyDocumentDTO> GetAllPowerOfAttorneys() {
            List<GetPowerOfAttorneyDocumentDTO> getPowerOfAttorneyDocuments = new List<GetPowerOfAttorneyDocumentDTO>();
            foreach (var relashionship in compositeData.linkedDocuments)
            {
                if (!getPowerOfAttorneyDocuments.Contains(relashionship.powerOfAttorneyDocumentDTO))
                {
                    getPowerOfAttorneyDocuments.Add(relashionship.powerOfAttorneyDocumentDTO);
                }
            }
            return getPowerOfAttorneyDocuments;
        }

        public List<GetActivityDTO> GetSelectedActivities() {
            foreach (var link in compositeData._fetchedLinkedClients) {
                if (link.requestDTO.RequestId == _selectedRequest.RequestId) {
                    var activities = link.activityDTOs;
                    return activities;
                }
            }
            return null;
        }
    }
}
