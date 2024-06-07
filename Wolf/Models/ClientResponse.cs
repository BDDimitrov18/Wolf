using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Models
{
    public class ClientResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T ResponseObj { get; set; }     
    }
}
