using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace SMSApp.Repositories
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {

        private string photosFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "SMSAppPhotos");
        public PhotoRepository(Context dbContext)
            : base(dbContext)
        {

        }

        public void AddAndStore(Photo photo)
        {
            if (!Directory.Exists(photosFolder)) Directory.CreateDirectory(photosFolder);
            var tempPath = Path.ChangeExtension(Path.GetRandomFileName(),Path.GetExtension(photo.URL));
            File.Copy(photo.URL, Path.Combine(photosFolder, tempPath));
            photo.URL = tempPath;
            Add(photo);
        }
    }
}
