// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NGit.Api;

namespace AsposeVisualStudioPlugin.Core
{
    public class GitHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
 
        public static string CloneOrCheckOutRepo(AsposeComponent component)
        {
            string repUrl = component.get_remoteExamplesRepository();
            string localFolder = getLocalRepositoryPath(component);
            string error = string.Empty;

            checkAndCreateFolder(getLocalRepositoryPath(component));

            try
            {
                CloneCommand clone = Git.CloneRepository();
                clone.SetURI(repUrl);
                clone.SetDirectory(localFolder);

                Git repo = clone.Call();
                //writer.Close();
                repo.GetRepository().Close();
            }
            catch (Exception ex)
            {

                try
                {
                    var git = Git.Open(localFolder);
                    var repository = git.GetRepository();
                    PullCommand pullCommand = git.Pull();
                    pullCommand.Call();
                    repository.Close();
                }
                catch (Exception ex2)
                {

                    error = ex2.Message;
                }

                error = ex.Message;
            }

            return error;
        }


        /**
         * 
         * @param folderPath
         */
        private static void checkAndCreateFolder(String folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);


        }


        /**
         * 
         * @param component
         * @return
         */
        public static bool isExamplesDefinitionsPresent(AsposeComponent component)
        {

            return File.Exists(getLocalRepositoryPath(component) + "/" + "Examples.xml");
            /*
               File file = new File(getLocalRepositoryPath(component) + "/" + "Examples.xml");
               return file.exists();
             * */
        }

        /**
         * 
         * @param component
         * @return
         */
        public static string getExamplesDefinitionsPath(AsposeComponent component)
        {
            return getLocalRepositoryPath(component) + "/" + "Examples.xml";
        }

        /**
         * 
         * @param component
         * @return
         */
        public static string getLocalRepositoryPath(AsposeComponent component)
        {
            return AsposeComponentsManager.getAsposeHomePath() + "gitrepos" + "/" + component.get_name();
        }

    }
}
