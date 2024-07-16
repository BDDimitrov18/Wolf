using DocumentFormat.OpenXml.Packaging;
using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WolfClient.Services.Interfaces;
using DocumentFormat.OpenXml.Wordprocessing;
using AngleSharp.Dom;
using DocumentFormat.OpenXml;

namespace WolfClient.NewForms
{
    public partial class DocumentEditor : Form
    {
        private readonly IDataService _dataService;
        private byte[] _fileData;
        private GetActivityDTO _selectedActivity;
        private List<GetPlotDTO> _selectedPlots;
        private GetRequestDTO _selectedRequest;
        private List<GetClientDTO> _selectedClients;
        private List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> _selectedPlotOwnerRelashionsip;
        private string _convertedFilePath;

        public DocumentEditor(IDataService dataService, byte[] fileData, GetActivityDTO activity)
        {
            InitializeComponent();
            _dataService = dataService;
            _fileData = fileData;
            _selectedActivity = activity;
            _selectedPlots = _dataService.GetSelectedPlots();
            _selectedRequest = _dataService.GetSelectedRequest();
            _selectedClients = _dataService.getSelectedCLients();
            _selectedPlotOwnerRelashionsip = _dataService.GetLinkedPlotOwnerRelashionships();

            // Convert the file to .docx before processing
            _convertedFilePath = ConvertDocToDocx(_fileData);

            // Generate the document
            GenerateDocument();
        }

        private string ConvertDocToDocx(byte[] fileData)
        {
            // Use the current directory for temporary file operations
            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine($"Current directory: {currentDirectory}");

            // Save the .doc file to a temporary location in the current directory
            string tempDocPath = Path.Combine(currentDirectory, $"test.doc");
            File.WriteAllBytes(tempDocPath, fileData);
            Console.WriteLine($"Temporary .doc file created at: {tempDocPath}");

            // Determine the output path for the .docx file
            string outputDocxPath = Path.Combine(currentDirectory, $"test.docx");
            Console.WriteLine($"Expected .docx output path: {outputDocxPath}");

            string libreOfficePath = @"C:\Program Files\LibreOffice\program\soffice.exe"; // Adjust the path to your LibreOffice installation
            string args = $"--headless --convert-to docx \"{tempDocPath}\" --outdir \"{currentDirectory}\"";
            Console.WriteLine($"Conversion command: {libreOfficePath} {args}");

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = libreOfficePath,
                Arguments = args,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using (Process process = Process.Start(startInfo))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();
                if (process.ExitCode != 0)
                {
                    Console.WriteLine($"LibreOffice conversion error: {error}");
                    throw new Exception($"LibreOffice conversion failed: {error}");
                }

                Console.WriteLine($"LibreOffice conversion output: {output}");
            }

            // Verify that the output file exists
            if (!File.Exists(outputDocxPath))
            {
                Console.WriteLine("Converted .docx file not found.");
                throw new FileNotFoundException("Converted .docx file not found.", outputDocxPath);
            }

            Console.WriteLine($"Converted .docx file found at: {outputDocxPath}");

            // Clean up the temporary .doc file
            File.Delete(tempDocPath);

            return outputDocxPath;
        }

        private void GenerateDocument()
        {
            // Load the converted .docx file into a MemoryStream
            byte[] docxFileData = File.ReadAllBytes(_convertedFilePath);
            using (var memoryStream = new MemoryStream(docxFileData))
            {
                // Open the document as a WordprocessingDocument from the MemoryStream
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(memoryStream, true))
                {
                    // Get the main document part
                    MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                    if (mainPart != null)
                    {
                        // Get the document body
                        Body body = mainPart.Document.Body;

                        // Replace placeholders and blocks
                        ReplacePlaceholders(body, _selectedActivity);
                        ReplaceBlocks(body, "(DocumentsOfOwnership_Block)", GetDistinctDocuments(_selectedActivity));
                        ReplaceBlocks(body, "(PowerOfAttorneyDocument_Block)", GetDistinctPowerOfAttorneyDocuments(_selectedActivity));
                        ReplaceBlocks(body, "(Owners_Block)", GetDistinctOwners(_selectedActivity));

                        // Save changes to the document
                        mainPart.Document.Save();
                    }
                }

                // Write the updated memory stream to a file
                string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "GeneratedDocument.docx");
                File.WriteAllBytes(outputFilePath, memoryStream.ToArray());

                // Load the updated document into the viewer
                documentViewer1.LoadDocument(outputFilePath);

                MessageBox.Show($"Document generated and saved successfully at {outputFilePath}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Clean up the temporary .docx file
            File.Delete(_convertedFilePath);
        }

        private string GetDocumentContent(Body body)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var element in body.Elements())
            {
                sb.Append(element.InnerText);
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        private void UpdateDocumentContent(Body body, string content)
        {
            body.RemoveAllChildren<Paragraph>();
            foreach (var line in content.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                body.Append(new Paragraph(new Run(new Text(line))));
            }
        }

        private void ReplacePlaceholders(Body body, GetActivityDTO activity)
        {
            foreach (var textElement in body.Descendants<Text>())
            {
                textElement.Text = textElement.Text
                    .Replace("[ActivityId]", activity.ActivityId.ToString())
                    .Replace("[Activity_Name]", activity.ActivityTypeName)
                    .Replace("[Activity_MainExecutant_FullName]", activity.mainExecutant.FullName)
                    .Replace("[Activity_MainExecutant_Phone]", activity.mainExecutant.phone);

                foreach (var client in _selectedClients)
                {
                    textElement.Text = textElement.Text
                        .Replace("[Client_Name]", client.FullName)
                        .Replace("[Client_address]", client.Address);
                }

                foreach (var plot in _selectedPlots)
                {
                    textElement.Text = textElement.Text
                        .Replace("[Plot_City]", plot.City)
                        .Replace("[Plot_Locality]", plot.locality);
                }
            }
        }

        private void ReplaceBlocks<T>(Body body, string blockName, List<T> blockItems)
        {
            var paragraphs = body.Elements<Paragraph>().ToList();
            var blockStartIndex = -1;
            var blockEndIndex = -1;

            // Identify the start and end indices of the block
            for (int i = 0; i < paragraphs.Count; i++)
            {
                var paragraphText = paragraphs[i].InnerText;

                if (blockStartIndex == -1 && paragraphText.Contains($"({blockName}){{"))
                {
                    blockStartIndex = i;
                }

                if (blockStartIndex != -1 && paragraphText.Contains("}}"))
                {
                    blockEndIndex = i;
                    break;
                }
            }

            if (blockStartIndex != -1 && blockEndIndex != -1)
            {
                var blockTemplate = new List<OpenXmlElement>();

                for (int i = blockStartIndex + 1; i < blockEndIndex; i++)
                {
                    blockTemplate.Add(paragraphs[i].CloneNode(true));
                }

                var blockContent = new List<Paragraph>();

                foreach (var item in blockItems)
                {
                    foreach (var element in blockTemplate)
                    {
                        var clonedElement = element.CloneNode(true);
                        ReplacePlaceholdersInElement(clonedElement, item);
                        blockContent.Add(clonedElement as Paragraph);
                    }
                }

                paragraphs.RemoveRange(blockStartIndex + 1, blockEndIndex - blockStartIndex - 1);
                paragraphs.InsertRange(blockStartIndex + 1, blockContent);

                body.RemoveAllChildren<Paragraph>();
                foreach (var paragraph in paragraphs)
                {
                    body.Append(paragraph);
                }
            }
        }

        private void ReplacePlaceholdersInElement<T>(OpenXmlElement element, T item)
        {
            var properties = item.GetType().GetProperties();

            foreach (var text in element.Descendants<Text>())
            {
                foreach (var property in properties)
                {
                    var placeholder = $"[{property.Name}]";
                    var value = property.GetValue(item)?.ToString() ?? string.Empty;
                    text.Text = text.Text.Replace(placeholder, value);
                }
            }
        }

        private List<GetDocumentOfOwnershipDTO> GetDistinctDocuments(GetActivityDTO activity)
        {
            var documents = new List<GetDocumentOfOwnershipDTO>();
            foreach (var plot in _selectedPlots)
            {
                foreach (var relationship in _selectedPlotOwnerRelashionsip)
                {
                    if (relationship.DocumentPlot.PlotId == plot.PlotId && !documents.Exists(d => d.DocumentId == relationship.DocumentPlot.documentOfOwnership.DocumentId))
                    {
                        documents.Add(relationship.DocumentPlot.documentOfOwnership);
                    }
                }
            }
            return documents;
        }

        private List<GetPowerOfAttorneyDocumentDTO> GetDistinctPowerOfAttorneyDocuments(GetActivityDTO activity)
        {
            var powerOfAttorneyDocuments = new List<GetPowerOfAttorneyDocumentDTO>();
            foreach (var plot in _selectedPlots)
            {
                foreach (var relationship in _selectedPlotOwnerRelashionsip)
                {
                    if (relationship.DocumentPlot.PlotId == plot.PlotId && !powerOfAttorneyDocuments.Exists(p => p.number == relationship.powerOfAttorneyDocumentDTO.number))
                    {
                        powerOfAttorneyDocuments.Add(relationship.powerOfAttorneyDocumentDTO);
                    }
                }
            }
            return powerOfAttorneyDocuments;
        }

        private List<GetOwnerDTO> GetDistinctOwners(GetActivityDTO activity)
        {
            var owners = new List<GetOwnerDTO>();
            foreach (var plot in _selectedPlots)
            {
                foreach (var relationship in _selectedPlotOwnerRelashionsip)
                {
                    if (relationship.DocumentPlot.PlotId == plot.PlotId)
                    {
                        var owner = relationship.DocumentOwner.Owner;
                        if (!owners.Exists(o => o.OwnerID == owner.OwnerID))
                        {
                            owners.Add(owner);
                        }
                    }
                }
            }
            return owners;
        }
    }
}
