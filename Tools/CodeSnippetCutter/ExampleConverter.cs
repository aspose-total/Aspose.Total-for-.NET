using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippetCutter
{
    /// <summary>
    /// Read snippets from source file
    /// </summary>
    class ExampleConverter
    {
        /// <summary>
        /// Read a source file and find code snippets
        /// Save the code snippets to the specified folder
        /// </summary>
        /// <param name="sourceFile">source file to read</param>
        /// <param name="snippetsFolder">Folder where snippets will be saved</param>
        /// <returns>Number of snippets created</returns>
        public int ProcessExample(String sourceFile, String snippetsFolder)
        {
            int snippetsCreated = 0;
            //Console.WriteLine("Processing " + sourceFile);

            // Read all lines from the source file
            String[] lines = File.ReadAllLines(sourceFile);
            int lineNo = 1, startLineNo = 0, endLineNo = 0;
            foreach (String line in lines)
            {
                // Start - Find the snippet
                if (line.Contains(Common.ExStart) == true)
                {
                    startLineNo = lineNo;
                    //Console.Write("Found ExStart at line " + startLineNo + " - ");
                    // Start - Find the ID of the snippet
                    int startID = line.IndexOf(Common.ExStart) + Common.ExStart.Length;
                    String snippetID = line.Substring(startID).Trim();
                    //Console.WriteLine("ID:" + snippetID);

                    // End - Find the snippet end in next lines
                    for (int iLines = startLineNo + 1; iLines < lines.Length; iLines++)
                    {
                        String strLine = lines[iLines];
                        if (strLine.Contains(Common.ExEnd) == true)
                        {
                            // End - Find the ID of the snippet
                            int endID = strLine.IndexOf(Common.ExEnd) + Common.ExEnd.Length;
                            String snippetEndID = strLine.Substring(endID).Trim();
                            if (snippetID == snippetEndID)
                            {
                                endLineNo = iLines + 1;
                                //Console.WriteLine("Found ExEnd at line " + endLineNo);

                                // Save the snippet
                                SaveSnippet(snippetID, startLineNo, endLineNo, lines, snippetsFolder, sourceFile);
                                snippetsCreated++;
                            }
                        }
                    }
                }

                lineNo++;
            }

            return snippetsCreated;
        }

        /// <summary>
        /// Save the code snippet in a file
        /// </summary>
        /// <param name="snippetID">Snippet ID e.g. ExStart:SnippetID</param>
        /// <param name="startLineNo">Start line number</param>
        /// <param name="endLineNo">End line number</param>
        /// <param name="lines">All lines of the source file</param>
        /// <param name="snippetsFolder">Folder where the snippet will be saved</param>
        /// <param name="sourceFile">Source file</param>
        private void SaveSnippet(string snippetID, int startLineNo, int endLineNo, string[] lines,
            string snippetsFolder, string sourceFile)
        {
            // Get the name of the snippet
            String repoURL = "";
            String snippetFile = snippetsFolder + Path.DirectorySeparatorChar + 
                GetSnippetFileName(sourceFile, snippetID, ref repoURL);
            // Get the lines required by the snippet
            List<String> lstLines = GetSnippetLines(startLineNo, endLineNo, lines);
            // Remove white spaces at the start
            lstLines = RemoveWhiteSpaces(lstLines);
            // Add the GitHub repo URL if found
            AddGitHubRepositoryURL(lstLines, repoURL, sourceFile);
            File.WriteAllLines(snippetFile, lstLines);
            //Console.WriteLine("Snippet file: " + snippetFile);
        }

        private void AddGitHubRepositoryURL(List<string> lstLines, string repoURL, string sourceFile)
        {
            if (repoURL.Trim().Length == 0)
                return;

            String comment = "";

            // First line should be a comment, referring to the GitHub repository URL
            // Detect the language from the source file extention
            String ext = Path.GetExtension(sourceFile).ToLower();
            switch(ext)
            {
                // All languages in which comment starts with //
                case ".cs":
                case ".java":
                    comment += "// ";
                    break;
                
                // All languages in which comment starts with '
                case ".vb":
                    comment += "' ";
                    break;
            }

            comment += "For complete examples and data files, please go to " + repoURL;
            lstLines.Insert(0, comment);
        }

        private List<string> RemoveWhiteSpaces(List<string> lstLines)
        {
            // Count the white spaces in the first line
            int spaceCount = lstLines[0].TakeWhile(Char.IsWhiteSpace).Count();
            // Process all lines
            for (int iLine = 0; iLine < lstLines.Count; iLine++ )
            {
                String line = lstLines[iLine];

                if (line.Length <= spaceCount)
                    continue;

                // If all of the first characters are spaces, remove them
                if (line.Substring(0, spaceCount).Trim().Length == 0)
                {
                    lstLines[iLine] = line.Remove(0, spaceCount);
                }
                else
                {
                    lstLines[iLine] = line.TrimStart(' ');
                }
            }
            return lstLines;
        }

        private List<string> GetSnippetLines(int startLineNo, int endLineNo, string[] lines)
        {
            // Create an empty list
            List<String> lstLines = new List<string>();

            for (int iLines = startLineNo - 1; iLines < endLineNo; iLines++)
            {
                // Do not add the line, if it contains ExStart or ExEnd
                if (lines[iLines].Contains(Common.ExStart) || lines[iLines].Contains(Common.ExEnd))
                    continue;
                lstLines.Add(lines[iLines]);
            }

            return lstLines;
        }

        private String GetSnippetFileName(String sourceFile, String snippetID, ref String repoURL)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Path.GetDirectoryName(sourceFile));
            String snippetFile = Path.GetFileNameWithoutExtension(sourceFile) + "-" + snippetID + Path.GetExtension(sourceFile);

            // Read parent folder until Examples or Plugins folder are found
            while (dirInfo != null)
            {
                String dirName = dirInfo.Name;

                // Break if we reach at the GitHub repository folder
                // e.g. Aspose_{Product}_{Platform}
                if (dirName.StartsWith("aspose_", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (dirName.EndsWith("_NET", StringComparison.CurrentCultureIgnoreCase) ||
                        dirName.EndsWith("_Java", StringComparison.CurrentCultureIgnoreCase) ||
                        dirName.EndsWith("_Cloud", StringComparison.CurrentCultureIgnoreCase) ||
                        dirName.EndsWith("_Android", StringComparison.CurrentCultureIgnoreCase))
                    {
                        // Read the URL from .git/config file in main repository folder
                        repoURL = GetRepositoryURL(dirInfo);
                        break;
                    }
                }

                snippetFile = dirName + "-" + snippetFile;
                // Go to parent directory
                dirInfo = dirInfo.Parent;
                //dirInfo = new DirectoryInfo(Path.GetDirectoryName(sourceFile)).Name;
            }

            return snippetFile;
        }

        private string GetRepositoryURL(DirectoryInfo dirInfo)
        {
            String url = "";

            // Read the file repo/.git/config
            String[] lines = File.ReadAllLines(dirInfo.FullName + Path.DirectorySeparatorChar + 
                ".git" + Path.DirectorySeparatorChar + "config");
            foreach(String line in lines)
            {
                if (line.Contains("url") && line.Contains("github.com/") && line.Contains(".git"))
                {
                    string[] arrURL = line.Split('=');
                    if (arrURL[0].Trim() == "url" && arrURL[1].Trim().StartsWith("https://"))
                    {
                        url = arrURL[1].Trim().Replace(".git", "");
                    }
                }
            }

            return url;
        }
    }
}
