using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippetCutter
{
    /// <summary>
    /// Converts the examples inside a folder to snippets
    /// Can process multiple files inside sub-folders
    /// All snippets are created in single directory, as Gist does not support directories
    /// </summary>
    public class ExamplesToSnippetsConverter
    {
        private int filesTotal = 0,
            filesProcessed = 0,
            snippetsCreatedTotal = 0;
        private String searchPattern = "*";
        private enum Language { CSharp, VisualBasic};
        private List<ErrorDescription> errors = new List<ErrorDescription>();

        /// <summary>
        /// Convert examples to snippets
        /// </summary>
        /// <param name="examples">Path of the examples folder e.g. D:\GitHub\Aspose_3D_NET\Examples</param>
        /// <param name="snippets">Path of the snippets folder e.g. D:\GitHub\Aspose_3D_NET_Snippets</param>
        public void ProcessExamples(String examples, String snippets)
        {
            // Initialize
            filesTotal = 0;
            filesProcessed = 0;
            snippetsCreatedTotal = 0;
            errors.Clear();

            // Get the source code files. Criteria define in search pattern
            List<String> files = DirSearch(examples, searchPattern, SearchOption.AllDirectories);
            filesTotal = files.Count;

            foreach(String file in files)
            {
                // Independent of the programming language
                ProcessSourceFile(file, snippets);
            }

            ListErrors();

            Console.WriteLine("Total example files: " + filesTotal + "\nExamples Processed: " + filesProcessed +
                "\nSnippets created: " + snippetsCreatedTotal);

            Console.WriteLine("Failed: " + errors.Count);
        }

        /// <summary>
        /// List the errors occurred during processing
        /// </summary>
        private void ListErrors()
        {
            
            if (errors.Count > 0)
            {
                foreach(ErrorDescription error in errors)
                {
                    Console.WriteLine("File: " + error.sourceFile + "\nError: " + error.exception.Message + "\n");
                }
            }
        }

        /// <summary>
        /// Read source file and create code snippets
        /// </summary>
        /// <param name="file">source file</param>
        /// <param name="snippetsFolder">Snippets folder</param>
        private void ProcessSourceFile(String file, String snippetsFolder)
        {
            try
            {
                ExampleConverter exConverter = new ExampleConverter();
                int snippetsCreated = exConverter.ProcessExample(file, snippetsFolder);

                snippetsCreatedTotal += snippetsCreated;
                if (snippetsCreated > 0)
                    filesProcessed++;
            }
            catch(Exception ex)
            {
                LogError(file, ex);
            }
        }

        /// <summary>
        /// Log the error message. Save the file names and exception in a list
        /// </summary>
        /// <param name="file">Source file</param>
        /// <param name="ex">Exception</param>
        private void LogError(string file, Exception ex)
        {
            errors.Add(new ErrorDescription() { exception = ex, sourceFile = file });
        }

        /// <summary>
        /// Returns file names from given folder that comply to given filters
        /// </summary>
        /// <param name="SourceFolder">Folder with files to retrieve</param>
        /// <param name="Filter">Multiple file filters separated by | character</param>
        /// <param name="searchOption">File.IO.SearchOption, 
        /// could be AllDirectories or TopDirectoryOnly</param>
        /// <returns>Array of FileInfo objects that presents collection of file names that 
        /// meet given filter</returns>
        private List<String> DirSearch(string SourceFolder, string Filter,
         System.IO.SearchOption searchOption)
        {
            // ArrayList will hold all file names
            List<String> alFiles = new List<String>();

            // Create an array of filter string
            string[] MultipleFilters = Filter.Split('|');

            // for each filter find mathing file names
            foreach (string FileFilter in MultipleFilters)
            {
                // add found file names to array list
                alFiles.AddRange(Directory.GetFiles(SourceFolder, FileFilter, searchOption));
            }

            // returns string array of relevant file names
            return alFiles;
        }
    }
}
