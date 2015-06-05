// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using System.Resources;
using System.Reflection;
using System.Globalization;
using AsposeVisualStudioPlugin.GUI;
using AsposeVisualStudioPlugin.Properties;
using Microsoft.VisualStudio.CommandBars;

namespace AsposeVisualStudioPlugin
{
    internal struct ConnectConstants
    {
        public const string COMMAND_NAME_MENU_TOOLS = "MenuTools_AsposeVSPlugin";
        public const string COMMAND_NAME_MENU_FILE = "MenuFile_AsposeVSPlugin";

        public const string COMMAND_TITLE_TOOLS = "Aspose Visual Studio Plugin";
        public const string COMMAND_TITLE_FILE = "New Aspose Example Project";

        public const string COMMAND_TOOLTIP = "Download and run Aspose Examples";

    }

    public class Connect : IDTExtensibility2, IDTCommandTarget
    {
        public Connect()
        {
        }

        private int GetItemIndex(CommandBarControls commandBarControls)
        {
            int index = 2;

            foreach (CommandBarControl item in commandBarControls)
            {
                if (item.Caption.Equals("New &Project..."))
                {
                    break;
                }
                index++;
            }

            return index;
        }

        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            _applicationObject = (DTE2)application;
            _addInInstance = (AddIn)addInInst;
            if (connectMode == ext_ConnectMode.ext_cm_UISetup)
            {
                object[] contextGUIDS = new object[] { };
                Commands2 commands = (Commands2)_applicationObject.Commands;

                CommandBar menuBarCommandBar = ((Microsoft.VisualStudio.CommandBars.CommandBars)_applicationObject.CommandBars)["MenuBar"];

                CommandBarControl toolsControl = menuBarCommandBar.Controls["Tools"];
                CommandBarPopup toolsPopup = (CommandBarPopup)toolsControl;

                try
                {
                    Command command = commands.AddNamedCommand2(_addInInstance, ConnectConstants.COMMAND_NAME_MENU_TOOLS, ConnectConstants.COMMAND_TITLE_TOOLS, ConnectConstants.COMMAND_TOOLTIP, false, Resources.pnglogosmall, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 1);
                    }
                }
                catch (System.ArgumentException) { }

                toolsControl = menuBarCommandBar.Controls["File"];
                toolsPopup = (CommandBarPopup)toolsControl;
                CommandBars cmdBars = (CommandBars)(_applicationObject.CommandBars);

                CommandBar vsBarProject = cmdBars["File"];
                try
                {
                    Command command = commands.AddNamedCommand2(_addInInstance, ConnectConstants.COMMAND_NAME_MENU_FILE, ConnectConstants.COMMAND_TITLE_FILE, ConnectConstants.COMMAND_TOOLTIP, false, Resources.pnglogosmall, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, GetItemIndex(toolsPopup.CommandBar.Controls));
                    }
                }
                catch (System.ArgumentException) { }
            }
        }

        /// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
        /// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
        {
        }

        /// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />		
        public void OnAddInsUpdate(ref Array custom)
        {
        }

        /// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnStartupComplete(ref Array custom)
        {
        }

        /// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnBeginShutdown(ref Array custom)
        {
        }

        /// <summary>Implements the QueryStatus method of the IDTCommandTarget interface. This is called when the command's availability is updated</summary>
        /// <param term='commandName'>The name of the command to determine state for.</param>
        /// <param term='neededText'>Text that is needed for the command.</param>
        /// <param term='status'>The state of the command in the user interface.</param>
        /// <param term='commandText'>Text requested by the neededText parameter.</param>
        /// <seealso class='Exec' />
        public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
        {
            if (neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
            {
                if (commandName == _addInInstance.ProgID + "." + ConnectConstants.COMMAND_NAME_MENU_FILE || commandName == _addInInstance.ProgID + "." + ConnectConstants.COMMAND_NAME_MENU_TOOLS)
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
            }
        }

        /// <summary>Implements the Exec method of the IDTCommandTarget interface. This is called when the command is invoked.</summary>
        /// <param term='commandName'>The name of the command to execute.</param>
        /// <param term='executeOption'>Describes how the command should be run.</param>
        /// <param term='varIn'>Parameters passed from the caller to the command handler.</param>
        /// <param term='varOut'>Parameters passed from the command handler to the caller.</param>
        /// <param term='handled'>Informs the caller if the command was handled or not.</param>
        /// <seealso class='Exec' />
        public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            try
            {
                handled = false;
                if (executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
                {
                    if (commandName == _addInInstance.ProgID + "." + ConnectConstants.COMMAND_NAME_MENU_FILE || commandName == _addInInstance.ProgID + "." + ConnectConstants.COMMAND_NAME_MENU_TOOLS)
                    {
                        SampleWizardPage page = new SampleWizardPage(_applicationObject);
                        if (page != null && !page.IsDisposed) page.ShowDialog();
                        handled = true;
                        return;
                    }
                }
            }
            catch (Exception) { }
        }
        private DTE2 _applicationObject;
        private AddIn _addInInstance;
    }
}