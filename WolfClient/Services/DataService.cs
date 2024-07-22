﻿using AngleSharp.Dom;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WolfClient.NewForms;
using WolfClient.Services.Interfaces;
using WolfClient.ViewModels;

namespace WolfClient.Services
{
    public class DataService : IDataService
    {

        private CompositeDataDTO compositeData { get; set; }
        private GetRequestDTO _selectedRequest { get; set; }

        private List<GetEmployeeDTO> _employeeDTOs { get; set; }

        private List<GetActivityTypeDTO> _activityTypesDTOs { get; set; }

        private List<EKTVIewModel> _ektViewModels { get; set; }

        public List<GetClientDTO> _selectedClients { get; set; }

        public List<ActivityViewModel> _selectedActivity { get; set; }

        public List<GetPlotDTO> _selectedPlotsRequestMenuService { get; set; }

        public List<OwnershipViewModel> _selectedOwnershipRequestMenu { get; set; }

        public List<GetClientDTO> _allClients { get; set; }

        public DataService()
        {
            compositeData = new CompositeDataDTO();
            compositeData._fetchedLinkedClients = new List<RequestWithClientsDTO>();
            compositeData.linkedDocuments = new List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>();
            _employeeDTOs = new List<GetEmployeeDTO>();
            _selectedClients = new List<GetClientDTO>();
            _allClients = new List<GetClientDTO>();
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
        public List<GetPlotDTO> GetAllPlots()
        {
            List<GetPlotDTO> plotDTOs = new List<GetPlotDTO>();

            foreach (var link in compositeData._fetchedLinkedClients)
            {
                if (link.activityDTOs?.Count() > 0)
                {
                    foreach (var activity in link.activityDTOs)
                    {
                        if (activity.Plots != null && activity.Plots.Count() > 0)
                        {
                            foreach (var plot in activity.Plots)
                            {
                                plotDTOs.Add(plot);
                            }
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

        private string ConvertFloatToFraction(float value)
        {
            // Tolerance for floating point comparison
            const double TOLERANCE = 1.0E-6;

            if (value == 0.0)
                return "0/1";

            int sign = Math.Sign(value);
            value = Math.Abs(value);

            int n = (int)Math.Floor(value);
            value -= n;

            if (value < TOLERANCE)
                return $"{sign * n}/1";

            if (1 - value < TOLERANCE)
                return $"{sign * (n + 1)}/1";

            int lower_numerator = 0;
            int lower_denominator = 1;
            int upper_numerator = 1;
            int upper_denominator = 1;

            while (true)
            {
                int middle_numerator = lower_numerator + upper_numerator;
                int middle_denominator = lower_denominator + upper_denominator;

                if (middle_denominator * (value + TOLERANCE) < middle_numerator)
                {
                    upper_numerator = middle_numerator;
                    upper_denominator = middle_denominator;
                }
                else if (middle_numerator < (value - TOLERANCE) * middle_denominator)
                {
                    lower_numerator = middle_numerator;
                    lower_denominator = middle_denominator;
                }
                else
                {
                    return $"{sign * (n * middle_denominator + middle_numerator)}/{middle_denominator}";
                }
            }
        }

        public List<OwnershipViewModel> GetOwnershipViewModels(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs)
        {
            // Initialize the dictionary
            var RelashionshipDictionary = new Dictionary<int, Dictionary<int, List<Dictionary<GetOwnerDTO, string>>>>();

            var plotDictionary = relashionshipDTOs
                .Select(r => r.DocumentPlot.Plot)
                .GroupBy(p => p.PlotId)
                .Select(g => g.First())
                .ToDictionary(p => p.PlotId);

            var documentDictionary = relashionshipDTOs
                .Select(r => r.DocumentPlot.documentOfOwnership)
                .GroupBy(d => d.DocumentId)
                .Select(g => g.First())
                .ToDictionary(d => d.DocumentId);

            foreach (var relashionship in relashionshipDTOs)
            {
                var plotId = relashionship.DocumentPlot.Plot.PlotId;
                var documentId = relashionship.DocumentPlot.documentOfOwnership.DocumentId;
                var owner = relashionship.DocumentOwner.Owner;
                var idealParts = relashionship.IdealParts;

                // Check if the plot is already in the dictionary
                if (!RelashionshipDictionary.ContainsKey(plotId))
                {
                    RelashionshipDictionary[plotId] = new Dictionary<int, List<Dictionary<GetOwnerDTO, string>>>();
                }

                // Check if the document is already in the dictionary for this plot
                if (!RelashionshipDictionary[plotId].ContainsKey(documentId))
                {
                    RelashionshipDictionary[plotId][documentId] = new List<Dictionary<GetOwnerDTO, string>>();
                }

                // Determine the string value for idealParts based on isDrob
                string idealPartsString = relashionship.isDrob ? ConvertFloatToFraction(idealParts) : idealParts.ToString();

                // Create a dictionary for the owner and ideal parts string
                var ownerWithIdealParts = new Dictionary<GetOwnerDTO, string> { { owner, idealPartsString } };

                // Add the owner and ideal parts string to the list for this document
                RelashionshipDictionary[plotId][documentId].Add(ownerWithIdealParts);
            }

            var ownershipViewModels = new List<OwnershipViewModel>();
            foreach (var plotEntry in RelashionshipDictionary)
            {
                bool isFirstEntryForPlot = true;
                foreach (var documentEntry in plotEntry.Value)
                {
                    foreach (var ownerWithIdealParts in documentEntry.Value)
                    {
                        foreach (var ownerEntry in ownerWithIdealParts)
                        {
                            var owner = ownerEntry.Key;
                            var idealPartsString = ownerEntry.Value;

                            // Extract PowerOfAttorneyNumber from the relationship DTO
                            var powerOfAttorneyNumber = relashionshipDTOs
                                .FirstOrDefault(r => r.DocumentPlot.Plot.PlotId == plotEntry.Key
                                                     && r.DocumentPlot.documentOfOwnership.DocumentId == documentEntry.Key
                                                     && r.DocumentOwner.OwnerID == owner.OwnerID)?.powerOfAttorneyDocumentDTO?.number;

                            // Extract PlotOwnerID from the relationship DTO
                            var plotOwnerID = relashionshipDTOs
                                .FirstOrDefault(r => r.DocumentPlot.Plot.PlotId == plotEntry.Key
                                                     && r.DocumentPlot.documentOfOwnership.DocumentId == documentEntry.Key
                                                     && r.DocumentOwner.OwnerID == owner.OwnerID)?.Id;

                            var ownershipViewModel = new OwnershipViewModel()
                            {
                                PlotNumber = isFirstEntryForPlot ? plotDictionary[plotEntry.Key].PlotNumber : string.Empty,
                                NumberTypeDocument = $"{documentDictionary[documentEntry.Key].NumberOfDocument} {documentDictionary[documentEntry.Key].TypeOfDocument}",
                                NumberTypeOwner = $"{owner.OwnerID} {owner.FirstName} {owner.MiddleName} {owner.LastName}",
                                EGN = owner.EGN,
                                Address = owner.Address,
                                IdealParts = idealPartsString,
                                PowerOfAttorneyNumber = powerOfAttorneyNumber,
                                PlotOwnerID = plotOwnerID ?? 0 // Default to 0 if null
                            };

                            ownershipViewModels.Add(ownershipViewModel);
                            isFirstEntryForPlot = false;
                        }
                    }
                }
            }

            return ownershipViewModels;
        }

        private void cleanUnconnectedDocumentLinks() {
            foreach (var link in compositeData._fetchedLinkedClients) {
                foreach (var activity in link.activityDTOs) {
                    foreach (var plot in activity.Plots) {
                        if (compositeData.linkedDocuments.Where(opt => opt.DocumentPlot.PlotId == plot.PlotId).ToList().Count() >0) {
                            var listToRemove = compositeData.linkedDocuments.Where(opt => opt.DocumentPlot.PlotId == plot.PlotId).ToList();
                            foreach (var item in listToRemove) {
                                compositeData.linkedDocuments.Remove(item);
                            }
                        }
                    }
                }
            }
        }
        public void HandleWebSocketMessage(string message)
        {
            var baseNotification = JsonSerializer.Deserialize<UpdateNotification<JsonElement>>(message);

            switch (baseNotification.OperationType)
            {
                case "Create":
                    HandleCreateOperation(baseNotification);
                    break;
                case "Delete":
                    HandleDeleteOperation(baseNotification);
                    break;
                case "Edit":
                    // Handle Edit operation if necessary
                    break;
            }
            WebSocketDataUpdate.OnDataUpdated();
        }

        private void HandleDeleteOperation(UpdateNotification<JsonElement> baseNotification)
        {
            switch (baseNotification.EntityType)
            {
                case "List<GetRequestDTO>":
                    HandleDeleteRequest(baseNotification);
                    break;
                case "List<GetClient_RequestRelashionshipDTO>":
                    HandleDeleteClientRelationship(baseNotification);
                    break;
                case "List<GetTaskDTO>":
                    HandleDeleteTasks(baseNotification);
                    break;
                case "List<GetActivityDTO>":
                    HandleDeleteActivities(baseNotification);
                    break;
                case "List<GetActivity_PlotRelashionshipDTO>":
                    HandleDeleteActivityPlotRelationship(baseNotification);
                    break;
                case "List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>":
                    HandleDeleteDocumentPlotOwnerRelationship(baseNotification);
                    break;
            }
        }

        private void HandleDeleteRequest(UpdateNotification<JsonElement> baseNotification)
        {
            var requestDTOs = baseNotification.UpdatedEntity.Deserialize<List<GetRequestDTO>>();
            var itemsToRemove = compositeData._fetchedLinkedClients
                .Where(link => requestDTOs.Any(opt => opt.RequestId == link.requestDTO.RequestId))
                .ToList();
            foreach (var item in itemsToRemove)
            {
                compositeData._fetchedLinkedClients.Remove(item);
                if (_selectedRequest != null && item.requestDTO.RequestId == _selectedRequest.RequestId)
                {
                    _selectedRequest = null;
                }
            }
            WebSocketDataUpdate.OnRequestsUpdated(requestDTOs);
        }

        private void HandleDeleteClientRelationship(UpdateNotification<JsonElement> baseNotification)
        {
            var getClient_RequestRelashionshipDTOs = baseNotification.UpdatedEntity.Deserialize<List<GetClient_RequestRelashionshipDTO>>();

            foreach (var link in compositeData._fetchedLinkedClients)
            {
                if (link.requestDTO.RequestId == getClient_RequestRelashionshipDTOs[0].RequestId)
                {
                    var clientsToRemove = link.clientDTOs
                        .Where(client => getClient_RequestRelashionshipDTOs.Any(r => r.ClientId == client.ClientId))
                        .ToList();

                    foreach (var client in clientsToRemove)
                    {
                        link.clientDTOs.Remove(client);
                    }
                }
            }
            WebSocketDataUpdate.OnClientRelationshipsUpdated(getClient_RequestRelashionshipDTOs);
        }

        private void HandleDeleteTasks(UpdateNotification<JsonElement> baseNotification)
        {
            var getTaskDTOs = baseNotification.UpdatedEntity.Deserialize<List<GetTaskDTO>>();

            foreach (var link in compositeData._fetchedLinkedClients)
            {
                foreach (var activity in link.activityDTOs)
                {
                    activity.Tasks = activity.Tasks
                        .Where(task => !getTaskDTOs.Any(t => t.TaskId == task.TaskId))
                        .ToList();
                }
            }
            WebSocketDataUpdate.OnTasksUpdated(getTaskDTOs);
        }

        private void HandleDeleteActivities(UpdateNotification<JsonElement> baseNotification)
        {
            var activityDTOs = baseNotification.UpdatedEntity.Deserialize<List<GetActivityDTO>>();
            foreach (var link in compositeData._fetchedLinkedClients)
            {
                link.activityDTOs.RemoveAll(activity => activityDTOs.Any(a => a.ActivityId == activity.ActivityId));
            }
            cleanUnconnectedDocumentLinks();
            WebSocketDataUpdate.OnActivitiesUpdated(activityDTOs);
        }

        private void HandleDeleteActivityPlotRelationship(UpdateNotification<JsonElement> baseNotification)
        {
            var getActivity_PlotRelashionshipDTOs = baseNotification.UpdatedEntity.Deserialize<List<GetActivity_PlotRelashionshipDTO>>();

            foreach (var link in compositeData._fetchedLinkedClients)
            {
                foreach (var activity in link.activityDTOs)
                {
                    activity.Plots = activity.Plots
                        .Where(plot => !getActivity_PlotRelashionshipDTOs.Any(r => r.PlotId == plot.PlotId))
                        .ToList();
                }
            }
            WebSocketDataUpdate.OnActivityPlotRelationshipsUpdated(getActivity_PlotRelashionshipDTOs);
        }

        private void HandleDeleteDocumentPlotOwnerRelationship(UpdateNotification<JsonElement> baseNotification)
        {
            var getDocumentPlot_DocumentOwnerRelashionshipDTOs = baseNotification.UpdatedEntity.Deserialize<List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>>();
            compositeData.linkedDocuments.RemoveAll(document => getDocumentPlot_DocumentOwnerRelashionshipDTOs.Any(d => d.Id == document.Id));
            WebSocketDataUpdate.OnDocumentPlotOwnerRelationshipsUpdated(getDocumentPlot_DocumentOwnerRelashionshipDTOs);
        }

        private void HandleCreateOperation(UpdateNotification<JsonElement> baseNotification)
        {
            switch (baseNotification.EntityType)
            {
                case "List<GetRequestDTO>":
                    HandleCreateRequest(baseNotification);
                    break;
                case "List<GetClient_RequestRelashionshipDTO>":
                    HandleCreateClientRelationship(baseNotification);
                    break;
                case "GetActivityDTO":
                    HandleCreateActivity(baseNotification);
                    break;
                case "GetActivity_Plot_OwnershipDTO":
                    HandleCreateActivityPlotOwnership(baseNotification);
                    break;
                case "GetDocumentPlot_DocumentOwnerRelashionshipDTO":
                    HandleCreateDocumentPlotOwnerRelationship(baseNotification);
                    break;
                case "List<GetEmployeeDTO>":
                    HandleCreateEmployees(baseNotification);
                    break;
                case "List<GetClientDTO>":
                    HandleCreateClients(baseNotification);
                    break;
                case "GetActivityTypeDTO":
                    HandleCreateActivityType(baseNotification);
                    break;
            }
        }

        private void HandleCreateRequest(UpdateNotification<JsonElement> baseNotification)
        {
            var requestWithClientsDTO = new RequestWithClientsDTO
            {
                requestDTO = baseNotification.UpdatedEntity.Deserialize<List<GetRequestDTO>>()[0],
                clientDTOs = new List<GetClientDTO>(),
                activityDTOs = new List<GetActivityDTO>()
            };
            compositeData._fetchedLinkedClients.Add(requestWithClientsDTO);
            WebSocketDataUpdate.OnRequestsUpdated(new List<GetRequestDTO> { requestWithClientsDTO.requestDTO });
        }

        private void HandleCreateClientRelationship(UpdateNotification<JsonElement> baseNotification)
        {
            var getClient_RequestRelashionshipDTOs = baseNotification.UpdatedEntity.Deserialize<List<GetClient_RequestRelashionshipDTO>>();
            foreach (var link in compositeData._fetchedLinkedClients)
            {
                if (link.requestDTO.RequestId == getClient_RequestRelashionshipDTOs[0].RequestId)
                {
                    link.clientDTOs.AddRange(getClient_RequestRelashionshipDTOs.Select(r => r.Client));
                }
            }
            WebSocketDataUpdate.OnClientRelationshipsUpdated(getClient_RequestRelashionshipDTOs);
        }

        private void HandleCreateActivity(UpdateNotification<JsonElement> baseNotification)
        {
            var activityDTO = baseNotification.UpdatedEntity.Deserialize<GetActivityDTO>();
            foreach (var link in compositeData._fetchedLinkedClients)
            {
                if (link.requestDTO.RequestId == activityDTO.RequestId)
                {
                    var existingActivity = link.activityDTOs.FirstOrDefault(a => a.ActivityId == activityDTO.ActivityId);
                    if (existingActivity != null)
                    {
                        link.activityDTOs[link.activityDTOs.IndexOf(existingActivity)] = activityDTO;
                    }
                    else
                    {
                        link.activityDTOs.Add(activityDTO);
                    }
                }
            }
            WebSocketDataUpdate.OnActivitiesUpdated(new List<GetActivityDTO> { activityDTO });
        }

        private void HandleCreateActivityPlotOwnership(UpdateNotification<JsonElement> baseNotification)
        {
            var getActivity_Plot_OwnershipDTO = baseNotification.UpdatedEntity.Deserialize<GetActivity_Plot_OwnershipDTO>();
            foreach (var link in compositeData._fetchedLinkedClients)
            {
                foreach (var activity in getActivity_Plot_OwnershipDTO.activity_PlotRelashionshipDTOs)
                {
                    var existingActivity = link.activityDTOs.FirstOrDefault(opt => opt.ActivityId == activity.ActivityId);
                    if (existingActivity != null)
                    {
                        existingActivity = activity.Activity;
                    }
                    else
                    {
                        link.activityDTOs.Add(activity.Activity);
                    }
                }
            }
            compositeData.linkedDocuments.AddRange(getActivity_Plot_OwnershipDTO.getDocumentPlot_DocumentOwnerRelashionshipDTOs);
            WebSocketDataUpdate.OnActivityPlotRelationshipsUpdated(getActivity_Plot_OwnershipDTO.activity_PlotRelashionshipDTOs);
            WebSocketDataUpdate.OnDocumentPlotOwnerRelationshipsUpdated(getActivity_Plot_OwnershipDTO.getDocumentPlot_DocumentOwnerRelashionshipDTOs);
        }

        private void HandleCreateDocumentPlotOwnerRelationship(UpdateNotification<JsonElement> baseNotification)
        {
            var getDocumentPlot_DocumentOwnerRelashionshipDTO = baseNotification.UpdatedEntity.Deserialize<GetDocumentPlot_DocumentOwnerRelashionshipDTO>();
            compositeData.linkedDocuments.Add(getDocumentPlot_DocumentOwnerRelashionshipDTO);
            WebSocketDataUpdate.OnDocumentPlotOwnerRelationshipsUpdated(new List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> { getDocumentPlot_DocumentOwnerRelashionshipDTO });
        }

        private void HandleCreateEmployees(UpdateNotification<JsonElement> baseNotification)
        {
            var employeesDTO = baseNotification.UpdatedEntity.Deserialize<List<GetEmployeeDTO>>();
            _employeeDTOs.AddRange(employeesDTO);
            WebSocketDataUpdate.OnEmployeesUpdated(employeesDTO);
        }

        private void HandleCreateClients(UpdateNotification<JsonElement> baseNotification)
        {
            var clientDTOs = baseNotification.UpdatedEntity.Deserialize<List<GetClientDTO>>();
            _allClients.AddRange(clientDTOs);
            WebSocketDataUpdate.OnClientsUpdated(clientDTOs);
        }

        private void HandleCreateActivityType(UpdateNotification<JsonElement> baseNotification)
        {
            var activityTypeDTO = baseNotification.UpdatedEntity.Deserialize<GetActivityTypeDTO>();
            var existingActivityType = _activityTypesDTOs.FirstOrDefault(at => at.ActivityTypeID == activityTypeDTO.ActivityTypeID);
            if (existingActivityType != null)
            {
                existingActivityType.ActivityTypeName = activityTypeDTO.ActivityTypeName;
            }
            else
            {
                _activityTypesDTOs.Add(activityTypeDTO);
            }
            WebSocketDataUpdate.OnActivityTypeUpdated(activityTypeDTO);
        }
    }
}
