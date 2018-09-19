using Prism.Commands;
using Prism.Mvvm;
using SMSApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SMSApp.Controls.FilePicker
{
    public class FilePickerControlViewModel : BindableBase
    {
        const string FILES_FOLDER = "SMSAppDBFiles";

        public delegate void onDeleteHandler(FileItem fItem);
        public event onDeleteHandler DeleteEvent;

        public delegate void onUploadHandler(FileItem fItem);
        public event onUploadHandler UploadEvent;

        private ObservableCollection<FileItem> _files;
        private string _currentFilePath;
        private FileItem _selectedFileItem;

        public ObservableCollection<FileItem> Files { get => _files; set { _files = value; RaisePropertyChanged(); } }
        public string CurrentFilePath { get => _currentFilePath; set { _currentFilePath = value; RaisePropertyChanged(); } }
        public FileItem SelectedFileItem { get => _selectedFileItem; set { _selectedFileItem = value; RaisePropertyChanged(); } }


        public DelegateCommand UploadFileCmd { get; set; }
        public DelegateCommand DeleteCmd { get; set; }
        public DelegateCommand DownloadCmd { get; set; }

        private AlertsService _alerts;
        public FilePickerControlViewModel(AlertsService alerts)
        {
            Files = new ObservableCollection<FileItem>();
            UploadFileCmd = new DelegateCommand(UploadFile);
            DeleteCmd = new DelegateCommand(DeleteFile);
            DownloadCmd = new DelegateCommand(DownloadFile);
            _alerts = alerts;
        }

        private void UploadFile()
        {
            var fileName = CurrentFilePath;
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var tempFileName = Path.ChangeExtension(Guid.NewGuid().ToString(), Path.GetExtension(fileName));
            var tempFileDir = Path.Combine(directory, FILES_FOLDER);

            if (!Directory.Exists(tempFileDir)) Directory.CreateDirectory(tempFileDir);

            var tempFilePath = Path.Combine(tempFileDir, tempFileName);

            File.Copy(fileName, tempFilePath);
            var fItem = new FileItem() { FileName = fileName, FilePath = tempFilePath };

            Files.Add(fItem);

            UploadEvent?.Invoke(fItem);
        }

        private void DeleteFile()
        {
            if (SelectedFileItem == null) return;
            if (_alerts.ShowQuestionYesNoMsg("Do you want to delete this file?") != MessageBoxResult.Yes) return;

            DeleteEvent?.Invoke(SelectedFileItem);

            try
            {
                File.Delete(SelectedFileItem.FilePath);
            }
            catch (Exception ex)
            {

            }
            Files.Remove(SelectedFileItem);
        }

        private void DownloadFile()
        {
            Process.Start(SelectedFileItem.FilePath);
        }
    }
}
