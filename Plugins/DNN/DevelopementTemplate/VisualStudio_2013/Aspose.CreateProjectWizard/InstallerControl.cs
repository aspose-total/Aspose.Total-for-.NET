// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows.Forms;

namespace Aspose.CreateProjectWizard
{
    public class InstallerControl : UserControl
    {
        private string title;
        private string subTitle;

        protected InstallerControl()
        {
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string SubTitle
        {
            get { return subTitle; }
            set { subTitle = value; }
        }

        protected InstallerForm Form
        {
            get
            {
                return (InstallerForm)this.ParentForm;
            }
        }

        protected internal virtual void Open() { }

        protected internal virtual void Close() { }

        protected internal virtual void RequestCancel()
        {
            Application.Exit();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // InstallerControl
            // 
            this.Name = "InstallerControl";
            this.ResumeLayout(false);

        }

    }

    public class InstallerControlList : List<InstallerControl>
    {
    }
}
