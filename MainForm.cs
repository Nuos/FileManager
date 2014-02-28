using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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

        public SidePanel SidePanelLeft
        {
            get { return sidePanel1; }
        }

        public SidePanel SidePanelRight
        {
            get { return sidePanel2; }
        }


	    public void Copy(SidePanel source, string name)
	    {
	        SidePanel target;
	        target = (source == sidePanel1) ? sidePanel2 : sidePanel1;


            if (File.Exists( Path.Combine(source.CurrentDirectory, name)))
            {
                
                File.Copy(Path.Combine(source.CurrentDirectory, name), Path.Combine(target.CurrentDirectory, name));
                //RefreshLists(); //TEMPORARY - TAKE CARE!!!
            }

	    }

        //public void Delete(SidePanel source, string name)
        //{

        //    if (File.Exists(Path.Combine(source.CurrentDirectory, name)))
        //    {
        //        if (MessageBox.Show("Are You sure you want to delete the file " + name + "?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

        //            File.Delete(Path.Combine(source.CurrentDirectory, name));
        //        RefreshLists();
        //    }
        //    else if (Directory.Exists(Path.Combine(source.CurrentDirectory, name)))
        //    {
        //        if (
        //            MessageBox.Show(
        //                "Are You sure you want to delete the folder " + name + " \nand all of its contents?",
        //                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            RecursiveDeletion(Path.Combine(source.CurrentDirectory, name));
        //        }


        //        RefreshLists();
        //    }

        //}



        //private void RecursiveDeletion(string path)
        //{
        //    foreach (string thisPath in Directory.GetDirectories(path))
        //    {
        //        RecursiveDeletion(thisPath);
        //    }

        //    foreach (string filename in Directory.GetFiles(path))
        //        File.Delete(Path.GetFullPath(filename));
            
            
        //    Directory.Delete(Path.GetFullPath(path));

        //}

        //public void RefreshLists()
        //{
        //    string dir = sidePanel1.CurrentDirectory;
        //    sidePanel1.CurrentDirectory = SidePanel.InitialDirectory;
        //    sidePanel1.CurrentDirectory = dir;

        //    dir = sidePanel2.CurrentDirectory;
        //    sidePanel2.CurrentDirectory = SidePanel.InitialDirectory;
        //    sidePanel2.CurrentDirectory = dir;
        //}

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


	    public bool FileContentEquals(SidePanel sidePanel1)
	    {
	        SidePanel sidePanel2 = (sidePanel1 == this.sidePanel1) ? this.sidePanel2 : this.sidePanel1;

            string path1 = Path.Combine(sidePanel1.CurrentDirectory, sidePanel1.SelectedItem.ToString());
            string path2 = Path.Combine(sidePanel2.CurrentDirectory, sidePanel2.SelectedItem.ToString());

            if (sidePanel1.SelectedItem != null && sidePanel1.SelectedItem != null
                /*&& File.Exists(path1) && File.Exists(path2) */)
	        {
	            byte[] file1 = File.ReadAllBytes(path1);
	            byte[] file2 = File.ReadAllBytes(path2);
	            if (file1.Length == file2.Length)
	            {
	                for (int i = 0; i < file1.Length; i++)
	                {
	                    if (file1[i] != file2[i])
	                    {
	                        return false;
	                    }
	                }
	                return true;
	            }
            }
	        
            return false;
	      
	     
	    }


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
