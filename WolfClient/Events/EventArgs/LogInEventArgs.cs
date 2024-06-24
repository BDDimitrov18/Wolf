using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfClient.Events.EventArgs
{
    public class LogInEventArgs 
    {
        public string _role { get; set; }
        public DateTime _LoginTime { get; set; }

        public string _Username { get; set; }

        public LogInEventArgs(string role, DateTime loginTime, string username)
        {
            _role = role;
            _LoginTime = loginTime;
            _Username = username;   
        }
    }
}
