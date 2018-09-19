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
            var tempFileDir = Path.Combine(directory, FILES_FOLDER);

            if (!Directory.Exists(tempFileDir)) Directory.CreateDirectory(tempFileDir);

            var tempFilePath = Path.Combine(tempFileDir, tempFileName);

            using (FileStream f = new FileStream(tempFilePath, FileMode.CreateNew, FileAccess.Write))
            {
                int length = 256;
                Byte[] buffer = new Byte[length];
                int bytesRead = fileStream.Read(buffer, 0, length);
                // write the required bytes
                while (bytesRead > 0)
                {
                    f.Write(buffer, 0, bytesRead);
                    bytesRead = fileStream.Read(buffer, 0, length);
                    uploadProgressChanged(f.Length);
                }
                f.Close();
            }
            //File.Copy(fileName, tempFilePath);

            return tempFilePath;
        }
    }
}
