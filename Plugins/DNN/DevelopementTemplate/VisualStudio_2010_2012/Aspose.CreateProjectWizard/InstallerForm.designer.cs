// Copyright (c) Aspose 2002-2014. All Rights Reserved.

namespace Aspose.CreateProjectWizard
{
  partial class InstallerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallerForm));
            this.contentPanel = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.topSeparatorPanel = new System.Windows.Forms.Panel();
            this.bottomSeparatorPanel = new System.Windows.Forms.Panel();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.subTitleLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.buttonPanel.SuspendLayout();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 70);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.contentPanel.Size = new System.Drawing.Size(542, 292);
            this.contentPanel.TabIndex = 2;
            // 
            // buttonPanel
            // 
            this.buttonPanel.ColumnCount = 4;
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.buttonPanel.Controls.Add(this.cancelButton, 3, 0);
            this.buttonPanel.Controls.Add(this.prevButton, 1, 0);
            this.buttonPanel.Controls.Add(this.nextButton, 2, 0);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 362);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.RowCount = 1;
            this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonPanel.Size = new System.Drawing.Size(542, 44);
            this.buttonPanel.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cancelButton.Location = new System.Drawing.Point(465, 10);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(10, 10, 10, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(67, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "&Abort";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // prevButton
            // 
            this.prevButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.prevButton.Location = new System.Drawing.Point(297, 10);
            this.prevButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(74, 23);
            this.prevButton.TabIndex = 2;
            this.prevButton.Text = "&Previous";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nextButton.Location = new System.Drawing.Point(377, 10);
            this.nextButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "&Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // topSeparatorPanel
            // 
            this.topSeparatorPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.topSeparatorPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topSeparatorPanel.Location = new System.Drawing.Point(0, 70);
            this.topSeparatorPanel.Name = "topSeparatorPanel";
            this.topSeparatorPanel.Size = new System.Drawing.Size(542, 1);
            this.topSeparatorPanel.TabIndex = 0;
            // 
            // bottomSeparatorPanel
            // 
            this.bottomSeparatorPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.bottomSeparatorPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomSeparatorPanel.Location = new System.Drawing.Point(0, 361);
            this.bottomSeparatorPanel.Name = "bottomSeparatorPanel";
            this.bottomSeparatorPanel.Size = new System.Drawing.Size(542, 1);
            this.bottomSeparatorPanel.TabIndex = 1;
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.White;
            this.titlePanel.Controls.Add(this.logoPicture);
            this.titlePanel.Controls.Add(this.subTitleLabel);
            this.titlePanel.Controls.Add(this.titleLabel);
            this.titlePanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(542, 70);
            this.titlePanel.TabIndex = 1;
            this.titlePanel.Click += new System.EventHandler(this.titlePanel_Click);
            // 
            // logoPicture
            // 
            this.logoPicture.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.logoPicture.BackColor = System.Drawing.Color.Transparent;
            this.logoPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoPicture.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.logoPicture.Location = new System.Drawing.Point(470, 0);
            this.logoPicture.Name = "logoPicture";
            this.logoPicture.Size = new System.Drawing.Size(70, 70);
            this.logoPicture.TabIndex = 2;
            this.logoPicture.TabStop = false;
            this.logoPicture.Click += new System.EventHandler(this.logoPicture_Click);
            // 
            // subTitleLabel
            // 
            this.subTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.subTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.subTitleLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.subTitleLabel.Location = new System.Drawing.Point(8, 40);
            this.subTitleLabel.Name = "subTitleLabel";
            this.subTitleLabel.Size = new System.Drawing.Size(456, 38);
            this.subTitleLabel.TabIndex = 1;
            this.subTitleLabel.Text = "[Sub Title]";
            this.subTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subTitleLabel.Click += new System.EventHandler(this.subTitleLabel_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.titleLabel.Location = new System.Drawing.Point(8, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(456, 23);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "[Title]";
            this.titleLabel.Click += new System.EventHandler(this.titleLabel_Click);
            // 
            // InstallerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(542, 406);
            this.ControlBox = false;
            this.Controls.Add(this.topSeparatorPanel);
            this.Controls.Add(this.bottomSeparatorPanel);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.titlePanel);
            this.Controls.Add(this.buttonPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstallerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[FormTitle]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstallerForm_FormClosing);
            this.buttonPanel.ResumeLayout(false);
            this.titlePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel titlePanel;
    private System.Windows.Forms.Panel contentPanel;
    private System.Windows.Forms.Panel topSeparatorPanel;
    private System.Windows.Forms.Panel bottomSeparatorPanel;
    private System.Windows.Forms.Button nextButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button prevButton;
    private System.Windows.Forms.Label titleLabel;
    private System.Windows.Forms.Label subTitleLabel;
    private System.Windows.Forms.TableLayoutPanel buttonPanel;
    private System.Windows.Forms.PictureBox logoPicture;
  }
}