using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

	    public void Copy(SidePanel source, string name)
	    {
	        SidePanel target;
	        target = (source == sidePanel1) ? sidePanel2 : sidePanel1;

            //if (Directory.Exists(source.CurrentDirectory + name))
            //{
            //    //Now Create all of the directories
            //    foreach (string dirPath in Directory.GetDirectories(source.CurrentDirectory, "*", SearchOption.AllDirectories))
            //        Directory.CreateDirectory(dirPath.Replace(source.CurrentDirectory, target.CurrentDirectory));

            //    //Copy all the files
            //    foreach (string filePath in Directory.GetFiles(source.CurrentDirectory, "*.*", SearchOption.AllDirectories))
            //        File.Copy(filePath, filePath.Replace(source.CurrentDirectory, target.CurrentDirectory));
            //}
            //else
            
            if (File.Exists( Path.Combine(source.CurrentDirectory, name)))
            {
                //File.Create( Path.Combine(target.CurrentDirectory, name));

                File.Copy(Path.Combine(source.CurrentDirectory, name), Path.Combine(target.CurrentDirectory, name));
                RefreshLists();
            }

	    }

	    public void Delete(SidePanel source, string name)
	    {
            
            if (File.Exists(Path.Combine(source.CurrentDirectory, name)))
            {
                if (MessageBox.Show("Are You sure you want to delete the file " + name + "?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)

                File.Delete( Path.Combine(source.CurrentDirectory, name) );
                RefreshLists();
            }
            else if (Directory.Exists( Path.Combine(source.CurrentDirectory, name)))
            {
                if (
                    MessageBox.Show(
                        "Are You sure you want to delete the folder" + name + " \nand all of its contents?",
                        "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RecursiveDeletion(Path.Combine(source.CurrentDirectory, name));
                }
                    

                RefreshLists();
            }
            
        }



	    private void RecursiveDeletion(string path)
	    {
	        foreach (string thisPath in Directory.GetDirectories(path))
	        {
	            RecursiveDeletion(thisPath);
            }

            foreach (string filename in Directory.GetFiles(path))
                File.Delete(Path.GetFullPath(filename));
            
            
            Directory.Delete(Path.GetFullPath(path));

	    }

	    public void RefreshLists()
	    {
	        string dir = sidePanel1.CurrentDirectory;
	        sidePanel1.CurrentDirectory = SidePanel.InitialDirectory;
	        sidePanel1.CurrentDirectory = dir;

            dir = sidePanel2.CurrentDirectory;
            sidePanel2.CurrentDirectory = SidePanel.InitialDirectory;
            sidePanel2.CurrentDirectory = dir;
	    }

	    public bool DirectoriesEqual()
	    {

	        string dir1 = Path.Combine(sidePanel1.CurrentDirectory, sidePanel1.SelectedItem.ToString());
	        string dir2 = Path.Combine(sidePanel2.CurrentDirectory, sidePanel2.SelectedItem.ToString());

	        if (sidePanel1.SelectedItem != null && sidePanel1.SelectedItem != null
	            && Directory.Exists(dir1) && Directory.Exists(dir2))
                return new DirCompare().DirEquals(new DirectoryInfo(dir1), new DirectoryInfo(dir2));
	        else
	        {
                throw new IOException();
	            
	        }
	    }

        //public bool FilesEqual(string file1, string file2)
        //{
        //    if ( (File) file1.ends
        //}

	    private class DirCompare
	    {

	        public bool DirEquals(DirectoryInfo dir1, DirectoryInfo dir2)
	        {
	            if (dir1 == null || dir2 == null)
	                return false;

                if ((dir1.GetFiles().Length != dir2.GetFiles().Length) || (dir1.GetDirectories().Length != dir2.GetDirectories().Length))
	                return false;

	            for (int i = 0; i < dir1.GetFiles().Length; i++)
	            {
	                if (FileEquals(dir1.GetFiles()[i], dir2.GetFiles()[i]) == false)
	                    return false;
	            }

	            for(int i = 0 ; i < dir1.GetDirectories().Length ; i++)
	            {
	                if (DirEquals(dir1.GetDirectories()[i], dir2.GetDirectories()[i]) == false)
	                    return false;
	            }

                return true;
	        }

	        public bool FileEquals(FileInfo file1,FileInfo file2)
	        {
	            return (file1.Name == file2.Name && file1.Length == file2.Length);
	        }

	    }
	}
}
