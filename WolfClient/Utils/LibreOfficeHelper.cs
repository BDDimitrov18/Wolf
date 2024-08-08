using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;

public class LibreOfficeHelper
{
    public static string FindLibreOfficePath()
    {
        string libreOfficePath = null;

        // Try to find LibreOffice in the registry
        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\LibreOffice\UNO\InstallPath"))
        {
            if (key != null)
            {
                libreOfficePath = key.GetValue(null) as string;
                if (!string.IsNullOrEmpty(libreOfficePath))
                {
                    libreOfficePath = Path.Combine(libreOfficePath, "program", "soffice.exe");
                    if (File.Exists(libreOfficePath))
                    {
                        return libreOfficePath;
                    }
                }
            }
        }

        // Check typical installation directories (if needed)
        string[] possiblePaths = new string[]
        {
            @"C:\Program Files\LibreOffice\program\soffice.exe",
            @"C:\Program Files (x86)\LibreOffice\program\soffice.exe",
            @"D:\Program Files\LibreOffice\program\soffice.exe",
            @"E:\Program Files\LibreOffice\program\soffice.exe"
            // Add more paths as necessary
        };

        foreach (var path in possiblePaths)
        {
            if (File.Exists(path))
            {
                return path;
            }
        }

        // If not found, throw an exception or prompt the user
        throw new FileNotFoundException("LibreOffice not found. Please install LibreOffice or specify the correct path.");
    }
}
