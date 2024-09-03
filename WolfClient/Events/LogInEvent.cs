using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfClient.Events.EventArgs;

namespace WolfClient.Events
{
    public delegate void LogInEventHandler(object sender, LogInEventArgs e);
    public static class LogInEvent
    {
        public static event LogInEventHandler logIn;


        public static void OnLogIn(string username, string role) {
            logIn?.Invoke(null, new LogInEventArgs(role, GlobalSettings.GetCurrentTime(), username));    
        }
    }
}
