using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace SMSApp.Controls.FilePicker
{
    /// <summary>
    /// Interaction logic for FilePickerControlView.xaml
    /// </summary>
    public partial class FilePickerControlView : UserControl
    {
        public static readonly DependencyProperty SelectedPathProperty =
        DependencyProperty.Register("Files", typeof(string), typeof(FilePickerControlView), new UIPropertyMetadata(string.Empty));

        public string SelectedPath
        {
            get { return (string)this.GetValue(SelectedPathProperty); }
            set {
                this.SetValue(SelectedPathProperty, value); }
        }

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
