// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System.IO;
using Aspose.CreateProjectWizard.Library;
using VSLangProj;

namespace Aspose.CreateProjectWizard
{
    class IWizardImplementation : IWizard
    {
        private InstallerForm installerForm;

        public string DestinationDirectory { get; internal set; }
        public string ProjectName { get; internal set; }

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
            string referencesToAdd = string.Empty;
            string destinationFileToChange = string.Empty;
            try
            {
                string referenceTextTemplate = (project.UniqueName.EndsWith(".vbproj")) ? "Imports {0}" : "using {0};";
                destinationFileToChange = (project.UniqueName.EndsWith(".vbproj")) ? "\\View.ascx.vb" : "\\View.ascx.cs";
                destinationFileToChange = DestinationDirectory + destinationFileToChange;
                if (!File.Exists(destinationFileToChange)) destinationFileToChange = string.Empty;

                string destinationAsposeFolder = DestinationDirectory + "\\Aspose";
                if (!Directory.Exists(destinationAsposeFolder)) Directory.CreateDirectory(destinationAsposeFolder);
                
                foreach (string product in GlobalData.SelectedProductsList)
                {
                    string productReleaseFile = AsposeManager.GetLibraryPath(product);
                    if (!string.IsNullOrEmpty(productReleaseFile))
                    {
                        File.Copy(productReleaseFile, destinationAsposeFolder + "\\" + Path.GetFileName(productReleaseFile));
                        ((VSProject)project.Object).References.Add(destinationAsposeFolder + "\\" + Path.GetFileName(productReleaseFile));

                        referencesToAdd += string.Format(referenceTextTemplate, product) + Environment.NewLine;
                    }
                }               
            }
            catch (Exception) { }            
            finally 
            {
                if (!string.IsNullOrEmpty(destinationFileToChange))
                {
                    string text = File.ReadAllText(destinationFileToChange);
                    text = text.Replace("$Aspose_Dynamic_References$", referencesToAdd);
                    File.WriteAllText(destinationFileToChange, text);
                }
            }
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {

        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            try
            {
                DestinationDirectory = replacementsDictionary["$destinationdirectory$"];
                ProjectName = replacementsDictionary["$safeprojectname$"];
                ShowCustomForm();
            }
            catch (Exception) { }
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        private void ShowCustomForm()
        {
            installerForm = new InstallerForm();
            installerForm.Text = ApplicationSettings.FormatString("Aspose .NET Module Development Template for DNN");

            installerForm.ContentControls.Add(CreateWelcomeControl());
            installerForm.ContentControls.Add(CreateProcessControl());

            installerForm.ShowDialog();
        }

        private static InstallerControl CreateWelcomeControl()
        {
            WelcomeControl control = new WelcomeControl();
            control.Title = ApplicationSettings.FormatString("Aspose DNN Project");
            control.SubTitle = ApplicationSettings.FormatString("Welcome to the Aspose DNN project creation wizard");
            return control;
        }

        internal static InstallProcessControl CreateProcessControl()
        {
            InstallProcessControl control = new InstallProcessControl();
            control.Title = "Aspose DNN Project";
            control.SubTitle = "Thank you for your patience while we configure your preferences";
            return control;
        }
    }
}
