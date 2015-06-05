// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Aspose.CreateProjectWizard.Library;

namespace Aspose.CreateProjectWizard
{
    public partial class WelcomeControl : InstallerControl
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public WelcomeControl()
        {
            InitializeComponent();
            progressMessageLabel.Text = ApplicationSettings.FormatString(progressMessageLabel.Text);
            ProcessProductComponents();
        }

        protected internal override void Open()
        {
            label1.Text = global::Aspose.CreateProjectWizard.Properties.Resources.AsposeGeneralDetails;
        }

        private void ProcessProductComponents()
        {
        }

        private String ExtractZipFile(string productZipFilePath)
        {
            string baseDirectory = Path.GetDirectoryName(productZipFilePath) + @"\" + Path.GetFileNameWithoutExtension(productZipFilePath);
            Directory.CreateDirectory(baseDirectory);

            return baseDirectory;
        }

        private void AdvancedButton_Click(object sender, EventArgs e)
        {
        }

        private void ComponentsList_Deactivate(object sender, EventArgs e)
        {

        }

        private void selectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < productsCheckedListBox.Items.Count; i++)
                productsCheckedListBox.SetItemChecked(i, selectAllCheckBox.Checked);

            label1.Text = global::Aspose.CreateProjectWizard.Properties.Resources.AsposeGeneralDetails;
        }

        private void productsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected index, and then make sure it is valid.
            int selected = productsCheckedListBox.SelectedIndex;
            if (selected != -1)
            {
                label1.Text = AsposeManager.GetProductDescription(productsCheckedListBox.Items[selected].ToString());
            }
        }

        private void linkLabelAspose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AsposeManager.RunAsposeHomePage();
        }

    }
}
