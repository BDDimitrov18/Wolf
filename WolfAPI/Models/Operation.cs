namespace WolfAPI.Models
{
    public class Operation
    {
        public Guid OperationId { get; } = Guid.NewGuid();
        public string OperationType { get; set; } // e.g., "Update", "Delete", etc.
        public string ObjectName { get; set; } // The name of the object being modified
        public object AffectedObject { get; set; } // The object that was affected
        public object PreviousState { get; set; } // State of the object before the operation
        public object NewState { get; set; } // State of the object after the operation
    }

}
