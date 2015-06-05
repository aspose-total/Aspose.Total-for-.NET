// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace Aspose.CreateProjectWizard
{
    internal class ApplicationSettings
    {
        public class BackwardCompatibilityConfigProps
        {
            // "Apllication" mispelled on purpose to match original mispelling released
            public const string RequireDeploymentToCentralAdminWebApllication = "RequireDeploymentToCentralAdminWebApllication";
            // Require="MOSS" = RequireMoss="true" 
            public const string Require = "RequireMoss";
            // FarmFeatureId = FeatureId with FeatureScope = Farm
            public const string FarmFeatureId = "FarmFeatureId";
        }

        public class ConfigProps
        {
            public const string EULA = "EULA";
            public const string SolutionFolder = "ProductFiles";
            public const string RequireMoss = "RequireMoss";
            public const string FeatureScope = "FeatureScope";
            public const string DefaultDeployToSRP = "DefaultDeployToSRP";
            public const string RequireDeploymentToCentralAdminWebApplication = "RequireDeploymentToCentralAdminWebApplication";
            public const string RequireDeploymentToAllContentWebApplications = "RequireDeploymentToAllContentWebApplications";            
        }

        internal static string EULA
        {
            get
            {
                string valueString;
                try
                {
                    valueString = ConfigurationManager.AppSettings[ConfigProps.EULA];
                    valueString = String.IsNullOrEmpty(valueString) ? String.Empty : valueString;
                }
                catch (Exception)
                {
                    valueString = String.Empty;
                }
                return valueString;
            }
        }

        internal static string SolutionTitle
        {
            get
            {
                return global::Aspose.CreateProjectWizard.Properties.Resources.SolutionTitleText;
            }
        }

        internal static string SolutionFolder
        {
            get
            {
                try
                {
                    string solutionPath = ConfigurationManager.AppSettings[ConfigProps.SolutionFolder];
                    string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    if (!String.IsNullOrEmpty(solutionPath))
                    {
                        if (solutionPath.Contains("\\"))
                        {
                            try
                            {
                                if (Directory.Exists(solutionPath))
                                {
                                    return solutionPath;
                                }
                            }
                            catch (Exception)
                            { }
                        }
                        return appPath + "\\" + solutionPath;
                    }
                }
                catch (Exception)
                { }
                return String.Empty;
            }
        }

        internal static string FormatString(string str)
        {
            return FormatString(str, null);
        }

        internal static string FormatString(string str, params object[] args)
        {
            string formattedStr = str;
            string solutionTitle = SolutionTitle;
            if (!String.IsNullOrEmpty(solutionTitle))
            {
                formattedStr = formattedStr.Replace("{SolutionTitle}", solutionTitle);
            }
            if (args != null)
            {
                formattedStr = String.Format(formattedStr, args);
            }
            return formattedStr;
        }

        internal static string BannerImage
        {
            get { return "Default"; }
        }

        internal static string LogoImage
        {
            get { return "None"; }
        }

        internal static bool RequireMoss
        {
            get
            {
                bool rtnValue = false;
                string valueStr = ConfigurationManager.AppSettings[ConfigProps.RequireMoss];
                if (String.IsNullOrEmpty(valueStr))
                {
                    valueStr = ConfigurationManager.AppSettings[BackwardCompatibilityConfigProps.Require];
                    rtnValue = valueStr != null && valueStr.Equals("MOSS", StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    rtnValue = Boolean.Parse(valueStr);
                }
                return rtnValue;
            }
        }

        internal static bool DefaultDeployToSRP
        {
            get
            {
                string valueStr = ConfigurationManager.AppSettings[ConfigProps.DefaultDeployToSRP];
                if (!String.IsNullOrEmpty(valueStr))
                {
                    return valueStr.Equals("true", StringComparison.OrdinalIgnoreCase);
                }
                return false;
            }
        }

        internal static bool RequireDeploymentToCentralAdminWebApplication
        {
            get
            {
                string valueStr = ConfigurationManager.AppSettings[ConfigProps.RequireDeploymentToCentralAdminWebApplication];

                //
                // Backwards compatability with old configuration files containing spelling error in the 
                // application setting key (Bug 990).
                //
                if (String.IsNullOrEmpty(valueStr))
                {
                    valueStr = ConfigurationManager.AppSettings[ApplicationSettings.BackwardCompatibilityConfigProps.RequireDeploymentToCentralAdminWebApllication];
                }

                if (!String.IsNullOrEmpty(valueStr))
                {
                    return valueStr.Equals("true", StringComparison.OrdinalIgnoreCase);
                }

                return false;
            }
        }

        internal static bool RequireDeploymentToAllContentWebApplications
        {
            get
            {
                string valueStr = ConfigurationManager.AppSettings[ConfigProps.RequireDeploymentToAllContentWebApplications];
                if (!String.IsNullOrEmpty(valueStr))
                {
                    return valueStr.Equals("true", StringComparison.OrdinalIgnoreCase);
                }
                return false;
            }
        }      
        
    }
}
