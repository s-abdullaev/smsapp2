using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SMSApp.Controls.FilePicker
{
    /// <summary>
    /// Interaction logic for FilePickerControlView.xaml
    /// </summary>
    /// 

    public class FileItem
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }

    public partial class FilePickerControlView : UserControl
    {

        //public delegate void onFileUploaded(FileItem fileItem);
        //public event onFileUploaded FileUploaded;

        public FilePickerControlView()
        {
            InitializeComponent();
        }
        
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                txtFilePath.Text = openFileDialog.FileName;
        }

        //private void btnUpload_Click(object sender, RoutedEventArgs e)
        //{

        //    var fileName = txtFilePath.Text;
        //    var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        //    var tempFileName = Path.ChangeExtension(Guid.NewGuid().ToString(), Path.GetExtension(fileName));
        //    var tempFileDir = Path.Combine(directory, FILES_FOLDER);

        //    if (!Directory.Exists(tempFileDir)) Directory.CreateDirectory(tempFileDir);

        //    var tempFilePath = Path.Combine(tempFileDir, tempFileName);

        //    File.Copy(fileName, tempFilePath);
        //    var fItem = new FileItem() { FileName = fileName, FilePath = tempFilePath };

        //    Files.Add(fItem);

        //    lstFiles.ItemsSource = Files;

        //    FileUploaded?.Invoke(fItem);
        //}

        //public static readonly DependencyProperty FilesProperty =
        //DependencyProperty.Register("Files", typeof(List<FileItem>), typeof(FilePickerControlView), new UIPropertyMetadata(new List<FileItem>()));

        //public List<FileItem> Files
        //{
        //    get { return (List<FileItem>)this.GetValue(FilesProperty); }
        //    set { this.SetValue(FilesProperty, value);}
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var _ofd = new OpenFileDialog();
        //    _ofd.Multiselect = false;
        //    _ofd.Filter = "Image|*.jpeg;*.jpg;*.png;*.gif;*.bmp|Documents|*.doc*; *.xls*;*.pdf;*.txt*;*.rtf;*.xml;|All Files|*.*";

        //    if (_ofd.ShowDialog() == true)
        //    {
        //        SelectedPath = _ofd.FileName;
        //    }
        //}
    }
}
