using Autofac;
using SMSApp.Controls.FilePicker;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;

namespace SMSApp.ViewModels
{
    public class PlantAddViewModel : EntityAddViewModel<Plant>
    {

        private FilePickerControlViewModel _filePickerVwMdl;
        public FilePickerControlViewModel FilePickerVwMdl { get => _filePickerVwMdl; set { _filePickerVwMdl = value; RaisePropertyChanged(); } }

        public PlantAddViewModel(IContainer container, IUnitOfWork unitOfWork, Plant model, bool isUpdate=false) : base(container, isUpdate, unitOfWork, model)
        {
            FilePickerVwMdl = container.Resolve<FilePickerControlViewModel>();
            FilePickerVwMdl.Files = Model.Photos;
        }
    }
}
