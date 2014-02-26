using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace FileManager
{
	public partial class SidePanel : UserControl
	{
		private DirectoryInfo _curDir;
        private string _curPath;
	    private MainForm _parentMainForm;

	    public const string InitialDirectory = @"C:\";
	

		public SidePanel(MainForm mainForm)
		{
			InitializeComponent();
		    this._parentMainForm = mainForm;
            comboBoxDrives.DropDownStyle = ComboBoxStyle.DropDownList;
            
            comboBoxDrives.Items.AddRange(DriveInfo.GetDrives());
		    comboBoxDrives.SelectedItem = comboBoxDrives.Items[0];


		}

        public Object SelectedItem
        {
            get { return listBox1.SelectedItem; }
            
        }

   
	    

	    public string CurrentDirectory
		{
			get { return _curDir.FullName; }
			set
			{
                
				if (_curDir != null && (value == _curDir.FullName || !Directory.Exists(value))) //if no Dir or the same
					return;

			    try //Get access to the directory
			    {
			        DirectorySecurity ds = Directory.GetAccessControl(value);
			    }
			    catch (UnauthorizedAccessException exception)
			    {
			        MessageBox.Show(exception.Message, "Access denied");
                    return;
			    }
			    
				_curDir = new DirectoryInfo(value);

				listBox1.Items.Clear();


                foreach (string path in Directory.GetDirectories(value)) // Cut the string to only show names without path for Dirs
                {
                    var dirName = new DirectoryInfo(path);
                    listBox1.Items.Add(dirName.Name);

                }

                foreach (string path in Directory.GetFiles(value)) // Cut the string to only show names without path for Files
                {
                    listBox1.Items.Add(Path.GetFileName(path));

                }

                //listBox1.Items.AddRange(Directory.GetDirectories(value));
                //listBox1.Items.AddRange(Directory.GetFiles(value));

				pathBox.Text = _curDir.ToString();
                _curPath = value;
			    //string curDrive = _curPath[0].ToString().ToUpper() + ":\";

			    var curDrive = Path.GetPathRoot(_curPath);

			    foreach (object drive in comboBoxDrives.Items)
			    {
			        if (drive.ToString().ToUpper() == curDrive.ToUpper())
			            comboBoxDrives.SelectedItem = drive;
			    }

			}
		}



		private void SidePanel_Load(object sender, EventArgs e)
		{
			CurrentDirectory = InitialDirectory;
		}

		private void tsb_UpDir_Click(object sender, EventArgs e)
		{
            if (Directory.GetParent(CurrentDirectory) != null)
			CurrentDirectory = 
				Directory.GetParent(CurrentDirectory).ToString();
		}

		private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			base.OnDoubleClick(e);

			if (listBox1.SelectedItem == null)
				return;

			string itemString = listBox1.SelectedItem.ToString();

            if ( Directory.GetParent(_curPath) == null)

                itemString = Path.Combine(_curPath, itemString);
            else
                itemString = Path.Combine(_curPath, itemString);


			if (Directory.Exists(itemString))
			{
				CurrentDirectory = itemString;
			} else if (File.Exists(itemString))
			{

			    try
			    {
			        System.Diagnostics.Process.Start(itemString);
			    }
                catch (Win32Exception exception)
                {
                    
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK , MessageBoxIcon.Exclamation);
                }
			}
		}



        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (Directory.Exists(pathBox.Text))
                {
                    CurrentDirectory = pathBox.Text;
                }
            }
        }

        private void rootDirBtn_Click(object sender, EventArgs e)
        {
            CurrentDirectory = Path.GetPathRoot(CurrentDirectory);
        }

        private void newDirBtn_Click(object sender, EventArgs e)
        {
            string newDirValue = PromptDialog.ShowDialog("Enter name:", "New Folder");
            
            if(newDirValue == "")
                return;

            if (isLegalName(newDirValue))
            {
                if (!(Directory.Exists(CurrentDirectory + newDirValue)))
                    Directory.CreateDirectory(Path.Combine(CurrentDirectory, newDirValue));
                else
                {
                    MessageBox.Show("This folder already exists!");
                }
                            
            }
            else
                MessageBox.Show("Illegal folder name!");

            _parentMainForm.RefreshLists();
        }

	    private bool isLegalName(string name)
	    {
	        char[] invalid = System.IO.Path.GetInvalidFileNameChars();

	        for (int i = 0; i < name.Length; i++)
	        {
	            if ( name.Contains(invalid[i].ToString() ))
	            {
	                return false;
	            }

	        }
	        return true;
	    }

        private void copyItemBtn_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
                try
                {
                    _parentMainForm.Copy(this, listBox1.SelectedItem.ToString());
                }

                catch (IOException exception)
                {
                    MessageBox.Show(exception.Message);
                }

               
        }

        private void moveItemBtn_Click(object sender, EventArgs e)
        {
            _parentMainForm.Copy(this, listBox1.SelectedItem.ToString());
            _parentMainForm.Delete(this, listBox1.SelectedItem.ToString());
        }

        private void refreshListsBtn_Click(object sender, EventArgs e)
        {
            _parentMainForm.RefreshLists();
        }

        private void deleteItemBtn_Click(object sender, EventArgs e)
        {
            _parentMainForm.Delete(this, listBox1.SelectedItem.ToString());
        }

        private void compareDirsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(_parentMainForm.DirectoriesEqual())
                    MessageBox.Show("Folders are equal!", "Result");
                else
                {
                    MessageBox.Show("Folders are NOT equal!", "Result");
                }


            }
            catch (IOException)
            {
                MessageBox.Show("One or more selections isn't a folder!", "Error");
            }
            
        }

        private void pathBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (Directory.Exists(Path.GetFullPath(pathBox.Text)))
                {
                    CurrentDirectory = Path.GetFullPath(pathBox.Text);
                }
            }
        }

        private void pathBox_Leave(object sender, EventArgs e)
        {
            pathBox.Text = CurrentDirectory;
        }

        private void compareFilesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_parentMainForm.FileContentEquals(this))
                    MessageBox.Show("The files content is equal.", "Content Comparison");
                else
                {
                    MessageBox.Show("The files content is different.", "Content Comparison");
                }
            }
            catch (IOException)
            {
                MessageBox.Show("One or more selections isn't a file!", "Error");
            }

        }

        private void comboBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriveInfo selectedDrive = (DriveInfo) comboBoxDrives.SelectedItem;
            if (selectedDrive.IsReady)
            {
                this.CurrentDirectory = comboBoxDrives.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("This drive isn't ready!", "Drive not ready");
                string curDrive = Path.GetPathRoot(CurrentDirectory);
                foreach (object currentDrive in comboBoxDrives.Items)
                {
                    if (currentDrive.ToString().ToUpper() == curDrive.ToUpper())
                        comboBoxDrives.SelectedItem = currentDrive;
                }

            }

        }

        private void txtEditorBtn_Click(object sender, EventArgs e)
        {
            string filename = PromptDialog.ShowDialog("Enter file name:", "New text file");

            TextEditor txt = new TextEditor(Path.Combine(this.CurrentDirectory, filename));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string searchValue = PromptDialog.ShowDialog("Enter search term:", "Search");

            if (!String.IsNullOrEmpty(searchValue))
            {
                listBox1.Items.Clear();
                Operation.Search(searchValue, new DirectoryInfo(CurrentDirectory), listBox1);
            }
        }


	}


}