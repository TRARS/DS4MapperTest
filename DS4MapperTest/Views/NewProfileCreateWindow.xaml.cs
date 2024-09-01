using DS4MapperTest.ViewModels;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace DS4MapperTest.Views
{
    /// <summary>
    /// Interaction logic for NewProfileCreateWindow.xaml
    /// </summary>
    public partial class NewProfileCreateWindow : Window
    {
        private NewProfileCreateViewModel newProfCreateVM;
        public NewProfileCreateViewModel NewProfCreateVM => newProfCreateVM;

        public NewProfileCreateWindow()
        {
            InitializeComponent();
        }

        public void PostInit(Mapper mapper, BackendManager manager)
        {
            newProfCreateVM = new NewProfileCreateViewModel(mapper, manager);
            DataContext = newProfCreateVM;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            bool validForm = newProfCreateVM.ValidateForm();
            if (validForm)
            {
                newProfCreateVM.CreateProfile();
                Close();
            }
        }

        private void BrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.FileOk += FileDialog_FileOk;
            fileDialog.InitialDirectory = newProfCreateVM.Mapper.AppGlobal.GetDeviceProfileFolderLocation(newProfCreateVM.Mapper.DeviceType);
            fileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == true)
            {
                string tempFile = fileDialog.FileName;
                if (tempFile.EndsWith(".json") && !File.Exists(tempFile))
                {
                    newProfCreateVM.ProfilePath = tempFile;
                }
            }
        }

        private void FileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveFileDialog fileDialog = sender as SaveFileDialog;
            string destDir = System.IO.Path.GetDirectoryName(fileDialog.FileName);
            if (fileDialog.InitialDirectory != destDir)
            {
                e.Cancel = true;
                MessageBox.Show("Cannot move to a different directory");
                return;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DataContext = null;
        }
    }
}
