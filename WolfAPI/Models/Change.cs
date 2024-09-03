using Microsoft.Build.Evaluation;
using WolfClient;

namespace WolfAPI.Models
{
    public class Change
    {
        public Guid ChangeId { get; } = Guid.NewGuid();
        public DateTime Timestamp { get; } = TimeSettingsWebApi.GetCurrentTime();
        public List<Operation> Operations { get; set; } = new List<Operation>();
    }
}
