using AngleSharp.Dom;
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
            if (baseNotification.OperationType == "Create")
            {
                if (baseNotification.EntityType == "List<GetRequestDTO>")
                {
                    RequestWithClientsDTO requestWithClientsDTO = new RequestWithClientsDTO();
                    requestWithClientsDTO.requestDTO = baseNotification.UpdatedEntity.Deserialize<List<GetRequestDTO>>()[0];
                    requestWithClientsDTO.clientDTOs = new List<GetClientDTO>();
                    requestWithClientsDTO.activityDTOs = new List<GetActivityDTO>();
                    compositeData._fetchedLinkedClients.Add(requestWithClientsDTO);
                }
                else if (baseNotification.EntityType == "List<GetClient_RequestRelashionshipDTO>")
                {
                    List<GetClient_RequestRelashionshipDTO> getClient_RequestRelashionshipDTOs = baseNotification.UpdatedEntity.Deserialize<List<GetClient_RequestRelashionshipDTO>>();
                    foreach (var link in compositeData._fetchedLinkedClients)
                    {
                        if (link.requestDTO.RequestId == getClient_RequestRelashionshipDTOs[0].RequestId)
                        {
                            foreach (var relashionship in getClient_RequestRelashionshipDTOs)
                            {
                                link.clientDTOs.Add(relashionship.Client);
                            }
                        }
                    }
                }
                else if (baseNotification.EntityType == "GetActivityDTO")
                {
                    GetActivityDTO activityDTO = baseNotification.UpdatedEntity.Deserialize<GetActivityDTO>();
                    bool replaced = false;
                    foreach (var link in compositeData._fetchedLinkedClients)
                    {
                        if (link.requestDTO.RequestId == activityDTO.RequestId)
                        {
                            for (int i = 0; i < link.activityDTOs.Count; i++)
                            {
                                if (link.activityDTOs[i].ActivityId == activityDTO.ActivityId)
                                {
                                    link.activityDTOs[i] = activityDTO;
                                    replaced = true;
                                }
                            }
                            if (!replaced)
                            {
                                link.activityDTOs.Add(activityDTO);
                            }
                        }
                    }
                }
                else if (baseNotification.EntityType == "GetActivity_Plot_OwnershipDTO")
                {
                    GetActivity_Plot_OwnershipDTO getActivity_Plot_OwnershipDTO = baseNotification.UpdatedEntity.Deserialize<GetActivity_Plot_OwnershipDTO>();

                    foreach (var link in compositeData._fetchedLinkedClients)
                    {
                        foreach (var activity in getActivity_Plot_OwnershipDTO.activity_PlotRelashionshipDTOs)
                        {
                            var existingActivity = link.activityDTOs.FirstOrDefault(opt => opt.ActivityId == activity.ActivityId);
                            if (existingActivity != null)
                            {
                                // Update the properties of the existing activity
                                existingActivity.RequestId = activity.Activity.RequestId;
                                existingActivity.Request = activity.Activity.Request;
                                existingActivity.ActivityTypeID = activity.Activity.ActivityTypeID;
                                existingActivity.ActivityType = activity.Activity.ActivityType;
                                existingActivity.ParentActivityId = activity.Activity.ParentActivityId;
                                existingActivity.ParentActivity = activity.Activity.ParentActivity;
                                existingActivity.ExpectedDuration = activity.Activity.ExpectedDuration;
                                existingActivity.StartDate = activity.Activity.StartDate;
                                existingActivity.employeePayment = activity.Activity.employeePayment;
                                existingActivity.ExecutantId = activity.Activity.ExecutantId;
                                existingActivity.mainExecutant = activity.Activity.mainExecutant;
                                existingActivity.Tasks = activity.Activity.Tasks;
                                existingActivity.Plots = activity.Activity.Plots;
                                // Add other properties as needed
                            }
                            else
                            {
                                link.activityDTOs.Add(activity.Activity);
                            }
                        }
                    }
                    compositeData.linkedDocuments.AddRange(getActivity_Plot_OwnershipDTO.getDocumentPlot_DocumentOwnerRelashionshipDTOs);
                }
                else if (baseNotification.EntityType == "GetDocumentPlot_DocumentOwnerRelashionshipDTO")
                {
                    GetDocumentPlot_DocumentOwnerRelashionshipDTO getDocumentPlot_DocumentOwnerRelashionshipDTO = baseNotification.UpdatedEntity.Deserialize<GetDocumentPlot_DocumentOwnerRelashionshipDTO>();
                    compositeData.linkedDocuments.Add(getDocumentPlot_DocumentOwnerRelashionshipDTO);
                }
                else if (baseNotification.EntityType == "List<GetEmployeeDTO>")
                {
                    List<GetEmployeeDTO> employeesDTO = baseNotification.UpdatedEntity.Deserialize<List<GetEmployeeDTO>>();
                    _employeeDTOs.AddRange(employeesDTO);
                }
                else if (baseNotification.EntityType == "List<GetClientDTO>")
                {
                    List<GetClientDTO> clientDTOs = baseNotification.UpdatedEntity.Deserialize<List<GetClientDTO>>();
                    _allClients.AddRange(clientDTOs);
                }
                else if (baseNotification.EntityType == "GetActivityTypeDTO")
                {
                    GetActivityTypeDTO activityTypeDTO = baseNotification.UpdatedEntity.Deserialize<GetActivityTypeDTO>();

                    var existingActivityType = _activityTypesDTOs.FirstOrDefault(at => at.ActivityTypeID == activityTypeDTO.ActivityTypeID);
                    if (existingActivityType != null)
                    {
                        // Update the properties of the existing activity type
                        existingActivityType.ActivityTypeName = activityTypeDTO.ActivityTypeName;
                        // Add other properties as needed
                    }
                    else { 
                        _activityTypesDTOs.Add(activityTypeDTO);
                    }
                }
            }
            else if (baseNotification.OperationType == "Delete")
            {
                if (baseNotification.EntityType == "List<GetRequestDTO>")
                {
                    List<GetRequestDTO> requestDTOs = baseNotification.UpdatedEntity.Deserialize<List<GetRequestDTO>>();
                    List<RequestWithClientsDTO> itemsToRemove = new List<RequestWithClientsDTO>();

                    foreach (var link in compositeData._fetchedLinkedClients)
                    {
                        if (requestDTOs.Any(opt => opt.RequestId == link.requestDTO.RequestId))
                        {
                            itemsToRemove.Add(link);
                        }
                    }

                    foreach (var item in itemsToRemove)
                    {
                        compositeData._fetchedLinkedClients.Remove(item);
                    }
                }
                else if (baseNotification.EntityType == "List<GetClient_RequestRelashionshipDTO>")
                {
                    List<GetClient_RequestRelashionshipDTO> getClient_RequestRelashionshipDTOs = baseNotification.UpdatedEntity.Deserialize<List<GetClient_RequestRelashionshipDTO>>();

                    foreach (var link in compositeData._fetchedLinkedClients)
                    {
                        if (link.requestDTO.RequestId == getClient_RequestRelashionshipDTOs[0].RequestId)
                        {
                            List<GetClientDTO> clientsToRemove = new List<GetClientDTO>();

                            foreach (var relashionship in getClient_RequestRelashionshipDTOs)
                            {
                                var clientToRemove = link.clientDTOs.FirstOrDefault(opt => opt.ClientId == relashionship.ClientId);
                                if (clientToRemove != null)
                                {
                                    clientsToRemove.Add(clientToRemove);
                                }
                            }

                            foreach (var client in clientsToRemove)
                            {
                                link.clientDTOs.Remove(client);
                            }
                        }
                    }
                }
                else if (baseNotification.EntityType == "List<GetTaskDTO>")
                {
                    List<GetTaskDTO> getTaskDTOs = baseNotification.UpdatedEntity.Deserialize<List<GetTaskDTO>>();

                    foreach (var link in compositeData._fetchedLinkedClients)
                    {
                        foreach (var activity in link.activityDTOs)
                        {
                            List<GetTaskDTO> tasksToRemove = new List<GetTaskDTO>();

                            foreach (var task in getTaskDTOs)
                            {
                                var taskToRemove = activity.Tasks.FirstOrDefault(opt => opt.TaskId == task.TaskId);
                                if (taskToRemove != null)
                                {
                                    tasksToRemove.Add(taskToRemove);
                                }
                            }

                            foreach (var task in tasksToRemove)
                            {
                                activity.Tasks.Remove(task);
                            }
                        }
                    }
                }
                else if (baseNotification.EntityType == "List<GetActivityDTO>")
                {
                    List<GetActivityDTO> activityDTOs = baseNotification.UpdatedEntity.Deserialize<List<GetActivityDTO>>();

                    foreach (var link in compositeData._fetchedLinkedClients)
                    {
                        List<GetActivityDTO> activitiesToRemove = new List<GetActivityDTO>();

                        foreach (var activity in activityDTOs)
                        {
                            var existingActivity = link.activityDTOs.FirstOrDefault(opt => opt.ActivityId == activity.ActivityId);
                            if (existingActivity != null)
                            {
                                activitiesToRemove.Add(existingActivity);
                            }
                        }

                        foreach (var activity in activitiesToRemove)
                        {
                            link.activityDTOs.Remove(activity);
                        }
                    }
                    cleanUnconnectedDocumentLinks();
                }
                else if (baseNotification.EntityType == "List<GetActivity_PlotRelashionshipDTO>")
                {
                    List<GetActivity_PlotRelashionshipDTO> getActivity_PlotRelashionshipDTOs = baseNotification.UpdatedEntity.Deserialize<List<GetActivity_PlotRelashionshipDTO>>();

                    foreach (var link in compositeData._fetchedLinkedClients)
                    {
                        foreach (var activity in link.activityDTOs)
                        {
                            List<GetPlotDTO> plotsToRemove = new List<GetPlotDTO>();

                            foreach (var relashionship in getActivity_PlotRelashionshipDTOs)
                            {
                                if (activity.ActivityId == relashionship.ActivityId)
                                {
                                    plotsToRemove.AddRange(activity.Plots.Where(opt => opt.PlotId == relashionship.PlotId).ToList());
                                }
                            }

                            foreach (var plot in plotsToRemove)
                            {
                                activity.Plots.Remove(plot);
                            }
                        }
                    }
                }
                else if (baseNotification.EntityType == "List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>")
                {
                    List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> getDocumentPlot_DocumentOwnerRelashionshipDTOs = baseNotification.UpdatedEntity.Deserialize<List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>>();

                    List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> documentsToRemove = new List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>();

                    foreach (var link in compositeData.linkedDocuments)
                    {
                        if (getDocumentPlot_DocumentOwnerRelashionshipDTOs.Any(opt => opt.Id == link.Id))
                        {
                            documentsToRemove.Add(link);
                        }
                    }

                    foreach (var document in documentsToRemove)
                    {
                        compositeData.linkedDocuments.Remove(document);
                    }
                }
            }
            else if (baseNotification.EntityType == "Edit") { 
                
            }
        }

    }
}
