namespace Aspose.CreateProjectWizard
{
  partial class WelcomeControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.progressMessageLabel = new System.Windows.Forms.Label();
            this.productsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.selectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabelAspose = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressMessageLabel
            // 
            this.progressMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressMessageLabel.Location = new System.Drawing.Point(0, 16);
            this.progressMessageLabel.Name = "progressMessageLabel";
            this.progressMessageLabel.Size = new System.Drawing.Size(472, 26);
            this.progressMessageLabel.TabIndex = 0;
            this.progressMessageLabel.Text = "Please select one or more products to be added to your project";
            // 
            // productsCheckedListBox
            // 
            this.productsCheckedListBox.BackColor = System.Drawing.SystemColors.Control;
            this.productsCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productsCheckedListBox.CheckOnClick = true;
            this.productsCheckedListBox.FormattingEnabled = true;
            this.productsCheckedListBox.Items.AddRange(new object[] {
            "Aspose.Cells",
            "Aspose.Words",
            "Aspose.Pdf",
            "Aspose.Slides",
            "Aspose.BarCode",
            "Aspose.Tasks",
            "Aspose.Diagram",
            "Aspose.OCR",
            "Aspose.Imaging",
            "Aspose.Email",
            "Aspose.Note"});
            this.productsCheckedListBox.Location = new System.Drawing.Point(25, 88);
            this.productsCheckedListBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.productsCheckedListBox.Name = "productsCheckedListBox";
            this.productsCheckedListBox.Size = new System.Drawing.Size(111, 165);
            this.productsCheckedListBox.TabIndex = 1;
            this.productsCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.productsCheckedListBox_SelectedIndexChanged);
            // 
            // selectAllCheckBox
            // 
            this.selectAllCheckBox.AutoSize = true;
            this.selectAllCheckBox.Location = new System.Drawing.Point(12, 22);
            this.selectAllCheckBox.Name = "selectAllCheckBox";
            this.selectAllCheckBox.Size = new System.Drawing.Size(70, 17);
            this.selectAllCheckBox.TabIndex = 2;
            this.selectAllCheckBox.Text = "Select All";
            this.selectAllCheckBox.UseVisualStyleBackColor = true;
            this.selectAllCheckBox.CheckedChanged += new System.EventHandler(this.selectAllCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabelAspose);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(166, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 220);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Common uses";
            // 
            // linkLabelAspose
            // 
            this.linkLabelAspose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabelAspose.AutoSize = true;
            this.linkLabelAspose.LinkArea = new System.Windows.Forms.LinkArea(13, 10);
            this.linkLabelAspose.Location = new System.Drawing.Point(10, 200);
            this.linkLabelAspose.Name = "linkLabelAspose";
            this.linkLabelAspose.Size = new System.Drawing.Size(211, 17);
            this.linkLabelAspose.TabIndex = 3;
            this.linkLabelAspose.TabStop = true;
            this.linkLabelAspose.Text = "Please visit Aspose.com for more details.";
            this.linkLabelAspose.UseCompatibleTextRendering = true;
            this.linkLabelAspose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAspose_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.MaximumSize = new System.Drawing.Size(315, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.selectAllCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(3, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 220);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select component";
            // 
            // WelcomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.productsCheckedListBox);
            this.Controls.Add(this.progressMessageLabel);
            this.Controls.Add(this.groupBox2);
            this.Name = "WelcomeControl";
            this.Size = new System.Drawing.Size(496, 400);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label progressMessageLabel;
    private System.Windows.Forms.CheckedListBox productsCheckedListBox;
    private System.Windows.Forms.CheckBox selectAllCheckBox;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.LinkLabel linkLabelAspose;
  }
}
