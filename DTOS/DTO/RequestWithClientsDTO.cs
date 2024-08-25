using DTOS.DTO;

public class RequestWithClientsDTO
{
    public GetRequestDTO requestDTO { get; set; }
    public List<GetClientDTO>? clientDTOs { get; set; }
    public List<GetActivityDTO>? activityDTOs { get; set; }
    public List<GetInvoiceDTO>? invoiceDTOs { get; set; }

    public RequestWithClientsDTO Copy()
    {
        return new RequestWithClientsDTO
        {
            requestDTO = this.requestDTO != null ? new GetRequestDTO
            {
                RequestId = this.requestDTO.RequestId,
                Price = this.requestDTO.Price,
                PaymentStatus = this.requestDTO.PaymentStatus,
                Advance = this.requestDTO.Advance,
                Comments = this.requestDTO.Comments,
                RequestName = this.requestDTO.RequestName,
                Path = this.requestDTO.Path
            } : null,

            clientDTOs = this.clientDTOs?.Select(client => new GetClientDTO
            {
                ClientId = client.ClientId,
                FirstName = client.FirstName,
                MiddleName = client.MiddleName,
                LastName = client.LastName,
                Phone = client.Phone,
                Email = client.Email,
                Address = client.Address,
                ClientLegalType = client.ClientLegalType
            }).ToList(),

            activityDTOs = this.activityDTOs?.Select(activity => new GetActivityDTO
            {
                ActivityId = activity.ActivityId,
                RequestId = activity.RequestId,
                Request = activity.Request != null ? new GetRequestDTO
                {
                    RequestId = activity.Request.RequestId,
                    Price = activity.Request.Price,
                    PaymentStatus = activity.Request.PaymentStatus,
                    Advance = activity.Request.Advance,
                    Comments = activity.Request.Comments,
                    RequestName = activity.Request.RequestName
                } : null,
                ActivityTypeID = activity.ActivityTypeID,
                ActivityType = activity.ActivityType != null ? new GetActivityTypeDTO
                {
                    ActivityTypeID = activity.ActivityType.ActivityTypeID,
                    ActivityTypeName = activity.ActivityType.ActivityTypeName,
                    TaskTypes = activity.ActivityType.TaskTypes?.Select(taskType => new GetTaskTypeDTO
                    {
                        TaskTypeId = taskType.TaskTypeId,
                        TaskTypeName = taskType.TaskTypeName,
                        ActivityTypeID = taskType.ActivityTypeID
                    }).ToList()
                } : null,
                ParentActivityId = activity.ParentActivityId,
                ParentActivity = activity.ParentActivity != null ? new GetActivityDTO
                {
                    ActivityId = activity.ParentActivity.ActivityId,
                    RequestId = activity.ParentActivity.RequestId,
                    Request = activity.ParentActivity.Request != null ? new GetRequestDTO
                    {
                        RequestId = activity.ParentActivity.Request.RequestId,
                        Price = activity.ParentActivity.Request.Price,
                        PaymentStatus = activity.ParentActivity.Request.PaymentStatus,
                        Advance = activity.ParentActivity.Request.Advance,
                        Comments = activity.ParentActivity.Request.Comments,
                        RequestName = activity.ParentActivity.Request.RequestName
                    } : null,
                    ActivityTypeID = activity.ParentActivity.ActivityTypeID,
                    ActivityType = activity.ParentActivity.ActivityType != null ? new GetActivityTypeDTO
                    {
                        ActivityTypeID = activity.ParentActivity.ActivityType.ActivityTypeID,
                        ActivityTypeName = activity.ParentActivity.ActivityType.ActivityTypeName,
                        TaskTypes = activity.ParentActivity.ActivityType.TaskTypes?.Select(taskType => new GetTaskTypeDTO
                        {
                            TaskTypeId = taskType.TaskTypeId,
                            TaskTypeName = taskType.TaskTypeName,
                            ActivityTypeID = taskType.ActivityTypeID
                        }).ToList()
                    } : null,
                    ParentActivityId = activity.ParentActivity.ParentActivityId,
                    ExpectedDuration = activity.ParentActivity.ExpectedDuration,
                    StartDate = activity.ParentActivity.StartDate,
                    employeePayment = activity.ParentActivity.employeePayment,
                    ExecutantId = activity.ParentActivity.ExecutantId,
                    mainExecutant = activity.ParentActivity.mainExecutant != null ? new GetEmployeeDTO
                    {
                        EmployeeId = activity.ParentActivity.mainExecutant.EmployeeId,
                        FirstName = activity.ParentActivity.mainExecutant.FirstName,
                        SecondName = activity.ParentActivity.mainExecutant.SecondName,
                        LastName = activity.ParentActivity.mainExecutant.LastName,
                        phone = activity.ParentActivity.mainExecutant.phone,
                        Email = activity.ParentActivity.mainExecutant.Email,
                        FullName = activity.ParentActivity.mainExecutant.FullName
                    } : null,
                    Tasks = activity.ParentActivity.Tasks?.Select(task => new GetTaskDTO
                    {
                        TaskId = task.TaskId,
                        ActivityId = task.ActivityId,
                        Duration = task.Duration,
                        StartDate = task.StartDate,
                        FinishDate = task.FinishDate,
                        ExecutantId = task.ExecutantId,
                        Executant = task.Executant != null ? new GetEmployeeDTO
                        {
                            EmployeeId = task.Executant.EmployeeId,
                            FirstName = task.Executant.FirstName,
                            SecondName = task.Executant.SecondName,
                            LastName = task.Executant.LastName,
                            phone = task.Executant.phone,
                            Email = task.Executant.Email,
                            FullName = task.Executant.FullName
                        } : null,
                        ControlId = task.ControlId,
                        Control = task.Control != null ? new GetEmployeeDTO
                        {
                            EmployeeId = task.Control.EmployeeId,
                            FirstName = task.Control.FirstName,
                            SecondName = task.Control.SecondName,
                            LastName = task.Control.LastName,
                            phone = task.Control.phone,
                            Email = task.Control.Email,
                            FullName = task.Control.FullName
                        } : null,
                        Comments = task.Comments,
                        TaskTypeId = task.TaskTypeId,
                        taskType = task.taskType != null ? new GetTaskTypeDTO
                        {
                            TaskTypeId = task.taskType.TaskTypeId,
                            TaskTypeName = task.taskType.TaskTypeName,
                            ActivityTypeID = task.taskType.ActivityTypeID
                        } : null,
                        executantPayment = task.executantPayment,
                        tax = task.tax,
                        CommentTax = task.CommentTax,
                        Status = task.Status
                    }).ToList(),
                    Plots = activity.ParentActivity.Plots?.Select(plot => new GetPlotDTO
                    {
                        PlotId = plot.PlotId,
                        PlotNumber = plot.PlotNumber,
                        RegulatedPlotNumber = plot.RegulatedPlotNumber,
                        neighborhood = plot.neighborhood,
                        City = plot.City,
                        Municipality = plot.Municipality,
                        Street = plot.Street,
                        StreetNumber = plot.StreetNumber,
                        designation = plot.designation,
                        locality = plot.locality
                    }).ToList()
                } : null,
                ExpectedDuration = activity.ExpectedDuration,
                StartDate = activity.StartDate,
                employeePayment = activity.employeePayment,
                ExecutantId = activity.ExecutantId,
                mainExecutant = activity.mainExecutant != null ? new GetEmployeeDTO
                {
                    EmployeeId = activity.mainExecutant.EmployeeId,
                    FirstName = activity.mainExecutant.FirstName,
                    SecondName = activity.mainExecutant.SecondName,
                    LastName = activity.mainExecutant.LastName,
                    phone = activity.mainExecutant.phone,
                    Email = activity.mainExecutant.Email,
                    FullName = activity.mainExecutant.FullName
                } : null,
                Tasks = activity.Tasks?.Select(task => new GetTaskDTO
                {
                    TaskId = task.TaskId,
                    ActivityId = task.ActivityId,
                    Duration = task.Duration,
                    StartDate = task.StartDate,
                    FinishDate = task.FinishDate,
                    ExecutantId = task.ExecutantId,
                    Executant = task.Executant != null ? new GetEmployeeDTO
                    {
                        EmployeeId = task.Executant.EmployeeId,
                        FirstName = task.Executant.FirstName,
                        SecondName = task.Executant.SecondName,
                        LastName = task.Executant.LastName,
                        phone = task.Executant.phone,
                        Email = task.Executant.Email,
                        FullName = task.Executant.FullName
                    } : null,
                    ControlId = task.ControlId,
                    Control = task.Control != null ? new GetEmployeeDTO
                    {
                        EmployeeId = task.Control.EmployeeId,
                        FirstName = task.Control.FirstName,
                        SecondName = task.Control.SecondName,
                        LastName = task.Control.LastName,
                        phone = task.Control.phone,
                        Email = task.Control.Email,
                        FullName = task.Control.FullName
                    } : null,
                    Comments = task.Comments,
                    TaskTypeId = task.TaskTypeId,
                    taskType = task.taskType != null ? new GetTaskTypeDTO
                    {
                        TaskTypeId = task.taskType.TaskTypeId,
                        TaskTypeName = task.taskType.TaskTypeName,
                        ActivityTypeID = task.taskType.ActivityTypeID
                    } : null,
                    executantPayment = task.executantPayment,
                    tax = task.tax,
                    CommentTax = task.CommentTax,
                    Status = task.Status
                }).ToList(),
                Plots = activity.Plots?.Select(plot => new GetPlotDTO
                {
                    PlotId = plot.PlotId,
                    PlotNumber = plot.PlotNumber,
                    RegulatedPlotNumber = plot.RegulatedPlotNumber,
                    neighborhood = plot.neighborhood,
                    City = plot.City,
                    Municipality = plot.Municipality,
                    Street = plot.Street,
                    StreetNumber = plot.StreetNumber,
                    designation = plot.designation,
                    locality = plot.locality
                }).ToList()
            }).ToList(),
            invoiceDTOs = this.invoiceDTOs?.Select(invoice => new GetInvoiceDTO
            {
                InvoiceId = invoice.InvoiceId,
                number = invoice.number,
                RequestId = invoice.RequestId,
                Request = invoice.Request != null ? new GetRequestDTO
                {
                    RequestId = invoice.Request.RequestId,
                    Price = invoice.Request.Price,
                    PaymentStatus = invoice.Request.PaymentStatus,
                    Advance = invoice.Request.Advance,
                    Comments = invoice.Request.Comments,
                    RequestName = invoice.Request.RequestName
                } : null,
                Sum = invoice.Sum,
            }).ToList()
        };
    }
}
