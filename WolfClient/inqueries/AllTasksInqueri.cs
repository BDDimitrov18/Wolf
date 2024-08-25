using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using DTOS.DTO;
using DocumentFormat.OpenXml;

namespace WolfClient.inqueries
{
    public class AllTasksInqueri
    {
        private readonly List<RequestWithClientsDTO> _requests;
        private readonly List<GetEmployeeDTO> _employees;

        public AllTasksInqueri(List<RequestWithClientsDTO> requests, List<GetEmployeeDTO> employees)
        {
            _requests = requests;
            _employees = employees;
        }

        public void ExportToExcel(string outputPath)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(outputPath, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = document.WorkbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet()
                {
                    Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Inquiries"
                };
                sheets.Append(sheet);

                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                // Add headers
                AddHeaderRow(sheetData);

                // Set column widths
                SetColumnWidths(worksheetPart);

                // Create a CellFormat for text wrapping
                var stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = CreateStylesheet();
                stylesPart.Stylesheet.Save();

                uint wrapTextStyleIndex = 1;

                uint rowIndex = 2;

                foreach (var employee in _employees)
                {
                    var employeeRequests = _requests.Where(req =>
                        req.activityDTOs != null &&
                        req.activityDTOs.Any(act => act.Tasks != null && act.Tasks.Any(t => t.ExecutantId == employee.EmployeeId))
                    ).ToList();

                    int employeeRowSpan = 0;

                    foreach (var request in employeeRequests)
                    {
                        var employeeActivities = request.activityDTOs.Where(act =>
                            act.Tasks != null && act.Tasks.Any(t => t.ExecutantId == employee.EmployeeId)
                        ).ToList();

                        int requestRowSpan = 0;

                        foreach (var activity in employeeActivities)
                        {
                            var employeeTasks = activity.Tasks.Where(t => t.ExecutantId == employee.EmployeeId).ToList();

                            int activityRowSpan = 0;

                            foreach (var task in employeeTasks)
                            {
                                var row = new Row() { RowIndex = rowIndex, CustomHeight = false};
                                sheetData.Append(row);

                                if (employeeRowSpan == 0)
                                {
                                    AddTextCell(row, 1, employee.FullName, wrapTextStyleIndex); // Employee column
                                }
                                if (requestRowSpan == 0)
                                {
                                    AddTextCell(row, 2, request.requestDTO.RequestName, wrapTextStyleIndex); // Request column
                                    AddTextCell(row, 3, request.requestDTO.Price.ToString(), wrapTextStyleIndex); // Request Price column
                                    AddHyperlinkCell(worksheetPart, row, 4, request.requestDTO.Path ?? ""); // Path column
                                }
                                // Only set text in the first row of the merge range
                                if (activityRowSpan == 0)
                                {
                                    AddTextCell(row, 5, activity.ActivityTypeName, wrapTextStyleIndex); // Activity column
                                    AddTextCell(row, 6, activity.employeePayment.ToString(), wrapTextStyleIndex); // Activity Main Executant Payment column
                                }

                                AddTextCell(row, 7, task.taskType.TaskTypeName, wrapTextStyleIndex); // Tasks column
                                AddTextCell(row, 8, task.executantPayment.ToString(), wrapTextStyleIndex); // Task Employee Payment column
                                AddTextCell(row, 9, task.Duration.TotalHours.ToString(), wrapTextStyleIndex); // Task Duration column

                                rowIndex++;
                                requestRowSpan += 1;
                                activityRowSpan += 1;
                                employeeRowSpan += 1;
                            }

                            // Merge cells for the activity column
                            if (activityRowSpan > 1)
                            {
                                MergeCells(worksheetPart, rowIndex - (uint)activityRowSpan, 5, rowIndex - 1); // Activity
                                MergeCells(worksheetPart, rowIndex - (uint)activityRowSpan, 6, rowIndex - 1); // Activity Main Executant Payment
                            }
                        }

                        // Merge cells for the request columns
                        if (requestRowSpan > 1)
                        {
                            MergeCells(worksheetPart, rowIndex - (uint)requestRowSpan, 2, rowIndex - 1); // Request
                            MergeCells(worksheetPart, rowIndex - (uint)requestRowSpan, 3, rowIndex - 1); // Request Price
                            MergeCells(worksheetPart, rowIndex - (uint)requestRowSpan, 4, rowIndex - 1); // Path
                        }
                    }

                    // Merge cells for the employee column
                    if (employeeRowSpan > 1)
                    {
                        MergeCells(worksheetPart, rowIndex - (uint)employeeRowSpan, 1, rowIndex - 1); // Employee
                    }
                }

                worksheetPart.Worksheet.Save();
            }

            // Open the Excel file
            Process.Start(new ProcessStartInfo(outputPath) { UseShellExecute = true });
        }
        private Stylesheet CreateStylesheet()
        {
            return new Stylesheet(
                new Fonts(
                    new DocumentFormat.OpenXml.Spreadsheet.Font( // Index 0 - default
                        new FontSize() { Val = 11 },
                        new DocumentFormat.OpenXml.Spreadsheet.Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new DocumentFormat.OpenXml.Spreadsheet.Font( // Index 1 - bold
                        new Bold(),
                        new FontSize() { Val = 11 },
                        new DocumentFormat.OpenXml.Spreadsheet.Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new DocumentFormat.OpenXml.Spreadsheet.Font( // Index 2 - hyperlink
                        new Underline(),
                        new FontSize() { Val = 11 },
                        new DocumentFormat.OpenXml.Spreadsheet.Color() { Rgb = new HexBinaryValue() { Value = "0563C1" } }, // Blue color for hyperlink
                        new FontName() { Val = "Calibri" })
                ),
                new Fills(
                    new Fill(new PatternFill() { PatternType = PatternValues.None }), // Index 0 - default
                    new Fill(new PatternFill(new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FFFFFF" } })
                    { PatternType = PatternValues.Solid }) // Index 1 - solid white fill
                ),
                new Borders(
                    new Border( // Index 0 - default
                        new LeftBorder(),
                        new RightBorder(),
                        new TopBorder(),
                        new BottomBorder(),
                        new DiagonalBorder())
                ),
                new CellFormats(
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 0, FormatId = 0 }, // Index 0 - default
                    new CellFormat()
                    {
                        FontId = 0,
                        FillId = 0,
                        BorderId = 0,
                        Alignment = new Alignment()
                        {
                            WrapText = true
                        },
                        ApplyAlignment = true
                    }, // Index 1 - wrap text
                    new CellFormat()
                    {
                        FontId = 2,
                        FillId = 0,
                        BorderId = 0,
                        Alignment = new Alignment()
                        {
                            WrapText = true
                        },
                        ApplyAlignment = true
                    }  // Index 2 - hyperlink style (blue and underlined)
                )
            );
        }



        private void AddHeaderRow(SheetData sheetData)
        {
            var row = new Row() { RowIndex = 1 };
            sheetData.Append(row);

            AddTextCell(row, 1, "Employees");
            AddTextCell(row, 2, "Requests");
            AddTextCell(row, 3, "Request Price");
            AddTextCell(row, 4, "Path");
            AddTextCell(row, 5, "Activity");
            AddTextCell(row, 6, "Activity Main Executant Payment");
            AddTextCell(row, 7, "Tasks");
            AddTextCell(row, 8, "Task Employee Payment");
            AddTextCell(row, 9, "Task Duration");
        }

        private void AddTextCell(Row row, int columnIndex, string cellValue, uint styleIndex = 0)
        {
            uint rowIndex = row.RowIndex.HasValue ? row.RowIndex.Value : 0;

            Cell cell = new Cell()
            {
                CellReference = GetCellReference(columnIndex, (int)rowIndex),
                DataType = CellValues.String, // Ensuring all cells are treated as text
                CellValue = new CellValue(cellValue),
                StyleIndex = styleIndex // Apply the wrap text style
            };
            row.Append(cell);
        }

        private string GetCellReference(int columnIndex, int rowIndex)
        {
            string columnName = GetColumnName(columnIndex);
            return $"{columnName}{rowIndex}";
        }

        private string GetColumnName(int columnIndex)
        {
            string columnName = "";
            while (columnIndex > 0)
            {
                columnName = (char)((columnIndex - 1) % 26 + 'A') + columnName;
                columnIndex = (columnIndex - 1) / 26;
            }
            return columnName;
        }

        private void MergeCells(WorksheetPart worksheetPart, uint startRowIndex, int columnIndex, uint endRowIndex)
        {
            MergeCells mergeCells;
            if (worksheetPart.Worksheet.Elements<MergeCells>().Count() > 0)
            {
                mergeCells = worksheetPart.Worksheet.Elements<MergeCells>().First();
            }
            else
            {
                mergeCells = new MergeCells();
                worksheetPart.Worksheet.InsertAfter(mergeCells, worksheetPart.Worksheet.Elements<SheetData>().First());
            }

            string cellReference1 = GetCellReference(columnIndex, (int)startRowIndex);
            string cellReference2 = GetCellReference(columnIndex, (int)endRowIndex);

            if (startRowIndex != endRowIndex)  // Only merge if there is a range to merge
            {
                MergeCell mergeCell = new MergeCell()
                {
                    Reference = new StringValue($"{cellReference1}:{cellReference2}")
                };
                mergeCells.Append(mergeCell);
            }
        }
        private void SetColumnWidths(WorksheetPart worksheetPart)
        {
            Columns columns = new Columns();

            // Set custom widths for each column
            columns.Append(new Column() { Min = 1, Max = 1, Width = 20, CustomWidth = true }); // Employees
            columns.Append(new Column() { Min = 2, Max = 2, Width = 20, CustomWidth = true }); // Requests
            columns.Append(new Column() { Min = 3, Max = 3, Width = 15, CustomWidth = true }); // Request Price
            columns.Append(new Column() { Min = 4, Max = 4, Width = 20, CustomWidth = true }); // Path
            columns.Append(new Column() { Min = 5, Max = 5, Width = 25, CustomWidth = true }); // Activity
            columns.Append(new Column() { Min = 6, Max = 6, Width = 20, CustomWidth = true }); // Activity Main Executant Payment
            columns.Append(new Column() { Min = 7, Max = 7, Width = 20, CustomWidth = true }); // Tasks
            columns.Append(new Column() { Min = 8, Max = 8, Width = 20, CustomWidth = true }); // Task Employee Payment
            columns.Append(new Column() { Min = 9, Max = 9, Width = 15, CustomWidth = true }); // Task Duration

            worksheetPart.Worksheet.InsertAt(columns, 0);
        }
        private void AddHyperlinkCell(WorksheetPart worksheetPart, Row row, int columnIndex, string pathValue)
        {
            uint rowIndex = row.RowIndex.HasValue ? row.RowIndex.Value : 0;

            // If the path is null or empty, just add the text without a hyperlink
            if (string.IsNullOrEmpty(pathValue))
            {
                AddTextCell(row, columnIndex, "No Path Provided", 1); // Use default text wrapping style for non-hyperlink cells
                return;
            }

            // Create a new cell
            Cell cell = new Cell()
            {
                CellReference = GetCellReference(columnIndex, (int)rowIndex),
                DataType = CellValues.InlineString
            };
            cell.StyleIndex = 1;
            // Set the inline string with text wrapping, font color, and underline
            cell.InlineString = new InlineString(
                new Run(
                    new RunProperties(
                        new DocumentFormat.OpenXml.Spreadsheet.Color() { Rgb = new HexBinaryValue("0563C1") }, // Set color to blue
                        new Underline(), // Underline the text
                        new FontSize() { Val = 11 } // Set font size
                    ),
                    new Text(pathValue)
                    {
                        Space = SpaceProcessingModeValues.Preserve // Preserve spaces in the text
                    }
                )
            );

            // Ensure the cell text is wrapped
            cell.StyleIndex = 1; // Ensure text wrapping style is applied (assuming style index 1 is wrap text)

            row.Append(cell);

            // Ensure hyperlinks element is present in the worksheet
            Hyperlinks hyperlinks;
            if (worksheetPart.Worksheet.GetFirstChild<Hyperlinks>() != null)
            {
                hyperlinks = worksheetPart.Worksheet.GetFirstChild<Hyperlinks>();
            }
            else
            {
                hyperlinks = new Hyperlinks();
                worksheetPart.Worksheet.AppendChild(hyperlinks);
            }

            // Create the hyperlink with an external path
            Hyperlink hyperlink = new Hyperlink()
            {
                Reference = cell.CellReference,
                Tooltip = pathValue, // Show the full path as a tooltip
                Id = $"rId{Guid.NewGuid().ToString()}"
            };

            hyperlinks.Append(hyperlink);

            // Add the actual relationship part to the worksheet part
            worksheetPart.AddHyperlinkRelationship(new Uri(pathValue, UriKind.Absolute), true, hyperlink.Id);
        }





    }
}
