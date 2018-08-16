using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telerik.Windows.Cloud;

namespace SMSApp.Controls.FilePicker
{
    public class FileProvider : ICloudUploadProvider
    {
        const string FILES_FOLDER = "SMSAppDBFiles";

        public Task<object> UploadFileAsync(string fileName, Stream fileStream, CloudUploadFileProgressChanged uploadProgressChanged, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew<object>(() => UploadFile(fileName, fileStream, uploadProgressChanged, cancellationToken), cancellationToken);
        }

        private object UploadFile(string fileName, Stream fileStream, CloudUploadFileProgressChanged uploadProgressChanged, CancellationToken cancellationToken)
        {
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var tempFileName = Path.ChangeExtension(Guid.NewGuid().ToString(), Path.GetExtension(fileName));
            var tempFilePath = Path.Combine(directory, FILES_FOLDER, fileName);

            File.Copy(fileName, tempFilePath);

            return tempFilePath;
        }
    }
}
