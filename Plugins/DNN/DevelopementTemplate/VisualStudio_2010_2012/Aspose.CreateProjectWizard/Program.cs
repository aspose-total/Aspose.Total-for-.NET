// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Aspose.CreateProjectWizard
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InstallerForm form = new InstallerForm();
            form.Text = ApplicationSettings.FormatString("Aspose DNN Project Templates");

            form.ContentControls.Add(CreateWelcomeControl());
            form.ContentControls.Add(CreateProcessControl());

            Application.Run(form);
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