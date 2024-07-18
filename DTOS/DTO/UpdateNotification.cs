using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class UpdateNotification<T>
    {
        public string OperationType { get; set; }
        public T UpdatedEntity { get; set; }
    }

}
