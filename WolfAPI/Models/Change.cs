using Microsoft.Build.Evaluation;

namespace WolfAPI.Models
{
    public class Change
    {
        public Guid ChangeId { get; } = Guid.NewGuid();
        public DateTime Timestamp { get; } = DateTime.Now;
        public List<Operation> Operations { get; set; } = new List<Operation>();
    }
}
