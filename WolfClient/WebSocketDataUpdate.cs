using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfClient
{
    public static class WebSocketDataUpdate
    {
        public static event Action DataUpdated;
        public static event Action<List<GetRequestDTO>> RequestsUpdated;
        public static event Action<List<GetClient_RequestRelashionshipDTO>> ClientRelationshipsUpdated;
        public static event Action<List<GetTaskDTO>> TasksUpdated;
        public static event Action<List<GetActivityDTO>> ActivitiesUpdated;
        public static event Action<List<GetActivity_PlotRelashionshipDTO>> ActivityPlotRelationshipsUpdated;
        public static event Action<List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>> DocumentPlotOwnerRelationshipsUpdated;
        public static event Action<GetActivityTypeDTO> ActivityTypeUpdated;
        public static event Action<List<GetEmployeeDTO>> EmployeesUpdated;
        public static event Action<List<GetClientDTO>> ClientsUpdated;

        public static void OnDataUpdated() => DataUpdated?.Invoke();
        public static void OnRequestsUpdated(List<GetRequestDTO> requests) => RequestsUpdated?.Invoke(requests);
        public static void OnClientRelationshipsUpdated(List<GetClient_RequestRelashionshipDTO> clientRelationships) => ClientRelationshipsUpdated?.Invoke(clientRelationships);
        public static void OnTasksUpdated(List<GetTaskDTO> tasks) => TasksUpdated?.Invoke(tasks);
        public static void OnActivitiesUpdated(List<GetActivityDTO> activities) => ActivitiesUpdated?.Invoke(activities);
        public static void OnActivityPlotRelationshipsUpdated(List<GetActivity_PlotRelashionshipDTO> activityPlotRelationships) => ActivityPlotRelationshipsUpdated?.Invoke(activityPlotRelationships);
        public static void OnDocumentPlotOwnerRelationshipsUpdated(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> documentPlotOwnerRelationships) => DocumentPlotOwnerRelationshipsUpdated?.Invoke(documentPlotOwnerRelationships);
        public static void OnActivityTypeUpdated(GetActivityTypeDTO activityType) => ActivityTypeUpdated?.Invoke(activityType);
        public static void OnEmployeesUpdated(List<GetEmployeeDTO> employees) => EmployeesUpdated?.Invoke(employees);
        public static void OnClientsUpdated(List<GetClientDTO> clients) => ClientsUpdated?.Invoke(clients);
    }
}
