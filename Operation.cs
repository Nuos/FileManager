using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    class Operation
    {

        

        public void DeleteDirectory(DirectoryInfo deleteFrom, string name)
        {

            RecursiveDeletion(Path.Combine(deleteFrom.ToString(), name));

            //if (File.Exists(Path.Combine(deleteFrom.ToString(), name)))
            //{
            //    if (MessageBox.Show("Are You sure you want to delete the file " + name + "?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            //        File.Delete(Path.Combine(deleteFrom.ToString(), name));
            //    //RefreshLists();
            //}
            //else

            //if (Directory.Exists(Path.Combine(deleteFrom.ToString(), name)))
            //{
            //    if (
            //        MessageBox.Show(
            //            "Are You sure you want to delete the folder " + name + " \nand all of its contents?",
            //            "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        RecursiveDeletion(Path.Combine(deleteFrom.ToString(), name));
            //    }


            //    //RefreshLists();
            //}

        }

        public void DeleteFile(DirectoryInfo deleteFrom, string name)
        {
            File.Delete(Path.Combine(deleteFrom.ToString(), name));
        }


        private static void RecursiveDeletion(string path)
        {
            foreach (string thisPath in Directory.GetDirectories(path))
            {
                RecursiveDeletion(thisPath);
            }

            foreach (string filename in Directory.GetFiles(path))
                File.Delete(Path.GetFullPath(filename));


            Directory.Delete(Path.GetFullPath(path));

        }

        public static List<string> Search(string searchValue, DirectoryInfo directory, ListBox resultsListBox)
        {
            var resultsList = new List<string>();

            if (!IsDirectoryAccessable(directory.ToString()))
                return new List<string>();


            foreach (string directoryIn in Directory.GetDirectories(Path.GetFullPath(directory.ToString())))
            {

                

                DirectoryInfo innerDirectory = new DirectoryInfo(Path.Combine(directory.ToString(), directoryIn));

                
                if (String.Equals(searchValue, innerDirectory.Name, StringComparison.CurrentCultureIgnoreCase))
                {
                    resultsList.Add(Path.Combine(directory.ToString(), directoryIn));
                }

                resultsList.AddRange( Search(searchValue, innerDirectory, resultsListBox) ); //recursive function
            }

            foreach (string fileIn in Directory.GetFiles(Path.GetFullPath(directory.ToString())))
            {
              

                if (String.Equals(searchValue, Path.GetFileNameWithoutExtension(fileIn), StringComparison.CurrentCultureIgnoreCase) 
                    || String.Equals(searchValue, Path.GetFileName(fileIn), StringComparison.CurrentCultureIgnoreCase))
                {
                    resultsList.Add( Path.Combine(directory.ToString(), fileIn) );
                    
                }              
            }

            return resultsList;
        }

        public static bool IsDirectoryAccessable(string directory)
        {

            try
            {
                Directory.GetDirectories(directory); //no other way to check access permissions ;( so much overhead...
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            
            
        }

        public static List<FileSystemInfo> FilterItems(string fullPath)
        {
            var filterValue = fullPath.Substring(fullPath.LastIndexOf("\\")+1);
            var currentPath = fullPath.Remove(fullPath.LastIndexOf("\\"));

            List<FileSystemInfo> itemsFound = new List<FileSystemInfo>();

            itemsFound.AddRange(new DirectoryInfo(currentPath).GetDirectories(filterValue, SearchOption.TopDirectoryOnly));
            itemsFound.AddRange(new DirectoryInfo(currentPath).GetFiles(filterValue, SearchOption.TopDirectoryOnly));

            return itemsFound;
        }
    }
}
