// Copyright (c) Aspose 2002-2014. All Rights Reserved.

namespace Aspose.CreateProjectWizard
{
  partial class InstallProcessControl
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.currentlyInstallingLabel = new System.Windows.Forms.Label();
            this.currentTaskProgressBar = new System.Windows.Forms.ProgressBar();
            this.totalProgressBar = new System.Windows.Forms.ProgressBar();
            this.overAllProgressLabel = new System.Windows.Forms.Label();
            this.NoOfTasksCompletedLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.currentlyInstallingLabel, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.currentTaskProgressBar, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.totalProgressBar, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.overAllProgressLabel, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.NoOfTasksCompletedLabel, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.descriptionLabel, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 9;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(460, 325);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // currentlyInstallingLabel
            // 
            this.currentlyInstallingLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.currentlyInstallingLabel.AutoSize = true;
            this.currentlyInstallingLabel.Location = new System.Drawing.Point(3, 83);
            this.currentlyInstallingLabel.Name = "currentlyInstallingLabel";
            this.currentlyInstallingLabel.Size = new System.Drawing.Size(134, 13);
            this.currentlyInstallingLabel.TabIndex = 4;
            this.currentlyInstallingLabel.Text = "Current Operation Progress";
            // 
            // currentTaskProgressBar
            // 
            this.currentTaskProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentTaskProgressBar.Location = new System.Drawing.Point(3, 103);
            this.currentTaskProgressBar.Name = "currentTaskProgressBar";
            this.currentTaskProgressBar.Size = new System.Drawing.Size(454, 14);
            this.currentTaskProgressBar.Step = 1;
            this.currentTaskProgressBar.TabIndex = 0;
            // 
            // totalProgressBar
            // 
            this.totalProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalProgressBar.Location = new System.Drawing.Point(3, 163);
            this.totalProgressBar.Name = "totalProgressBar";
            this.totalProgressBar.Size = new System.Drawing.Size(454, 14);
            this.totalProgressBar.TabIndex = 5;
            // 
            // overAllProgressLabel
            // 
            this.overAllProgressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.overAllProgressLabel.AutoSize = true;
            this.overAllProgressLabel.Location = new System.Drawing.Point(3, 147);
            this.overAllProgressLabel.Name = "overAllProgressLabel";
            this.overAllProgressLabel.Size = new System.Drawing.Size(84, 13);
            this.overAllProgressLabel.TabIndex = 6;
            this.overAllProgressLabel.Text = "Overall Progress";
            // 
            // NoOfTasksCompletedLabel
            // 
            this.NoOfTasksCompletedLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NoOfTasksCompletedLabel.AutoSize = true;
            this.NoOfTasksCompletedLabel.Location = new System.Drawing.Point(370, 183);
            this.NoOfTasksCompletedLabel.Name = "NoOfTasksCompletedLabel";
            this.NoOfTasksCompletedLabel.Size = new System.Drawing.Size(87, 13);
            this.NoOfTasksCompletedLabel.TabIndex = 7;
            this.NoOfTasksCompletedLabel.Text = "0 of 0 Completed";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(3, 33);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(56, 13);
            this.descriptionLabel.TabIndex = 1;
            this.descriptionLabel.Text = "Working...";
            // 
            // InstallProcessControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "InstallProcessControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(480, 345);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    private System.Windows.Forms.ProgressBar currentTaskProgressBar;
    private System.Windows.Forms.Label descriptionLabel;
    private System.Windows.Forms.Label currentlyInstallingLabel;
    private System.Windows.Forms.ProgressBar totalProgressBar;
    private System.Windows.Forms.Label overAllProgressLabel;
    private System.Windows.Forms.Label NoOfTasksCompletedLabel;

  }
}
