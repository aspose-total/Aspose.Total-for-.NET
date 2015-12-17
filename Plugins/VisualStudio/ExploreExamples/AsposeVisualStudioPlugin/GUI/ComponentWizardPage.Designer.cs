using AsposeVisualStudioPlugin.Core;
namespace AsposeVisualStudioPlugin.GUI
{
    partial class ComponentWizardPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComponentWizardPage));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxComponentsSelection = new System.Windows.Forms.GroupBox();
            this.checkBoxAspose3D = new System.Windows.Forms.CheckBox();
            this.checkBoxAsposeNote = new System.Windows.Forms.CheckBox();
            this.checkBoxAsposeImaging = new System.Windows.Forms.CheckBox();
            this.checkBoxAsposeOCR = new System.Windows.Forms.CheckBox();
            this.checkBoxAsposeEmail = new System.Windows.Forms.CheckBox();
            this.checkBoxAsposeTasks = new System.Windows.Forms.CheckBox();
            this.checkBoxAsposeBarCode = new System.Windows.Forms.CheckBox();
            this.checkBoxAsposeDiagram = new System.Windows.Forms.CheckBox();
            this.checkBoxAsposeSlides = new System.Windows.Forms.CheckBox();
            this.checkBoxAsposePdf = new System.Windows.Forms.CheckBox();
            this.checkBoxAsposeWords = new System.Windows.Forms.CheckBox();
            this.checkBoxAsposeCells = new System.Windows.Forms.CheckBox();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.groupBoxCommonUses = new System.Windows.Forms.GroupBox();
            this.linkLabelAspose = new System.Windows.Forms.LinkLabel();
            this.labelCommonUses = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.toolStripStatusMessage = new System.Windows.Forms.Label();
            this.AbortButton = new System.Windows.Forms.Button();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxComponentsSelection.SuspendLayout();
            this.groupBoxCommonUses.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(584, 76);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 74);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Aspose .NET APIs";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxComponentsSelection
            // 
            this.groupBoxComponentsSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxComponentsSelection.Controls.Add(this.checkBoxAspose3D);
            this.groupBoxComponentsSelection.Controls.Add(this.checkBoxAsposeNote);
            this.groupBoxComponentsSelection.Controls.Add(this.checkBoxAsposeImaging);
            this.groupBoxComponentsSelection.Controls.Add(this.checkBoxAsposeOCR);
            this.groupBoxComponentsSelection.Controls.Add(this.checkBoxAsposeEmail);
            this.groupBoxComponentsSelection.Controls.Add(this.checkBoxAsposeTasks);
            this.groupBoxComponentsSelection.Controls.Add(this.checkBoxAsposeBarCode);
            this.groupBoxComponentsSelection.Controls.Add(this.checkBoxAsposeDiagram);
            this.groupBoxComponentsSelection.Controls.Add(this.checkBoxAsposeSlides);
            this.groupBoxComponentsSelection.Controls.Add(this.checkBoxAsposePdf);
            this.groupBoxComponentsSelection.Controls.Add(this.checkBoxAsposeWords);
            this.groupBoxComponentsSelection.Controls.Add(this.checkBoxAsposeCells);
            this.groupBoxComponentsSelection.Controls.Add(this.checkBoxSelectAll);
            this.groupBoxComponentsSelection.Location = new System.Drawing.Point(11, 136);
            this.groupBoxComponentsSelection.Name = "groupBoxComponentsSelection";
            this.groupBoxComponentsSelection.Size = new System.Drawing.Size(184, 277);
            this.groupBoxComponentsSelection.TabIndex = 0;
            this.groupBoxComponentsSelection.TabStop = false;
            this.groupBoxComponentsSelection.Text = "Select Components:";
            // 
            // checkBoxAspose3D
            // 
            this.checkBoxAspose3D.AutoSize = true;
            this.checkBoxAspose3D.FlatAppearance.BorderSize = 0;
            this.checkBoxAspose3D.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.checkBoxAspose3D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAspose3D.Location = new System.Drawing.Point(28, 253);
            this.checkBoxAspose3D.Name = "checkBoxAspose3D";
            this.checkBoxAspose3D.Size = new System.Drawing.Size(75, 17);
            this.checkBoxAspose3D.TabIndex = 12;
            this.checkBoxAspose3D.Text = "Aspose.3D";
            this.checkBoxAspose3D.UseVisualStyleBackColor = true;
            this.checkBoxAspose3D.CheckedChanged += new System.EventHandler(this.checkBoxAspose3D_CheckedChanged);
            // 
            // checkBoxAsposeNote
            // 
            this.checkBoxAsposeNote.AutoSize = true;
            this.checkBoxAsposeNote.FlatAppearance.BorderSize = 0;
            this.checkBoxAsposeNote.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.checkBoxAsposeNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAsposeNote.Location = new System.Drawing.Point(28, 233);
            this.checkBoxAsposeNote.Name = "checkBoxAsposeNote";
            this.checkBoxAsposeNote.Size = new System.Drawing.Size(84, 17);
            this.checkBoxAsposeNote.TabIndex = 11;
            this.checkBoxAsposeNote.Text = "Aspose.Note";
            this.checkBoxAsposeNote.UseVisualStyleBackColor = true;
            this.checkBoxAsposeNote.CheckedChanged += new System.EventHandler(this.checkBoxAsposeNote_CheckedChanged);
            // 
            // checkBoxAsposeImaging
            // 
            this.checkBoxAsposeImaging.AutoSize = true;
            this.checkBoxAsposeImaging.FlatAppearance.BorderSize = 0;
            this.checkBoxAsposeImaging.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.checkBoxAsposeImaging.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAsposeImaging.Location = new System.Drawing.Point(28, 213);
            this.checkBoxAsposeImaging.Name = "checkBoxAsposeImaging";
            this.checkBoxAsposeImaging.Size = new System.Drawing.Size(98, 17);
            this.checkBoxAsposeImaging.TabIndex = 10;
            this.checkBoxAsposeImaging.Text = "Aspose.Imaging";
            this.checkBoxAsposeImaging.UseVisualStyleBackColor = true;
            this.checkBoxAsposeImaging.CheckedChanged += new System.EventHandler(this.checkBoxAsposeImaging_CheckedChanged);
            // 
            // checkBoxAsposeOCR
            // 
            this.checkBoxAsposeOCR.AutoSize = true;
            this.checkBoxAsposeOCR.FlatAppearance.BorderSize = 0;
            this.checkBoxAsposeOCR.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.checkBoxAsposeOCR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAsposeOCR.Location = new System.Drawing.Point(28, 194);
            this.checkBoxAsposeOCR.Name = "checkBoxAsposeOCR";
            this.checkBoxAsposeOCR.Size = new System.Drawing.Size(84, 17);
            this.checkBoxAsposeOCR.TabIndex = 9;
            this.checkBoxAsposeOCR.Text = "Aspose.OCR";
            this.checkBoxAsposeOCR.UseVisualStyleBackColor = true;
            this.checkBoxAsposeOCR.CheckedChanged += new System.EventHandler(this.checkBoxAsposeOCR_CheckedChanged);
            // 
            // checkBoxAsposeEmail
            // 
            this.checkBoxAsposeEmail.AutoSize = true;
            this.checkBoxAsposeEmail.FlatAppearance.BorderSize = 0;
            this.checkBoxAsposeEmail.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.checkBoxAsposeEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAsposeEmail.Location = new System.Drawing.Point(28, 175);
            this.checkBoxAsposeEmail.Name = "checkBoxAsposeEmail";
            this.checkBoxAsposeEmail.Size = new System.Drawing.Size(86, 17);
            this.checkBoxAsposeEmail.TabIndex = 8;
            this.checkBoxAsposeEmail.Text = "Aspose.Email";
            this.checkBoxAsposeEmail.UseVisualStyleBackColor = true;
            this.checkBoxAsposeEmail.CheckedChanged += new System.EventHandler(this.checkBoxAsposeEmail_CheckedChanged);
            // 
            // checkBoxAsposeTasks
            // 
            this.checkBoxAsposeTasks.AutoSize = true;
            this.checkBoxAsposeTasks.FlatAppearance.BorderSize = 0;
            this.checkBoxAsposeTasks.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.checkBoxAsposeTasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAsposeTasks.Location = new System.Drawing.Point(28, 155);
            this.checkBoxAsposeTasks.Name = "checkBoxAsposeTasks";
            this.checkBoxAsposeTasks.Size = new System.Drawing.Size(90, 17);
            this.checkBoxAsposeTasks.TabIndex = 7;
            this.checkBoxAsposeTasks.Text = "Aspose.Tasks";
            this.checkBoxAsposeTasks.UseVisualStyleBackColor = true;
            this.checkBoxAsposeTasks.CheckedChanged += new System.EventHandler(this.checkBoxAsposeMetafiles_CheckedChanged);
            // 
            // checkBoxAsposeBarCode
            // 
            this.checkBoxAsposeBarCode.AutoSize = true;
            this.checkBoxAsposeBarCode.FlatAppearance.BorderSize = 0;
            this.checkBoxAsposeBarCode.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.checkBoxAsposeBarCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAsposeBarCode.Location = new System.Drawing.Point(28, 136);
            this.checkBoxAsposeBarCode.Name = "checkBoxAsposeBarCode";
            this.checkBoxAsposeBarCode.Size = new System.Drawing.Size(102, 17);
            this.checkBoxAsposeBarCode.TabIndex = 6;
            this.checkBoxAsposeBarCode.Text = "Aspose.BarCode";
            this.checkBoxAsposeBarCode.UseVisualStyleBackColor = true;
            this.checkBoxAsposeBarCode.CheckedChanged += new System.EventHandler(this.checkBoxAsposeBarCode_CheckedChanged);
            // 
            // checkBoxAsposeDiagram
            // 
            this.checkBoxAsposeDiagram.AutoSize = true;
            this.checkBoxAsposeDiagram.FlatAppearance.BorderSize = 0;
            this.checkBoxAsposeDiagram.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.checkBoxAsposeDiagram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAsposeDiagram.Location = new System.Drawing.Point(28, 117);
            this.checkBoxAsposeDiagram.Name = "checkBoxAsposeDiagram";
            this.checkBoxAsposeDiagram.Size = new System.Drawing.Size(100, 17);
            this.checkBoxAsposeDiagram.TabIndex = 5;
            this.checkBoxAsposeDiagram.Text = "Aspose.Diagram";
            this.checkBoxAsposeDiagram.UseVisualStyleBackColor = true;
            this.checkBoxAsposeDiagram.CheckedChanged += new System.EventHandler(this.checkBoxAsposePdfKit_CheckedChanged);
            // 
            // checkBoxAsposeSlides
            // 
            this.checkBoxAsposeSlides.AutoSize = true;
            this.checkBoxAsposeSlides.FlatAppearance.BorderSize = 0;
            this.checkBoxAsposeSlides.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.checkBoxAsposeSlides.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAsposeSlides.Location = new System.Drawing.Point(28, 98);
            this.checkBoxAsposeSlides.Name = "checkBoxAsposeSlides";
            this.checkBoxAsposeSlides.Size = new System.Drawing.Size(89, 17);
            this.checkBoxAsposeSlides.TabIndex = 4;
            this.checkBoxAsposeSlides.Text = "Aspose.Slides";
            this.checkBoxAsposeSlides.UseVisualStyleBackColor = true;
            this.checkBoxAsposeSlides.CheckedChanged += new System.EventHandler(this.checkBoxAsposeSlides_CheckedChanged);
            // 
            // checkBoxAsposePdf
            // 
            this.checkBoxAsposePdf.AutoSize = true;
            this.checkBoxAsposePdf.FlatAppearance.BorderSize = 0;
            this.checkBoxAsposePdf.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.checkBoxAsposePdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAsposePdf.Location = new System.Drawing.Point(28, 79);
            this.checkBoxAsposePdf.Name = "checkBoxAsposePdf";
            this.checkBoxAsposePdf.Size = new System.Drawing.Size(77, 17);
            this.checkBoxAsposePdf.TabIndex = 3;
            this.checkBoxAsposePdf.Text = "Aspose.Pdf";
            this.checkBoxAsposePdf.UseVisualStyleBackColor = true;
            this.checkBoxAsposePdf.CheckedChanged += new System.EventHandler(this.checkBoxAsposePdf_CheckedChanged);
            // 
            // checkBoxAsposeWords
            // 
            this.checkBoxAsposeWords.AutoSize = true;
            this.checkBoxAsposeWords.FlatAppearance.BorderSize = 0;
            this.checkBoxAsposeWords.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.checkBoxAsposeWords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAsposeWords.Location = new System.Drawing.Point(28, 60);
            this.checkBoxAsposeWords.Name = "checkBoxAsposeWords";
            this.checkBoxAsposeWords.Size = new System.Drawing.Size(92, 17);
            this.checkBoxAsposeWords.TabIndex = 2;
            this.checkBoxAsposeWords.Text = "Aspose.Words";
            this.checkBoxAsposeWords.UseVisualStyleBackColor = true;
            this.checkBoxAsposeWords.CheckedChanged += new System.EventHandler(this.checkBoxAsposeWords_CheckedChanged);
            // 
            // checkBoxAsposeCells
            // 
            this.checkBoxAsposeCells.AutoSize = true;
            this.checkBoxAsposeCells.FlatAppearance.BorderSize = 0;
            this.checkBoxAsposeCells.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.checkBoxAsposeCells.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAsposeCells.Location = new System.Drawing.Point(28, 43);
            this.checkBoxAsposeCells.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxAsposeCells.Name = "checkBoxAsposeCells";
            this.checkBoxAsposeCells.Size = new System.Drawing.Size(83, 17);
            this.checkBoxAsposeCells.TabIndex = 1;
            this.checkBoxAsposeCells.Text = "Aspose.Cells";
            this.checkBoxAsposeCells.UseVisualStyleBackColor = true;
            this.checkBoxAsposeCells.CheckedChanged += new System.EventHandler(this.checkBoxAsposeCells_CheckedChanged);
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.FlatAppearance.BorderSize = 0;
            this.checkBoxSelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.checkBoxSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(11, 24);
            this.checkBoxSelectAll.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(67, 17);
            this.checkBoxSelectAll.TabIndex = 0;
            this.checkBoxSelectAll.Text = "Select All";
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.checkBoxSelectAll_CheckedChanged);
            // 
            // groupBoxCommonUses
            // 
            this.groupBoxCommonUses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCommonUses.Controls.Add(this.linkLabelAspose);
            this.groupBoxCommonUses.Controls.Add(this.labelCommonUses);
            this.groupBoxCommonUses.Location = new System.Drawing.Point(218, 136);
            this.groupBoxCommonUses.Name = "groupBoxCommonUses";
            this.groupBoxCommonUses.Size = new System.Drawing.Size(354, 275);
            this.groupBoxCommonUses.TabIndex = 1;
            this.groupBoxCommonUses.TabStop = false;
            this.groupBoxCommonUses.Text = "Common Uses:";
            // 
            // linkLabelAspose
            // 
            this.linkLabelAspose.AutoSize = true;
            this.linkLabelAspose.LinkArea = new System.Windows.Forms.LinkArea(6, 6);
            this.linkLabelAspose.Location = new System.Drawing.Point(12, 249);
            this.linkLabelAspose.Name = "linkLabelAspose";
            this.linkLabelAspose.Size = new System.Drawing.Size(151, 17);
            this.linkLabelAspose.TabIndex = 1;
            this.linkLabelAspose.TabStop = true;
            this.linkLabelAspose.Text = "Visit Aspose for more details.";
            this.linkLabelAspose.UseCompatibleTextRendering = true;
            this.linkLabelAspose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAspose_LinkClicked);
            // 
            // labelCommonUses
            // 
            this.labelCommonUses.AutoSize = true;
            this.labelCommonUses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelCommonUses.Location = new System.Drawing.Point(7, 20);
            this.labelCommonUses.Name = "labelCommonUses";
            this.labelCommonUses.Size = new System.Drawing.Size(334, 208);
            this.labelCommonUses.TabIndex = 0;
            this.labelCommonUses.Text = resources.GetString("labelCommonUses.Text");
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(326, 102);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(234, 13);
            this.progressBar.TabIndex = 3;
            // 
            // toolStripStatusMessage
            // 
            this.toolStripStatusMessage.AutoSize = true;
            this.toolStripStatusMessage.Location = new System.Drawing.Point(323, 86);
            this.toolStripStatusMessage.Name = "toolStripStatusMessage";
            this.toolStripStatusMessage.Size = new System.Drawing.Size(85, 13);
            this.toolStripStatusMessage.TabIndex = 4;
            this.toolStripStatusMessage.Text = "fetching API info";
            // 
            // AbortButton
            // 
            this.AbortButton.Location = new System.Drawing.Point(485, 434);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(75, 23);
            this.AbortButton.TabIndex = 7;
            this.AbortButton.Text = "Abort";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // ContinueButton
            // 
            this.ContinueButton.Location = new System.Drawing.Point(372, 434);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(75, 23);
            this.ContinueButton.TabIndex = 6;
            this.ContinueButton.Text = "Continue";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 418);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 1);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Please select one or more products to continue";
            // 
            // ComponentWizardPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 472);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.toolStripStatusMessage);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBoxCommonUses);
            this.Controls.Add(this.groupBoxComponentsSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(590, 500);
            this.MinimizeBox = false;
            this.Name = "ComponentWizardPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aspose Visual Studio Plugin";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBoxComponentsSelection.ResumeLayout(false);
            this.groupBoxComponentsSelection.PerformLayout();
            this.groupBoxCommonUses.ResumeLayout(false);
            this.groupBoxCommonUses.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxComponentsSelection;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;
        private System.Windows.Forms.CheckBox checkBoxAsposeSlides;
        private System.Windows.Forms.CheckBox checkBoxAsposePdf;
        private System.Windows.Forms.CheckBox checkBoxAsposeWords;
        private System.Windows.Forms.CheckBox checkBoxAsposeCells;
        private System.Windows.Forms.CheckBox checkBoxAsposeImaging;
        private System.Windows.Forms.CheckBox checkBoxAsposeOCR;
        private System.Windows.Forms.CheckBox checkBoxAsposeEmail;
        private System.Windows.Forms.CheckBox checkBoxAsposeTasks;
        private System.Windows.Forms.CheckBox checkBoxAsposeBarCode;
        private System.Windows.Forms.CheckBox checkBoxAsposeDiagram;
        private System.Windows.Forms.GroupBox groupBoxCommonUses;
        private System.Windows.Forms.Label labelCommonUses;
        private System.Windows.Forms.LinkLabel linkLabelAspose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label toolStripStatusMessage;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Button ContinueButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxAsposeNote;
        private System.Windows.Forms.CheckBox checkBoxAspose3D;
    }
}