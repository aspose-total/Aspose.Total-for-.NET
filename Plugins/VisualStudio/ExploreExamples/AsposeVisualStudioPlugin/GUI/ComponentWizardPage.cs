// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsposeVisualStudioPlugin.Core;
using AsposeVisualStudioPlugin.com.aspose.community;

namespace AsposeVisualStudioPlugin.GUI
{
    public partial class ComponentWizardPage : Form
    {
        //AsyncDownloadList downloadList = new AsyncDownloadList();
        AsyncDownload asyncActiveDownload = null;
        public ComponentWizardPage()
        {
            InitializeComponent();
            InitializedCustomComponents();
            AsyncDownloadList.list.Clear();
            validateForm();
            AsposeComponents components = new AsposeComponents();
            progressBar.Visible = false;
            toolStripStatusMessage.Visible = false;

            if (!GlobalData.isAutoOpened)
            {
                AbortButton.Text = "Close";
            }
        }

        private void performPostFinish()
        {
            Close();
        }

        private bool performFinish()
        {
            ContinueButton.Enabled = false;
            processComponents();

            if (!AsposeComponentsManager.isIneternetConnected())
            {
                this.showMessage(Constants.INTERNET_CONNECTION_REQUIRED_MESSAGE_TITLE, Constants.INTERNET_CONNECTION_REQUIRED_MESSAGE, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            GlobalData.backgroundWorker = new BackgroundWorker();
            GlobalData.backgroundWorker.WorkerReportsProgress = true;
            GlobalData.backgroundWorker.WorkerSupportsCancellation = true;

            GlobalData.backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            GlobalData.backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            GlobalData.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            GlobalData.backgroundWorker.RunWorkerAsync();

            return true;
        }

        public ProductRelease getProductReleaseInfo(string productName)
        {
            com.aspose.community.AsposeDownloads asposeDn = new AsposeDownloads();
            try
            {
                return asposeDn.GetProductRelease(".NET", productName);
            }
            catch (Exception e)
            {

            }

            return null;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                UpdateProgress(1);
                int total = 10;
                int index = 0;

                AsposeComponentsManager comManager = new AsposeComponentsManager(this);
                foreach (AsposeComponent component in AsposeComponents.list.Values)
                {
                    if (component.is_selected())
                    {
                        GlobalData.SelectedComponent = component.get_name();

                        ProductRelease productRelease = getProductReleaseInfo(component.get_name());
                        component.set_downloadUrl(productRelease.DownloadLink);
                        component.set_downloadFileName(productRelease.FileName);
                        component.set_changeLog(productRelease.ChangeLog);
                        component.set_latestVersion(productRelease.VersionNumber);
                        if (AsposeComponentsManager.libraryAlreadyExists(component.get_downloadFileName()))
                        {
                            component.set_currentVersion(AsposeComponentsManager.readVersion(component));
                            if (AsposeComponentsManager.readVersion(component).CompareTo(component.get_latestVersion()) == 0)
                            {
                                component.set_downloaded(true);
                            }
                            else
                            {
                                AsposeComponentsManager.addToDownloadList(component, component.get_downloadUrl(), component.get_downloadFileName());
                            }
                        }
                        else
                        {
                            AsposeComponentsManager.addToDownloadList(component, component.get_downloadUrl(), component.get_downloadFileName());
                        }
                    }

                    decimal percentage = ((decimal)(index + 1) / (decimal)total) * 100;
                    UpdateProgress(Convert.ToInt32(percentage));
                    
                    index++;
                }

                UpdateProgress(100);
                UpdateText("All operations completed");
            }
            catch (Exception) { }
        }

        private void UpdateText(string textToUpdate)
        {
            if (GlobalData.backgroundWorker != null)
            {
                toolStripStatusMessage.BeginInvoke(new TaskDescriptionCallback(this.TaskDescriptionLabel),
                     new object[] { textToUpdate });               
            }
        }

        private void UpdateProgress(int progressValue)
        {
            if (GlobalData.backgroundWorker != null)
            {
                progressBar.BeginInvoke(new UpdateCurrentProgressBarCallback(this.UpdateCurrentProgressBar), new object[] { progressValue });                
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
                progressBar.Value = 1;
            else
                progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            processDownloadList();
        }


        public delegate void TaskDescriptionCallback(string value);
        private void TaskDescriptionLabel(string value)
        {
            toolStripStatusMessage.Text = value;
        }

        public delegate void UpdateCurrentProgressBarCallback(int value);
        private void UpdateCurrentProgressBar(int value)
        {
            if (value < 0) value = 0;
            if (value > 100) value = 100;

            progressBar.Value = value;
        }


        private void processDownloadList()
        {
            if (AsyncDownloadList.list.Count > 0)
            {
                asyncActiveDownload = AsyncDownloadList.list[0];
                AsyncDownloadList.list.Remove(asyncActiveDownload);
                downloadFileFromWeb(asyncActiveDownload.Url, asyncActiveDownload.LocalPath);
                toolStripStatusMessage.Text = "downloading " + asyncActiveDownload.Component.Name;
            }
            else
                performPostFinish();

        }

        private void downloadFileFromWeb(string sourceURL, string destinationPath)
        {
            progressBar.Visible = true;
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri(sourceURL), destinationPath);
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            progressBar.Value = 100;
            asyncActiveDownload.Component.Downloaded = true;
            AsposeComponentsManager.storeVersion(asyncActiveDownload.Component);
            UnZipDownloadedFile(asyncActiveDownload);
            AbortButton.Enabled = true;
            processDownloadList();
        }

        private void UnZipDownloadedFile(AsyncDownload download)
        {
            AsposeComponentsManager.unZipFile(download.LocalPath, Path.Combine(Path.GetDirectoryName(download.LocalPath), download.Component.Name));
        }

        public DialogResult showMessage(string title, string message, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(message, title, buttons, icon);
        }

        private bool validateForm()
        {
            if (!isComponentSelected())
            {
                setErrorMessage(Constants.IS_COMPONENT_SELECTED);
                return false;
            }

            clearError();
            return true;

        }

        void processComponents()
        {
            if (checkBoxAsposeCells.Checked)
            {
                AsposeComponent component = new AsposeComponent();
                AsposeComponents.list.TryGetValue(Constants.ASPOSE_CELLS, out component);
                component.Selected = true;
            }
            if (checkBoxAsposeWords.Checked)
            {
                AsposeComponent component = new AsposeComponent();
                AsposeComponents.list.TryGetValue(Constants.ASPOSE_WORDS, out component);
                component.Selected = true;
            }
            if (checkBoxAsposePdf.Checked)
            {
                AsposeComponent component = new AsposeComponent();
                AsposeComponents.list.TryGetValue(Constants.ASPOSE_PDF, out component);
                component.Selected = true;
            }
            if (checkBoxAsposeSlides.Checked)
            {
                AsposeComponent component = new AsposeComponent();
                AsposeComponents.list.TryGetValue(Constants.ASPOSE_SLIDES, out component);
                component.Selected = true;
            }
            if (checkBoxAsposeDiagram.Checked)
            {
                AsposeComponent component = new AsposeComponent();
                AsposeComponents.list.TryGetValue(Constants.ASPOSE_DIAGRAM, out component);
                component.Selected = true;
            }
            if (checkBoxAsposeBarCode.Checked)
            {
                AsposeComponent component = new AsposeComponent();
                AsposeComponents.list.TryGetValue(Constants.ASPOSE_BARCODE, out component);
                component.Selected = true;
            }
            if (checkBoxAsposeTasks.Checked)
            {
                AsposeComponent component = new AsposeComponent();
                AsposeComponents.list.TryGetValue(Constants.ASPOSE_TASKS, out component);
                component.Selected = true;
            }
            if (checkBoxAsposeEmail.Checked)
            {
                AsposeComponent component = new AsposeComponent();
                AsposeComponents.list.TryGetValue(Constants.ASPOSE_EMAIL, out component);
                component.Selected = true;
            }
            if (checkBoxAsposeOCR.Checked)
            {
                AsposeComponent component = new AsposeComponent();
                AsposeComponents.list.TryGetValue(Constants.ASPOSE_OCR, out component);
                component.Selected = true;
            }
            if (checkBoxAsposeImaging.Checked)
            {
                AsposeComponent component = new AsposeComponent();
                AsposeComponents.list.TryGetValue(Constants.ASPOSE_IMAGING, out component);
                component.Selected = true;
            }
            if (checkBoxAsposeNote.Checked)
            {
                AsposeComponent component = new AsposeComponent();
                AsposeComponents.list.TryGetValue(Constants.ASPOSE_NOTE, out component);
                component.Selected = true;
            }
            if (checkBoxAspose3D.Checked)
            {
                AsposeComponent component = new AsposeComponent();
                AsposeComponents.list.TryGetValue(Constants.ASPOSE_3D, out component);
                component.Selected = true;
            }
        }



        private void setErrorMessage(string message)
        {
            toolStripStatusMessage.Text = message;
            ContinueButton.Enabled = false;
        }

        private void clearError()
        {
            ContinueButton.Enabled = true;
        }

        private bool isComponentSelected()
        {
            if (checkBoxAsposeCells.Checked || checkBoxAsposeWords.Checked || checkBoxAsposePdf.Checked || checkBoxAsposeSlides.Checked ||
                checkBoxAsposeDiagram.Checked || checkBoxAsposeBarCode.Checked || checkBoxAsposeTasks.Checked || checkBoxAsposeEmail.Checked ||
                checkBoxAsposeOCR.Checked || checkBoxAsposeImaging.Checked || checkBoxAsposeNote.Checked || checkBoxAspose3D.Checked)
                return true;


            return false;
        }

        private void InitializedCustomComponents()
        {
            setTooltip(checkBoxAsposeCells, Constants.ASPOSE_CELLS_FEATURE_TEXT);
            setTooltip(checkBoxAsposeWords, Constants.ASPOSE_WORDS_FEATURE_TEXT);
            setTooltip(checkBoxAsposePdf, Constants.ASPOSE_PDF_FEATURE_TEXT);
            setTooltip(checkBoxAsposeSlides, Constants.ASPOSE_SLIDES_FEATURE_TEXT);
            setTooltip(checkBoxAsposeDiagram, Constants.ASPOSE_DIAGRAM_FEATURE_TEXT);
            setTooltip(checkBoxAsposeBarCode, Constants.ASPOSE_BARCODE_FEATURE_TEXT);
            setTooltip(checkBoxAsposeTasks, Constants.ASPOSE_TASKS_FEATURE_TEXT);
            setTooltip(checkBoxAsposeEmail, Constants.ASPOSE_EMAIL_FEATURE_TEXT);
            setTooltip(checkBoxAsposeOCR, Constants.ASPOSE_OCR_FEATURE_TEXT);
            setTooltip(checkBoxAsposeImaging, Constants.ASPOSE_IMAGING_FEATURE_TEXT);
            setTooltip(checkBoxAsposeNote, Constants.ASPOSE_NOTE_FEATURE_TEXT);
            setTooltip(checkBoxAspose3D, Constants.ASPOSE_3D_FEATURE_TEXT);
        }

        private void setTooltip(Control control, string message)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.ToolTipTitle = control.Text;
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.IsBalloon = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;

            buttonToolTip.ShowAlways = true;

            buttonToolTip.AutoPopDelay = 90000;
            buttonToolTip.InitialDelay = 100;
            buttonToolTip.ReshowDelay = 100;

            buttonToolTip.SetToolTip(control, message);

        }
        #region events
        private void linkLabelAspose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelAspose.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.aspose.com/.net/total-component.aspx");
        }

        #region checkbox_events
        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            setComponentsCheckValue(checkBoxSelectAll.Checked);
            validateForm();
        }

        private void checkBoxAsposeCells_CheckedChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void checkBoxAsposeWords_CheckedChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void checkBoxAsposePdf_CheckedChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void checkBoxAsposeSlides_CheckedChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void checkBoxAsposePdfKit_CheckedChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void checkBoxAsposeBarCode_CheckedChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void checkBoxAsposeMetafiles_CheckedChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void checkBoxAsposeEmail_CheckedChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void checkBoxAsposeOCR_CheckedChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void checkBoxAsposeImaging_CheckedChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void checkBoxAsposeNote_CheckedChanged(object sender, EventArgs e)
        {
            validateForm();
        }
        
        private void checkBoxAspose3D_CheckedChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        #endregion

        #endregion

        void setComponentsCheckValue(bool value)
        {
            checkBoxAsposeCells.Checked = value;
            checkBoxAsposeWords.Checked = value;
            checkBoxAsposePdf.Checked = value;
            checkBoxAsposeSlides.Checked = value;
            checkBoxAsposeDiagram.Checked = value;
            checkBoxAsposeBarCode.Checked = value;
            checkBoxAsposeTasks.Checked = value;
            checkBoxAsposeEmail.Checked = value;
            checkBoxAsposeOCR.Checked = value;
            checkBoxAsposeImaging.Checked = value;
            checkBoxAsposeNote.Checked = value;
            checkBoxAspose3D.Checked = value;
        }

        private void logoButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.aspose.com");
        }

        private void textBoxProjectName_TextChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            progressBar.Value = 1;
            progressBar.Visible = true;
            toolStripStatusMessage.Visible = true;
            label2.Text = "Please wait while we configure you preferences";
            toolStripStatusMessage.Text = "Fetching API info";
            
            GlobalData.isComponentFormAborted = false;
            performFinish();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            if (GlobalData.isAutoOpened)
                GlobalData.isComponentFormAborted = true;
            
            Close();
        }

    }
}
