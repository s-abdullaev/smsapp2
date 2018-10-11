using Prism.Commands;
using Prism.Mvvm;
using SMSApp.DataAccess;
using SMSApp.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace SMSApp.Controls.FilePicker
{
    public class FilePickerControlViewModel : BindableBase
    {
        const string FILES_FOLDER = "SMSAppDBFiles";

        public delegate void onDeleteHandler(Photo fItem);
        public event onDeleteHandler DeleteEvent;

        public delegate void onUploadHandler(Photo fItem);
        public event onUploadHandler UploadEvent;

        private ObservableCollection<Photo> _files;
        private string _currentFilePath;
        private Photo _selectedFileItem;

        public ObservableCollection<Photo> Files { get => _files; set { _files = value; RaisePropertyChanged(); } }
        public string CurrentFilePath { get => _currentFilePath; set { _currentFilePath = value; RaisePropertyChanged(); } }
        public Photo SelectedFileItem { get => _selectedFileItem; set { _selectedFileItem = value; RaisePropertyChanged(); } }

        public string Title { get => _title; set { _title = value; RaisePropertyChanged(); } }
        public string Description { get => _description; set { _description = value; RaisePropertyChanged(); } }


        public DelegateCommand UploadFileCmd { get; set; }
        public DelegateCommand DeleteCmd { get; set; }
        public DelegateCommand DownloadCmd { get; set; }

        private AlertsService _alerts;
        private string _title;
        private string _description;

        public FilePickerControlViewModel(AlertsService alerts)
        {
            Files = new ObservableCollection<Photo>();
            UploadFileCmd = new DelegateCommand(UploadFile);
            DeleteCmd = new DelegateCommand(DeleteFile);
            DownloadCmd = new DelegateCommand(DownloadFile);
            _alerts = alerts;
        }

        private void UploadFile()
        {
            if (String.IsNullOrEmpty(CurrentFilePath)) { _alerts.ShowWarningMsg("Please, select a file first"); return; }
            if (String.IsNullOrEmpty(Title)) { _alerts.ShowWarningMsg("Please, input a name first"); return; }

            var fileName = CurrentFilePath;
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var tempFileName = Path.ChangeExtension(Guid.NewGuid().ToString(), Path.GetExtension(fileName));
            var tempFileDir = Path.Combine(directory, FILES_FOLDER);

            if (!Directory.Exists(tempFileDir)) Directory.CreateDirectory(tempFileDir);

            var tempFilePath = Path.Combine(tempFileDir, tempFileName);

            File.Copy(fileName, tempFilePath);
            var fItem = new Photo() { Title = Title, Description = Description, URL = tempFilePath };

            Files.Add(fItem);
            Title = "";

            UploadEvent?.Invoke(fItem);
        }

        private void DeleteFile()
        {
            if (SelectedFileItem == null) return;
            if (_alerts.ShowQuestionYesNoMsg("Do you want to delete this file?") != MessageBoxResult.Yes) return;

            DeleteEvent?.Invoke(SelectedFileItem);

            try
            {
                File.Delete(SelectedFileItem.URL);
            }
            catch (Exception)
            {

            }
            Files.Remove(SelectedFileItem);
        }

        private void DownloadFile()
        {

            try
            {
                Process.Start(SelectedFileItem.URL);
            }
            catch (Exception)
            {

                _alerts.ShowWarningMsg("Cannot open the file. The URL is invalid.");
            }
        }
    }
}
