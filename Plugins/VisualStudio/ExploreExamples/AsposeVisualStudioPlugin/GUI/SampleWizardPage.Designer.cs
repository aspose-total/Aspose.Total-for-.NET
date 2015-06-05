namespace AsposeVisualStudioPlugin.GUI
{
    partial class SampleWizardPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SampleWizardPage));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.examplesTree = new System.Windows.Forms.TreeView();
            this.GetComponentsButton = new System.Windows.Forms.Button();
            this.comboBoxComponents = new System.Windows.Forms.ComboBox();
            this.labelComponents = new System.Windows.Forms.Label();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.labelLocation = new System.Windows.Forms.Label();
            this.AbortButton = new System.Windows.Forms.Button();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.toolStripStatusMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder-icon.png");
            this.imageList1.Images.SetKeyName(1, "page_white_csharp.ico");
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.examplesTree);
            this.groupBox1.Location = new System.Drawing.Point(12, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 243);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Examples:";
            // 
            // examplesTree
            // 
            this.examplesTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.examplesTree.ImageIndex = 0;
            this.examplesTree.ImageList = this.imageList1;
            this.examplesTree.Location = new System.Drawing.Point(4, 19);
            this.examplesTree.Name = "examplesTree";
            this.examplesTree.SelectedImageIndex = 0;
            this.examplesTree.Size = new System.Drawing.Size(550, 218);
            this.examplesTree.TabIndex = 0;
            this.examplesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.examplesTree_AfterSelect);
            this.examplesTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.examplesTree_NodeMouseClick);
            this.examplesTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.examplesTree_NodeMouseDoubleClick);
            this.examplesTree.Click += new System.EventHandler(this.examplesTree_Click);
            // 
            // GetComponentsButton
            // 
            this.GetComponentsButton.Location = new System.Drawing.Point(179, 124);
            this.GetComponentsButton.Name = "GetComponentsButton";
            this.GetComponentsButton.Size = new System.Drawing.Size(57, 23);
            this.GetComponentsButton.TabIndex = 15;
            this.GetComponentsButton.Text = "&Get APIs";
            this.GetComponentsButton.UseVisualStyleBackColor = true;
            this.GetComponentsButton.Click += new System.EventHandler(this.GetComponentsButton_Click);
            // 
            // comboBoxComponents
            // 
            this.comboBoxComponents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComponents.FormattingEnabled = true;
            this.comboBoxComponents.Location = new System.Drawing.Point(16, 125);
            this.comboBoxComponents.Name = "comboBoxComponents";
            this.comboBoxComponents.Size = new System.Drawing.Size(157, 21);
            this.comboBoxComponents.TabIndex = 13;
            this.comboBoxComponents.SelectedIndexChanged += new System.EventHandler(this.comboBoxComponents_SelectedIndexChanged);
            // 
            // labelComponents
            // 
            this.labelComponents.AutoSize = true;
            this.labelComponents.Location = new System.Drawing.Point(13, 112);
            this.labelComponents.Name = "labelComponents";
            this.labelComponents.Size = new System.Drawing.Size(60, 13);
            this.labelComponents.TabIndex = 12;
            this.labelComponents.Text = ".NET APIs:";
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(270, 128);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.ReadOnly = true;
            this.textBoxLocation.Size = new System.Drawing.Size(209, 20);
            this.textBoxLocation.TabIndex = 11;
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(267, 114);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(54, 13);
            this.labelLocation.TabIndex = 10;
            this.labelLocation.Text = "Location: ";
            // 
            // AbortButton
            // 
            this.AbortButton.Location = new System.Drawing.Point(485, 417);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(75, 23);
            this.AbortButton.TabIndex = 18;
            this.AbortButton.Text = "Abort";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // ContinueButton
            // 
            this.ContinueButton.Location = new System.Drawing.Point(372, 417);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(75, 23);
            this.ContinueButton.TabIndex = 17;
            this.ContinueButton.Text = "Continue";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 404);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 1);
            this.panel1.TabIndex = 16;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 450);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(286, 13);
            this.progressBar.TabIndex = 4;
            this.progressBar.Visible = false;
            // 
            // toolStripStatusMessage
            // 
            this.toolStripStatusMessage.AutoSize = true;
            this.toolStripStatusMessage.Location = new System.Drawing.Point(8, 87);
            this.toolStripStatusMessage.Name = "toolStripStatusMessage";
            this.toolStripStatusMessage.Size = new System.Drawing.Size(203, 13);
            this.toolStripStatusMessage.TabIndex = 19;
            this.toolStripStatusMessage.Text = "Please select an API to view its Examples";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackgroundImage = global::AsposeVisualStudioPlugin.Properties.Resources.long_banner;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 584F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(584, 76);
            this.tableLayoutPanel2.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 74);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select an API to view Examples";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(485, 126);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(71, 23);
            this.BrowseButton.TabIndex = 21;
            this.BrowseButton.Text = "&Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(426, 87);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(130, 13);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 22;
            this.progressBar1.Visible = false;
            // 
            // SampleWizardPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.textBoxLocation);
            this.Controls.Add(this.toolStripStatusMessage);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GetComponentsButton);
            this.Controls.Add(this.comboBoxComponents);
            this.Controls.Add(this.labelComponents);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(590, 490);
            this.MinimizeBox = false;
            this.Name = "SampleWizardPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aspose Visual Studio Plugin";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView examplesTree;
        private System.Windows.Forms.Button GetComponentsButton;
        private System.Windows.Forms.ComboBox comboBoxComponents;
        private System.Windows.Forms.Label labelComponents;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Button ContinueButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label toolStripStatusMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}