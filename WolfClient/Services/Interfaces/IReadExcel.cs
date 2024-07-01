using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfClient.ViewModels;

namespace WolfClient.Services.Interfaces
{
    public interface IReadExcel
    {
        public List<EKTVIewModel> ReadExcelFile(string filePath);
    }
}
