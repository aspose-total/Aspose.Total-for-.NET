// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Ionic.Zip;
using System.Net;
using Aspose.CreateProjectWizard.com.aspose.community;

namespace Aspose.CreateProjectWizard.Library
{
    public class AsposeManager
    {

        public static void RunAsposeHomePage()
        {
            System.Diagnostics.Process.Start("http://www.aspose.com");
        }

        public static ProductRelease GetProductReleaseInformation(string productName)
        {
            if (!IsInternetConnected)
            {
                return null;
            }
            else
            {
                AsposeDownloads asposeDownloads = new AsposeDownloads();
                return asposeDownloads.GetProductRelease(".NET", productName);
            }
        }

        public static string GetLibraryPath(string productName)
        {
            string dllFile = AsposeHomePath + "\\" + productName + "\\" + productName + ".dll";
            if (File.Exists(dllFile))
                return dllFile;

            return string.Empty;
        }

        public static bool IsReleaseExists(string productName, string rootPath, string versionNumber)
        {
            string versionFile = rootPath + "\\" + productName + ".ver";
            string dllFile = rootPath + "\\" + productName + ".dll";

            try
            {
                if (File.Exists(dllFile))
                {
                    if (File.Exists(versionFile))
                    {
                        string storedVersion = File.ReadAllText(versionFile);
                        if (storedVersion.Equals(versionNumber))
                            return true;
                    }
                }
            }
            catch (FileNotFoundException) { }

            return false;
        }

        public static void SaveReleaseInfo(string productName, string rootPath, string versionNumber)
        {
            string versionFile = rootPath + "\\" + productName + ".ver";
            string dllFile = rootPath + "\\" + productName + ".dll";

            try
            {
                if (File.Exists(dllFile))
                {
                    if (File.Exists(versionFile))
                    {
                        string storedVersion = File.ReadAllText(versionFile);
                        if (storedVersion.Equals(versionNumber))
                            return;
                    }
                }
                File.WriteAllText(versionFile, versionNumber);
            }
            catch (FileNotFoundException) { }
        }

        private static string GetDownloadURL(string productName)
        {
            if (!IsInternetConnected)
            {
                return string.Empty;
            }
            else
            {
                AsposeDownloads asposeDownloads = new AsposeDownloads();
                return asposeDownloads.GetProductRelease(".NET", productName).DownloadLink;
            }
        }

        # region Utility Methods

        public static bool IsInternetConnected
        {
            get
            {
                try
                {
                    System.Net.IPHostEntry ipHostEntry = System.Net.Dns.GetHostEntry("www.google.com");
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public string readVersion(string productName)
        {
            string localPath = AsposeHomePath + productName + ".ver";
            string line = null;

            try
            {
                return System.IO.File.ReadAllText(localPath);
            }
            catch (FileNotFoundException) { }
            catch (IOException) { }

            return line;
        }

        private bool libraryAlreadyExists(string libFileName)
        {
            return System.IO.File.Exists(AsposeHomePath + libFileName);
        }

        public static string GetAsposeDownloadFolder(string productName)
        {
            string path = AsposeHomePath + "\\" + productName;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }

        public static string AsposeHomePath
        {
            get
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Aspose";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                return path;
            }
        }


        public static bool ExtractZipFile(string zipFilePath, string pathToExtract)
        {
            try
            {
                var options = new ReadOptions { StatusMessageWriter = System.Console.Out };
                using (ZipFile zip = ZipFile.Read(zipFilePath, options))
                {
                    zip.ExtractAll(pathToExtract, ExtractExistingFileAction.OverwriteSilently);
                }
            }
            catch (Exception)
            {
                return false;
            }

            try
            {
                File.Delete(zipFilePath);
            }
            catch (Exception) { }

            return true;
        }

        # endregion Utility Methods


        public static string GetProductDescription(string productName)
        {
            productName = productName.ToLower();

            string description = string.Empty;

            switch (productName)
            {
                case "aspose.cells":
                    description = global::Aspose.CreateProjectWizard.Properties.Resources.Aspose_Cells;
                    break;
                case "aspose.words":
                    description = global::Aspose.CreateProjectWizard.Properties.Resources.Aspose_Words;
                    break;
                case "aspose.pdf":
                    description = global::Aspose.CreateProjectWizard.Properties.Resources.Aspose_Pdf;
                    break;
                case "aspose.slides":
                    description = global::Aspose.CreateProjectWizard.Properties.Resources.Aspose_Slides;
                    break;
                case "aspose.barcode":
                    description = global::Aspose.CreateProjectWizard.Properties.Resources.Aspose_BarCode;
                    break;
                case "aspose.tasks":
                    description = global::Aspose.CreateProjectWizard.Properties.Resources.Aspose_Tasks;
                    break;
                case "aspose.diagram":
                    description = global::Aspose.CreateProjectWizard.Properties.Resources.Aspose_Diagram;
                    break;
                case "aspose.ocr":
                    description = global::Aspose.CreateProjectWizard.Properties.Resources.Aspose_OCR;
                    break;
                case "aspose.imaging":
                    description = global::Aspose.CreateProjectWizard.Properties.Resources.Aspose_Imaging;
                    break;
                case "aspose.email":
                    description = global::Aspose.CreateProjectWizard.Properties.Resources.Aspose_Email;
                    break;
                case "aspose.note":
                    description = global::Aspose.CreateProjectWizard.Properties.Resources.Aspose_Note;
                    break;
                default:
                    description = "";
                    break;
            }

            description = "  \u25CF " + description.Replace("\r\n", "\r\n  \u25CF ");

            return description;
        }
    }
}
