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
            _selectedPlotOwnerRelashionsip = _dataService.GetLinkedPlotOwnerRelashionshipsFilterActivity(_selectedActivity);

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

            // Create a new, expandable MemoryStream
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(docxFileData, 0, docxFileData.Length);
                memoryStream.Position = 0;  // Reset the position to the beginning of the stream

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
                        ReplaceBlocks(body, "DocumentsOfOwnership_Block", PrepareDocumentOfOwnerShipBlock());
                        ReplaceBlocks(body, "PowerOfAttorneyDocument_Block", PreparePowerOfAttorneyDocumentBlock());
                        ReplaceBlocks(body, "Owners_Block", prepareOwnersBlocks());

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
                        .Replace("[Plot_Locality]", plot.locality)
                        .Replace("[Plot_Manicipality]", plot.Municipality);
                }
            }
        }

        private void ReplaceBlocks(Body body, string blockName, List<Dictionary<string, string>> blockItems)
        {
            var paragraphs = body.Elements<Paragraph>().ToList();
            bool insideBlock = false;
            string currentBlockName = null;
            List<OpenXmlElement> blockTemplateElements = new List<OpenXmlElement>();
            StringBuilder blockBuilder = new StringBuilder();

            for (int i = 0; i < paragraphs.Count; i++)
            {
                var paragraphText = paragraphs[i].InnerText;

                if (!insideBlock && paragraphText.Contains("(("))
                {
                    blockBuilder.Append(paragraphText);
                    if (blockBuilder.ToString().Contains("((") && blockBuilder.ToString().Contains("))"))
                    {
                        int start = blockBuilder.ToString().IndexOf("((");
                        int end = blockBuilder.ToString().IndexOf("))");
                        currentBlockName = blockBuilder.ToString().Substring(start + 2, end - start - 2).Trim();

                        if (currentBlockName == blockName)
                        {
                            blockBuilder.Clear();
                        }
                        else
                        {
                            blockBuilder.Clear();
                            currentBlockName = null;
                        }
                    }
                }

                if (currentBlockName == blockName && paragraphText.Contains("{"))
                {
                    insideBlock = true;
                }

                if (insideBlock)
                {
                    blockTemplateElements.Add(paragraphs[i].CloneNode(true));
                    if (paragraphText.Contains("}"))
                    {
                        insideBlock = false;
                        currentBlockName = null;

                        var blockContent = new List<Paragraph>();

                        foreach (var item in blockItems)
                        {
                            foreach (var element in blockTemplateElements)
                            {
                                var clonedElement = element.CloneNode(true);
                                ReplacePlaceholdersInElement(clonedElement, item);
                                blockContent.Add(clonedElement as Paragraph);
                            }
                        }

                        // Remove the original block and insert the new content
                        paragraphs.RemoveRange(i - blockTemplateElements.Count + 1, blockTemplateElements.Count);
                        paragraphs.InsertRange(i - blockTemplateElements.Count + 1, blockContent);

                        // Adjust the loop index to account for the inserted content
                        i = i - blockTemplateElements.Count + blockContent.Count;
                        blockTemplateElements.Clear();
                        currentBlockName = null;
                        insideBlock = false;
                    }
                }
            }

            // Update the body with the modified paragraphs
            body.RemoveAllChildren<Paragraph>();
            foreach (var paragraph in paragraphs)
            {
                body.Append(paragraph.CloneNode(true));
            }
        }


        private void ReplacePlaceholdersInElement(OpenXmlElement element, Dictionary<string, string> replacements)
        {
            foreach (var text in element.Descendants<Text>())
            {
                foreach (var placeholder in replacements.Keys)
                {
                    if (text.Text.Contains($"[{placeholder}]"))
                    {
                        text.Text = text.Text.Replace($"[{placeholder}]", replacements[placeholder]);
                    }
                }
            }
        }

        public List<Dictionary<string,string>> prepareOwnersBlocks() {
            List<Dictionary<string,string>> returnDic = new List<Dictionary<string, string>>();
            List<GetOwnerDTO> distinctOwners = GetDistinctOwners(_selectedActivity);
            foreach (var owner in distinctOwners) {
                Dictionary<string,string> temDictionary = new Dictionary<string,string>();
                List<GetPlotDTO> OwnerAllPLots = GetAllPlotsFromOwner(owner);
                string allPlotsNumbers = "";
                foreach (var plot in OwnerAllPLots)
                {
                    if (plot != OwnerAllPLots.Last())
                    {
                        allPlotsNumbers += plot.PlotNumber + ",";
                    }
                    else {
                        allPlotsNumbers += plot.PlotNumber;
                    }
                }
                temDictionary.Add("Owner_FullName", $"{owner.FirstName} {owner.MiddleName} {owner.LastName}");
                temDictionary.Add("Owner_Address",owner.Address);
                temDictionary.Add("Plot_City", OwnerAllPLots[0].City);
                temDictionary.Add("SingleOwner_AllPlots", allPlotsNumbers);
                temDictionary.Add("Plot_Locality", OwnerAllPLots[0].locality);
                returnDic.Add(temDictionary);
            }
            return returnDic; 
        }
        public List<Dictionary<string, string>> PrepareDocumentOfOwnerShipBlock() {
            List<Dictionary<string, string>> returnDic = new List<Dictionary<string, string>>();
            List<GetDocumentOfOwnershipDTO> documentOfOwnershipDTOs = GetDistinctDocuments(_selectedActivity);
            foreach (var document in documentOfOwnershipDTOs) { 
                Dictionary<string,string> tempDictionary = new Dictionary<string,string>();
                tempDictionary.Add("Document_Type",document.TypeOfDocument);
                tempDictionary.Add("Document_Number", document.NumberOfDocument);
                tempDictionary.Add("Document_TOM", document.TOM.ToString());
                tempDictionary.Add("Document_Register", document.register);
                tempDictionary.Add("Document_Case", document.DocCase);
                tempDictionary.Add("Document_DateOfRegistration", document.DateOfRegistering.ToString());
                tempDictionary.Add("Document_Issuer", document.Issuer);
                returnDic.Add(tempDictionary);
            }
            return returnDic;
        }

        public List<Dictionary<string, string>> PreparePowerOfAttorneyDocumentBlock() {
            List<Dictionary<string, string>> returnDic = new List<Dictionary<string, string>>();
            List<GetPowerOfAttorneyDocumentDTO> powerOfAttorneyDocumentDTOs = GetDistinctPowerOfAttorneyDocuments(_selectedActivity);
            foreach (var powerOfAttorneyDocument in powerOfAttorneyDocumentDTOs) {
                Dictionary<string, string> tempDictionary = new Dictionary<string, string>();
                tempDictionary.Add("PowerOfAttorneyDocument_Number", powerOfAttorneyDocument.number);
                tempDictionary.Add("PowerOfAttorneyDocument_DateOfIssuing", powerOfAttorneyDocument.dateOfIssuing.ToString());
                tempDictionary.Add("PowerOfAttorneyDocument_Issuer", powerOfAttorneyDocument.Issuer);
                returnDic.Add(tempDictionary);
            }
            return returnDic;
        }

        private List<GetPlotDTO> GetAllPlotsFromOwner(GetOwnerDTO ownerDTO)
        {
            List<GetPlotDTO> ownerPlots = new List<GetPlotDTO>();

            foreach (var relationship in _selectedPlotOwnerRelashionsip)
            {
                if (relationship.DocumentOwner.OwnerID == ownerDTO.OwnerID)
                {
                    var plot = relationship.DocumentPlot.Plot;
                    if (!ownerPlots.Any(p => p.PlotId == plot.PlotId))
                    {
                        ownerPlots.Add(plot);
                    }
                }
            }

            return ownerPlots;
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
