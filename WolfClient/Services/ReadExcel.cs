using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfClient.Services.Interfaces;
using WolfClient.ViewModels;

namespace WolfClient.Services
{
    public class ReadExcel : IReadExcel
    {
        public List<EKTVIewModel> ReadExcelFile(string filePath)
        {
            var ekTList = new List<EKTVIewModel>();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);

                // Assuming the first two rows contain headers, start from the third row
                foreach (var row in worksheet.RowsUsed().Skip(2))
                {
                    var ekTViewModel = new EKTVIewModel
                    {
                        EKTNumber = row.Cell(1).GetString(),
                        TypeOfPlace = row.Cell(2).GetString(),
                        TownName = row.Cell(3).GetString(),
                        Localitiy = row.Cell(6).GetString(),
                        Municipality = row.Cell(8).GetString()
                    };

                    ekTList.Add(ekTViewModel);
                }
            }

            return ekTList;
        }
    }
}
