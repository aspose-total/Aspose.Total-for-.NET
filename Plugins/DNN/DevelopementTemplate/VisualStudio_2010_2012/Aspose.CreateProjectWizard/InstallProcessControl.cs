// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Security;
using Aspose.CreateProjectWizard.Library;
using System.Net;
using Aspose.CreateProjectWizard.com.aspose.community;

namespace Aspose.CreateProjectWizard
{
    public partial class InstallProcessControl : InstallerControl
    {
        public InstallProcessControl()
        {
            InitializeComponent();

            this.Load += new EventHandler(InstallProcessControl_Load);

            descriptionLabel.Text = string.Empty;
            //NoOfTasksCompletedLabel.Text = string.Empty;
        }

        private void InstallProcessControl_Load(object sender, EventArgs e)
        {
            Form.SetTitle("Aspose DNN Project");
            Form.SetSubTitle(ApplicationSettings.FormatString("Thank you for your patience while we configure your preferences"));

            Form.PrevButton.Enabled = false;
            Form.NextButton.Enabled = false;
        }


        protected internal override void RequestCancel()
        {
            Form.AbortButton.Enabled = false;
        }

        protected internal override void Open()
        {
            if (GlobalData.SelectedProductsList.Count > 0)
            {
                if (CheckConnectivity())
                {
                    GlobalData.backgroundWorker = new BackgroundWorker();
                    GlobalData.backgroundWorker.WorkerReportsProgress = true;
                    GlobalData.backgroundWorker.WorkerSupportsCancellation = true;

                    GlobalData.backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
                    GlobalData.backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
                    GlobalData.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
                    GlobalData.backgroundWorker.RunWorkerAsync();

                    return;
                }
            }

            UpdateProgress(0, ProgressBarType.CurrentTaskProgress);
            UpdateProgress(0, ProgressBarType.OverAllProgress);
            UpdateText("All operations completed", LabelType.TaskDescription);

            Form.Dispose();
        }

        private DialogResult ShowNotConnectedAlert()
        {
            DialogResult result = MessageBox.Show("It seems there is an error with your internet connection. This might be due to various reasons. Please check your cables, internet and router settings and retry. If this does not help please check your proxy settings.", "Connection Problem", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            return result;
        }

        private bool CheckConnectivity()
        {
            if (!AsposeManager.IsInternetConnected)
            {
                DialogResult result = ShowNotConnectedAlert();
                if (result == DialogResult.Cancel) return false;

                while (result == DialogResult.Retry)
                {
                    if (!AsposeManager.IsInternetConnected)
                    {
                        result = ShowNotConnectedAlert();
                        if (result == DialogResult.Cancel) return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return true;
        }


        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (GlobalData.backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                UpdateProgress(1, ProgressBarType.CurrentTaskProgress);
                UpdateProgress(1, ProgressBarType.OverAllProgress);

                int total = GlobalData.SelectedProductsList.Count;

                string taskCompletedText = "{0} of {1} Completed";

                UpdateText(string.Format(taskCompletedText, 0, total), LabelType.NoOfTasksCompleted);

                for (int index = 0; index < GlobalData.SelectedProductsList.Count; index++)
                {
                    UpdateText("Downloading " + GlobalData.SelectedProductsList[index], LabelType.TaskDescription);
                    DownloadFileFromWeb(GlobalData.SelectedProductsList[index]);
                    decimal percentage = ((decimal)(index + 1) / (decimal)GlobalData.SelectedProductsList.Count) * 100;
                    UpdateProgress(Convert.ToInt32(percentage), ProgressBarType.OverAllProgress);

                    UpdateText(string.Format(taskCompletedText, index + 1, total), LabelType.NoOfTasksCompleted);
                }

                UpdateProgress(100, ProgressBarType.CurrentTaskProgress);
                UpdateProgress(100, ProgressBarType.OverAllProgress);
                UpdateText(string.Format(taskCompletedText, total, total), LabelType.NoOfTasksCompleted);

                UpdateText("All operations completed", LabelType.TaskDescription);
            }
            catch (Exception) { }
        }

        private void DownloadFileFromWeb(string productName)
        {
            try
            {
                ProductRelease productRelease = AsposeManager.GetProductReleaseInformation(productName);
                if (productRelease == null)
                {
                    return;
                }

                string downloadURL = productRelease.DownloadLink;
                string downloadFolderRoot = AsposeManager.GetAsposeDownloadFolder(productName);
                GlobalData.backgroundWorker.ReportProgress(1);

                if (AsposeManager.IsReleaseExists(productName, downloadFolderRoot, productRelease.VersionNumber))
                {
                    GlobalData.backgroundWorker.ReportProgress(100);
                    return;
                }

                string downloadedReleasePath = downloadFolderRoot + "\\" + productName.ToLower() + ".zip";
                GlobalData.backgroundWorker.ReportProgress(1);

                Uri url = new Uri(downloadURL);
                string sFileName = Path.GetFileName(url.LocalPath);

                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();

                response.Close();
                // gets the size of the file in bytes
                long iSize = response.ContentLength;

                // keeps track of the total bytes downloaded so we can update the progress bar
                long iRunningByteTotal = 0;
                WebClient client = new WebClient();
                Stream strRemote = client.OpenRead(url);
                FileStream strLocal = new FileStream(downloadedReleasePath, FileMode.Create, FileAccess.Write, FileShare.None);

                int iByteSize = 0;
                byte[] byteBuffer = new byte[1024];
                while ((iByteSize = strRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                {
                    // write the bytes to the file system at the file path specified
                    strLocal.Write(byteBuffer, 0, iByteSize);
                    iRunningByteTotal += iByteSize;

                    // calculate the progress out of a base "100"
                    double dIndex = (double)(iRunningByteTotal);
                    double dTotal = (double)iSize;
                    double dProgressPercentage = (dIndex / dTotal);
                    int iProgressPercentage = (int)(dProgressPercentage * 98);

                    GlobalData.backgroundWorker.ReportProgress(iProgressPercentage);
                }
                strLocal.Close();
                strRemote.Close();

                AsposeManager.ExtractZipFile(downloadedReleasePath, downloadFolderRoot);
                AsposeManager.SaveReleaseInfo(productName, downloadFolderRoot, productRelease.VersionNumber);
                GlobalData.backgroundWorker.ReportProgress(100);
            }
            catch (Exception) 
            {
                MessageBox.Show("An error occurred while downloading Aspose components. Your module will be created but may not contain all the components you have selected. Please make sure you have an active internet connection and then try creating the project again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Form != null)
                    Form.Dispose();
            }
            
            GlobalData.backgroundWorker.ReportProgress(100);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
                currentTaskProgressBar.Value = 1;
            else
                currentTaskProgressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Form != null)
                Form.Dispose();
        }

        #region Delegates

        private enum LabelType
        {
            NoOfTasksCompleted = 1,
            CurrentlyInstalling = 2,
            OverAllProgress = 3,
            TaskDescription = 4
        }

        private enum ProgressBarType
        {
            CurrentTaskProgress = 1,
            OverAllProgress = 2
        }

        private void UpdateText(string textToUpdate, LabelType labelType)
        {
            if (GlobalData.backgroundWorker != null)
            {
                if (labelType == LabelType.NoOfTasksCompleted)
                {
                    NoOfTasksCompletedLabel.BeginInvoke(new UpdateNoOfTasksCompletedCallback(this.UpdateNoOfTasksCompletedLabel),
                                                        new object[] { textToUpdate });
                }
                else if (labelType == LabelType.CurrentlyInstalling)
                {
                    currentlyInstallingLabel.BeginInvoke(new UpdateCurrentTaskLabelCallback(this.UpdateCurrentTaskLabel),
                                                         new object[] { textToUpdate });
                }
                else if (labelType == LabelType.OverAllProgress)
                {
                    overAllProgressLabel.BeginInvoke(new UpdateTotalLabelCallback(this.UpdateTotalLabel),
                                         new object[] { textToUpdate });
                }
                else if (labelType == LabelType.TaskDescription)
                {
                    descriptionLabel.BeginInvoke(new TaskDescriptionCallback(this.TaskDescriptionLabel),
                                         new object[] { textToUpdate });
                }
            }
        }

        private void UpdateProgress(int progressValue, ProgressBarType progressBarType)
        {
            if (GlobalData.backgroundWorker != null)
            {
                if (progressBarType == ProgressBarType.CurrentTaskProgress)
                {
                    currentTaskProgressBar.BeginInvoke(new UpdateCurrentProgressBarCallback(this.UpdateCurrentProgressBar), new object[] { progressValue });
                }
                else if (progressBarType == ProgressBarType.OverAllProgress)
                {
                    totalProgressBar.BeginInvoke(new UpdateTotalProgressBarCallback(this.UpdateTotalProgressBar), new object[] { progressValue });
                }
            }
        }

        public delegate void TaskDescriptionCallback(string value);
        private void TaskDescriptionLabel(string value)
        {
            descriptionLabel.Text = value;
        }

        public delegate void UpdateNoOfTasksCompletedCallback(string value);
        private void UpdateNoOfTasksCompletedLabel(string value)
        {
            NoOfTasksCompletedLabel.Text = value;
        }

        public delegate void UpdateCurrentTaskLabelCallback(string value);
        private void UpdateCurrentTaskLabel(string value)
        {
            currentlyInstallingLabel.Text = value;
        }

        public delegate void UpdateCurrentProgressBarCallback(int value);
        private void UpdateCurrentProgressBar(int value)
        {
            if (value < 0) value = 0;
            if (value > 100) value = 100;

            currentTaskProgressBar.Value = value;
        }

        public delegate void UpdateTotalLabelCallback(string value);
        private void UpdateTotalLabel(string value)
        {
            overAllProgressLabel.Text = value;
        }

        public delegate void UpdateTotalProgressBarCallback(int value);
        private void UpdateTotalProgressBar(int value)
        {
            if (value < 0) value = 0;
            if (value > 100) value = 100;

            totalProgressBar.Value = value;
        }

        #endregion Delegates

    }
}
