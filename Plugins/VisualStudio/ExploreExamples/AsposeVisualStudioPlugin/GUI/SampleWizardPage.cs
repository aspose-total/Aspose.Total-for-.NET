// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsposeVisualStudioPlugin.Core;
using System.IO;
using System.Threading;
using System.Xml;
using AsposeVisualStudioPlugin.XML;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Xml.Linq;
using EnvDTE80;

namespace AsposeVisualStudioPlugin.GUI
{
    public partial class SampleWizardPage : Form
    {
        private bool examplesNotAvailable = false;
        private bool downloadTaskCompleted = false;
        private DTE2 _application = null;
        CancellationTokenSource cancelToken = new CancellationTokenSource();
        TreeNode selectedNode = null;

        Task progressTask;//= new Task(delegate { progressDisplayTask(); });
        //Task repoUpdateWorker2 = new Task(delegate { this.progressDisplayTask(); });
        public SampleWizardPage()
        {
            InitializeComponent();
            AsposeComponents components = new AsposeComponents();
            fillComponentsCombo();
        }

        private string GetExamplesRootPath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Aspose";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        public SampleWizardPage(DTE2 application)
        {
            _application = application;
            InitializeComponent();
            AsposeComponents components = new AsposeComponents();
            fillComponentsCombo();
            validateForm();
            textBoxLocation.Text = GetExamplesRootPath();
        }

        private void fillComponentsCombo()
        {
            comboBoxComponents.Items.Clear();
            int addedComponentsCount = 0;
            string libPath = AsposeComponentsManager.getLibaryDownloadPath();
            foreach (AsposeComponent component in AsposeComponents.list.Values)
            {
                if (Directory.Exists(Path.Combine(libPath, component.Name)))
                {
                    comboBoxComponents.Items.Add(component.Name);
                    addedComponentsCount++;
                }
            }

            if (!string.IsNullOrEmpty(GlobalData.SelectedComponent))
            {
                comboBoxComponents.SelectedItem = GlobalData.SelectedComponent;
                GlobalData.SelectedComponent = string.Empty;
            }

            if (addedComponentsCount == 0)
            {
                ComponentWizardPage components = new ComponentWizardPage();
                components.FormClosed += new FormClosedEventHandler(components_FormClosed);
                components.ShowDialog();

                if (!GlobalData.isComponentFormAborted) fillComponentsCombo();
            }
        }

        private void components_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (GlobalData.isComponentFormAborted)
                this.Close();
        }

        public DialogResult showMessage(string title, string message, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(message, title, buttons, icon);
        }

        private bool validateForm()
        {
            if (!isValidNodeSelected())
            {
                if (examplesTree.Nodes.Count > 0)
                    setErrorMessage("Please double click an Example below to open it");
                else
                    setErrorMessage("Please select an API to view its Examples");
                return false;
            }

            if (textBoxLocation.Text == "")
            {
                setErrorMessage("Please select location to create project");
                return false;
            }

            clearError();
            return true;
        }

        private bool isValidNodeSelected()
        {
            /*if (examplesTree.SelectedNode != null)
                selectedNode = examplesTree.SelectedNode;*/

            if (selectedNode == null)
                return false;
            TreeNodeData treedata = new TreeNodeData();
            if (selectedNode.Tag == null)
                return false;

            treedata = (TreeNodeData)selectedNode.Tag;
            if (treedata.Example == null)
                return false;

            return true;
        }

        private void setErrorMessage(string message)
        {
            toolStripStatusMessage.Text = message;
            ContinueButton.Enabled = false;
        }

        private void clearError()
        {

            toolStripStatusMessage.Text = "";
            ContinueButton.Enabled = true;
        }

        private void CloneOrCheckOutRepo(AsposeComponent component)
        {
            downloadTaskCompleted = false;
            timer1.Start();
            Task repoUpdateWorker = new Task(delegate { CloneOrCheckOutRepoWorker(component); });
            //repoUpdateWorker.ContinueWith(result => RepositoryUpdateCompleted(), TaskContinuationOptions.OnlyOnRanToCompletion);
            repoUpdateWorker.Start();
            progressTask = new Task(delegate { progressDisplayTask(); });
            progressBar.Enabled = true;
            progressTask.Start();
            ContinueButton.Enabled = false;
            if (GitHelper.isExamplesDefinitionsPresent(component))
            {
                toolStripStatusMessage.Text = "Please wait while the Examples are being downloaded...";
            }
            else
            {
                toolStripStatusMessage.Text = "Please wait while the Examples are being downloaded...";
            }
        }

        private void RepositoryUpdateCompleted()
        {
            ContinueButton.Enabled = true;
            toolStripStatusMessage.Text = "";
            //cancelToken.Cancel();
            downloadTaskCompleted = true;
            progressBar.Value = 0;
            populateExamplesTreeReady();
            progressBar1.Visible = false;
        }

        private void progressDisplayTask()
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate() { progressBar1.Visible = true; }));

                //int count = 1;
                //while (true)
                //{
                //    if (downloadTaskCompleted)
                //        break;
                //    if (count < 100)
                //        count++;
                //    else
                //        count = 1;

                //    this.Invoke(new MethodInvoker(delegate() { progressBar.Value = count; }));
                //}
            }
            catch (Exception)
            {
            }
        }

        private void CloneOrCheckOutRepoWorker(AsposeComponent component)
        {
            GitHelper.CloneOrCheckOutRepo(component);
            downloadTaskCompleted = true;

        }

        private void checkAndUpdateRepo(AsposeComponent component)
        {
            if (null == component)
                return;
            if (null == component.get_remoteExamplesRepository() || component.RemoteExamplesRepository == string.Empty)
            {
                showMessage("Examples not available", component.get_name() + " - " + Constants.EXAMPLES_NOT_AVAILABLE_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                examplesNotAvailable = true;
                validateForm();
                return;
            }
            else
            {
                examplesNotAvailable = false;
                validateForm();
            }
            // String repoPath;
            if (GitHelper.isExamplesDefinitionsPresent(component))
            {
                CloneOrCheckOutRepo(component);
            }
            else
            {
                DialogResult result = showMessage("Examples download required", component.get_name() + " - " + Constants.EXAMPLES_DOWNLOAD_REQUIRED, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {

                    if (AsposeComponentsManager.isIneternetConnected())
                    {
                        CloneOrCheckOutRepo(component);
                    }
                    else
                        showMessage(Constants.INTERNET_CONNECTION_REQUIRED_MESSAGE_TITLE, component.get_name() + " - " + Constants.EXAMPLES_INTERNET_CONNECTION_REQUIRED_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void populateExamplesTreeReady()
        {
            AsposeComponent component;
            AsposeComponents.list.TryGetValue(comboBoxComponents.Text, out component);
            populateExamplesTree(GitHelper.getExamplesDefinitionsPath(component), component.get_name());
            validateForm();
        }

        private void populateExamplesTree(string examplesDefinitionFile, string componentName)
        {
            if (!File.Exists(examplesDefinitionFile))
            {
                //dispay error message
                return;
            }
            examplesTree.Nodes.Clear();
            TreeNode parentNode = examplesTree.Nodes.Add(componentName);
            TreeNodeData treeNodeData = new TreeNodeData();
            treeNodeData.Path = "";
            parentNode.Tag = treeNodeData;
            XElement data = XElement.Load(examplesDefinitionFile);
            IEnumerable<XElement> folders = from c in data.Elements("Folders") select c;
            parseFoldersTree(folders, parentNode);

            //do same with examples
            IEnumerable<XElement> examples = from c in data.Elements("Examples") select c;
            parseExamplesTree(examples, parentNode);
            parentNode.ExpandAll();

            if (examplesTree.Nodes.Count > 0)
                examplesTree.Nodes[0].EnsureVisible();
        }

        void parseFoldersTree(IEnumerable<XElement> rootFoldersList, TreeNode parentNode)
        {
            foreach (XElement folders_sub in rootFoldersList)
            {
                IEnumerable<XElement> folderlist = from c in folders_sub.Elements("Folder") select c;
                foreach (XElement folder in folderlist)
                {
                    var serializer = new XmlSerializer(typeof(Folder));
                    Folder folderObj = (Folder)serializer.Deserialize(folder.CreateReader());

                    TreeNode childNode = parentNode.Nodes.Add(folderObj.Title);
                    TreeNodeData treeNodeData = new TreeNodeData();
                    treeNodeData.Path = Path.Combine(((TreeNodeData)(parentNode.Tag)).Path, folderObj.FolderName);
                    childNode.Tag = treeNodeData;
                    childNode.ImageIndex = 0;
                    IEnumerable<XElement> examples_list2 = from c in folder.Elements("Examples") select c;
                    parseExamplesTree(examples_list2, childNode);

                    IEnumerable<XElement> folders_list2 = from c in folder.Elements("Folders") select c;
                    parseFoldersTree(folders_list2, childNode);
                }

            }
        }

        void parseExamplesTree(IEnumerable<XElement> rootExamplesList, TreeNode parentNode)
        {
            foreach (XElement examples_sub in rootExamplesList)
            {
                IEnumerable<XElement> exampleList = from c in examples_sub.Elements("Example") select c;
                foreach (XElement example in exampleList)
                {
                    var serializer = new XmlSerializer(typeof(Example));
                    Example exampleObj = (Example)serializer.Deserialize(example.CreateReader());

                    TreeNode childNode = parentNode.Nodes.Add(exampleObj.Title);
                    TreeNodeData treeNodeData = new TreeNodeData();
                    treeNodeData.Path = Path.Combine(((TreeNodeData)(parentNode.Tag)).Path, exampleObj.FolderName);
                    treeNodeData.Example = exampleObj;
                    childNode.Tag = treeNodeData;
                    childNode.ImageIndex = 1;
                    childNode.SelectedImageIndex = 1;
                    IEnumerable<XElement> examples_list2 = from c in example.Elements("Examples") select c;
                    parseExamplesTree(examples_list2, childNode);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (downloadTaskCompleted)
            {
                timer1.Stop();
                RepositoryUpdateCompleted();
            }
        }

        private void examplesTree_Click(object sender, EventArgs e)
        {
            /*selectedNode = examplesTree.SelectedNode;
            validateForm();*/
        }

        private string GetDestinationPath(string destinationRoot, string selectedProject)
        {
            if (!Directory.Exists(destinationRoot))
                Directory.CreateDirectory(destinationRoot);

            string path = destinationRoot + "\\" + Path.GetFileName(selectedProject);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                int index = 1;
                while (Directory.Exists(path + index))
                {
                    index++;
                }
                path = path + index;
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }

            return path;
        }

        bool CopyAndCreateProject()
        {
            AsposeComponent component;
            AsposeComponents.list.TryGetValue(comboBoxComponents.Text, out component);
            TreeNodeData nodeData = (TreeNodeData)selectedNode.Tag;
            string sampleSourcePath = nodeData.Path;
            string repoPath = GitHelper.getLocalRepositoryPath(component);
            string destinationPath = GetDestinationPath(textBoxLocation.Text + "\\" + comboBoxComponents.Text, sampleSourcePath);

            bool isSuccessfull = false;
            try
            {
                CopyFolderContents(Path.Combine(repoPath, sampleSourcePath), destinationPath);
                string dllsRootPath = AsposeComponentsManager.getLibaryDownloadPath();
                string[] dllsPaths = Directory.GetFiles(Path.Combine(dllsRootPath, component.Name), "*.dll");
                for (int i = 0; i < dllsPaths.Length; i++)
                {
                    if (!Directory.Exists(Path.Combine(destinationPath, "Bin")))
                        Directory.CreateDirectory(Path.Combine(destinationPath, "Bin"));
                    File.Copy(dllsPaths[i], Path.Combine(destinationPath, "Bin", Path.GetFileName(dllsPaths[i])), true);
                }

                string[] projectFiles = Directory.GetFiles(Path.Combine(destinationPath, "CSharp"), "*.csproj");
                for (int i = 0; i < projectFiles.Length; i++)
                {
                    UpdatePrjReferenceHintPath(projectFiles[i], component);
                }

                int vsVersion = GetVSVersion();

                if (vsVersion >= 2010) vsVersion = 2010; // Since our examples mostly have 2010 solution files

                string[] solutionFiles = Directory.GetFiles(Path.Combine(destinationPath, "CSharp"), "*.sln");

                try
                {
                    if (solutionFiles.Length > 0)
                    {
                        foreach (string sFile in solutionFiles)
                        {
                            if (sFile.Contains(vsVersion.ToString()))
                            {
                                _application.Solution.Open(sFile);
                                isSuccessfull = true;
                                break;
                            }
                        }

                        if (!isSuccessfull)
                        {
                            System.Diagnostics.Process.Start(solutionFiles[solutionFiles.Count() - 1]);
                            isSuccessfull = true;
                        }
                    }
                    else if (projectFiles.Length > 0)
                    {
                        System.Diagnostics.Process.Start(projectFiles[0]);
                        isSuccessfull = true;
                    }
                }
                catch (Exception)
                {
                    if (solutionFiles.Length > 0)
                    {
                        System.Diagnostics.Process.Start(solutionFiles[0]);
                        isSuccessfull = true;
                    }
                    else if (projectFiles.Length > 0)
                    {
                        System.Diagnostics.Process.Start(projectFiles[0]);
                        isSuccessfull = true;
                    }
                }
            }
            catch (Exception)
            { }

            if (!isSuccessfull)
            {
                MessageBox.Show("Oops! We are unable to open the example project. Please open it manually from " + destinationPath);
                return false;
            }

            return true;
        }

        private int GetVSVersion()
        {
            switch (_application.Version)
            {
                case "11.0":
                    return 2012;
                case "10.0":
                    return 2010;
                case "9.0":
                    return 2008;
                case "8.0":
                    return 2005;
            }
            return 2003;
        }

        private void UpdatePrjReferenceHintPath(string projectFilePath, AsposeComponent component)
        {
            if (!File.Exists(projectFilePath))
                return;

            XmlDocument xdDoc = new XmlDocument();
            xdDoc.Load(projectFilePath);

            XmlNamespaceManager xnManager =
             new XmlNamespaceManager(xdDoc.NameTable);
            xnManager.AddNamespace("tu",
             "http://schemas.microsoft.com/developer/msbuild/2003");

            XmlNode xnRoot = xdDoc.DocumentElement;
            XmlNodeList xnlPages = xnRoot.SelectNodes("//tu:ItemGroup", xnManager);
            foreach (XmlNode node in xnlPages)
            {
                XmlNodeList nodelist = node.SelectNodes("//tu:HintPath", xnManager);
                foreach (XmlNode nd in nodelist)
                {
                    string innter = nd.InnerText;
                    nd.InnerText = "..\\Bin\\" + component.Name + ".dll";
                }
            }
            xdDoc.Save(projectFilePath);
        }

        private bool CopyFolderContents(string SourcePath, string DestinationPath)
        {
            SourcePath = SourcePath.EndsWith(@"\") ? SourcePath : SourcePath + @"\";
            DestinationPath = DestinationPath.EndsWith(@"\") ? DestinationPath : DestinationPath + @"\";

            try
            {
                if (Directory.Exists(SourcePath))
                {
                    if (Directory.Exists(DestinationPath) == false)
                    {
                        Directory.CreateDirectory(DestinationPath);
                    }

                    foreach (string files in Directory.GetFiles(SourcePath))
                    {
                        FileInfo fileInfo = new FileInfo(files);
                        fileInfo.CopyTo(string.Format(@"{0}\{1}", DestinationPath, fileInfo.Name), true);
                    }

                    foreach (string drs in Directory.GetDirectories(SourcePath))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(drs);
                        if (CopyFolderContents(drs, DestinationPath + directoryInfo.Name) == false)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void buttonGetComponents_Click(object sender, EventArgs e)
        {

        }

        private void examplesTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            /*selectedNode = examplesTree.SelectedNode;
            validateForm();*/
        }

        private void examplesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedNode = examplesTree.SelectedNode;
            if (isValidNodeSelected())
            {
                ContinueButton.Enabled = true;
            }
            else
            {
                ContinueButton.Enabled = false;
            }
        }

        private void examplesTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (isValidNodeSelected())
            {
                if (CopyAndCreateProject())
                    Close();
            }
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (CopyAndCreateProject())
                Close();
        }

        private void comboBoxComponents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxComponents.Text == "")
                return;
            AsposeComponent component;
            AsposeComponents.list.TryGetValue(comboBoxComponents.Text, out component);

            checkAndUpdateRepo(component);

        }

        private void GetComponentsButton_Click(object sender, EventArgs e)
        {
            GlobalData.isAutoOpened = false;
            ComponentWizardPage wizardpage = new ComponentWizardPage();
            wizardpage.ShowDialog();
            fillComponentsCombo();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialog1.ShowDialog())
            {
                textBoxLocation.Text = folderBrowserDialog1.SelectedPath;
                validateForm();
            }
        }

    }
}
