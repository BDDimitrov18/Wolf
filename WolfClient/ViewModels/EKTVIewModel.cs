using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfClient.ViewModels
{
    public class EKTVIewModel
    {
        public string EKTNumber { get; set; } //ЕКАТТЕ

        public string TypeOfPlace { get; set; } //Вид

        public string TownName { get; set; }// Име на населено място

        public string Localitiy { get; set; }// Име на областта

        public string Municipality { get; set; } // Община

    }
}
