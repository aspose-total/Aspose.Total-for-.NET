// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Aspose.CreateProjectWizard.Library;

namespace Aspose.CreateProjectWizard
{
    public partial class InstallerForm : Form
    {
        private readonly InstallerControlList contentControls;
        private InstallerControl currentContentControl;
        private int currentContentControlIndex = 0;

        public InstallerForm()
        {
            this.contentControls = new InstallerControlList();
            try
            {

            }
            catch (FileNotFoundException)
            {
            }
            InitializeComponent();

            this.Load += new EventHandler(InstallerForm_Load);
        }

        #region Event Handlers

        private void InstallerForm_Load(object sender, EventArgs e)
        {
            string bannerImageFile = ApplicationSettings.BannerImage;
            if (!String.IsNullOrEmpty(bannerImageFile))
            {
                this.titlePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                if (bannerImageFile != "Default")
                {
                    this.titlePanel.BackgroundImage = LoadImage(bannerImageFile);
                }
                else
                {
                    this.titlePanel.BackgroundImage = global::Aspose.CreateProjectWizard.Properties.Resources.Banner;
                }
            }

            string logoImageFile = ApplicationSettings.LogoImage;
            if (!String.IsNullOrEmpty(logoImageFile))
            {
                if (logoImageFile != "Default")
                {
                    this.logoPicture.BackgroundImage = LoadImage(logoImageFile);
                }
            }

            ReplaceContentControl(0);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            GlobalData.SelectedProductsList.Clear();

            InstallerControl newContentControl = contentControls[0];
            CheckedListBox productsCheckedListBox = (CheckedListBox)this.Controls.Find("productsCheckedListBox", true)[0];

            if (productsCheckedListBox.CheckedItems.Count > 0)
            {
                foreach (object itemChecked in productsCheckedListBox.CheckedItems)
                {
                    if (!GlobalData.SelectedProductsList.Contains(itemChecked.ToString()))
                        GlobalData.SelectedProductsList.Add(itemChecked.ToString());
                }
            }

            currentContentControlIndex++;
            ReplaceContentControl(currentContentControlIndex);
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            currentContentControlIndex--;
            ReplaceContentControl(currentContentControlIndex);

            if (GlobalData.backgroundWorker != null)
            {
                if (GlobalData.backgroundWorker.IsBusy == true)
                {
                    GlobalData.backgroundWorker.CancelAsync();
                    GlobalData.backgroundWorker.CancelAsync();
                    GlobalData.backgroundWorker.Dispose();
                    GlobalData.backgroundWorker = null;
                    GC.Collect();
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void InstallerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (GlobalData.backgroundWorker != null)
                {
                    if (GlobalData.backgroundWorker.IsBusy == true)
                    {
                        GlobalData.backgroundWorker.CancelAsync();
                        GlobalData.backgroundWorker.Dispose();
                        GlobalData.backgroundWorker = null;
                        GC.Collect();
                    }
                }                
            }
            catch (Exception)
            {
            }            
        }

        #endregion

        #region Public Properties

        public InstallerControlList ContentControls
        {
            get { return contentControls; }
        }

        public Button AbortButton
        {
            get
            {
                return cancelButton;
            }
        }

        public Button PrevButton
        {
            get
            {
                return prevButton;
            }
        }

        public Button NextButton
        {
            get
            {
                return nextButton;
            }
        }

        #endregion

        #region Public Methods

        public void SetTitle(string title)
        {
            titleLabel.Text = title;
        }

        public void SetSubTitle(string title)
        {
            subTitleLabel.Text = title;
        }

        #endregion

        #region Private Methods

        private void ReplaceContentControl(int index)
        {
            if (currentContentControl != null)
            {
            }

            if (index == 0)
            {
                prevButton.Enabled = false;
                nextButton.Enabled = true;
            }
            else if (index == (contentControls.Count - 1))
            {
                prevButton.Enabled = true;
                nextButton.Enabled = false;
            }
            else
            {
                prevButton.Enabled = true;
                nextButton.Enabled = true;
            }

            InstallerControl newContentControl = contentControls[index];
            newContentControl.Dock = DockStyle.Fill;

            titleLabel.Text = newContentControl.Title;
            subTitleLabel.Text = newContentControl.SubTitle;

            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(newContentControl);

            newContentControl.Open();

            currentContentControl = newContentControl;
        }

        private Image LoadImage(string filename)
        {
            try
            {
                return Image.FromFile(filename);
            }

            catch (IOException)
            {
                return null;
            }
        }

        #endregion

        private void logoPicture_Click(object sender, EventArgs e)
        {
            AsposeManager.RunAsposeHomePage();
        }

        private void titlePanel_Click(object sender, EventArgs e)
        {
            AsposeManager.RunAsposeHomePage();
        }

        private void subTitleLabel_Click(object sender, EventArgs e)
        {
            AsposeManager.RunAsposeHomePage();
        }

        private void titleLabel_Click(object sender, EventArgs e)
        {
            AsposeManager.RunAsposeHomePage();
        }
    }
}