using Autofac;
using Prism.Commands;
using SMSApp.Controls.FilePicker;
using SMSApp.DataAccess;
using SMSApp.ExtensionMethods;
using SMSApp.Repositories.Core;
using SMSApp.Views;

namespace SMSApp.ViewModels
{
    public class FarmOwnerAddViewModel : EntityAddViewModel<FarmOwner>
    {
        private FilePickerControlViewModel _filePickerVwMdl;
        public FilePickerControlViewModel FilePickerVwMdl { get => _filePickerVwMdl; set { _filePickerVwMdl = value; RaisePropertyChanged(); } }

        public FarmOwnerAddViewModel(IContainer container, IUnitOfWork unitOfWork, FarmOwner model, bool isUpdate = false) : base(container, isUpdate, unitOfWork, model)
        {

            FilePickerVwMdl = container.Resolve<FilePickerControlViewModel>();
            FilePickerVwMdl.Files = Model.Photos;
            //FilePickerVwMdl.UploadEvent += (f) =>
            //{
            //    Model.Photos.Add(f);
            //};
            //FilePickerVwMdl.DeleteEvent += (f) =>
            //{
            //    Model.Photos.Remove(f);
            //};


            //AddFarmOwnerPhotoCommand = new DelegateCommand(() =>
            //{
            //    var dialog = container.Resolve<PhotoAddView>();
            //    dialog.ShowDialog();
            //    RaisePropertyChanged("Model");
            //});
        }

        //public override void ExecuteAddEntityCommand()
        //{
        //    Model.User = uw.Users.CurrentUser();
        //    base.ExecuteAddEntityCommand();
        //}


        //public DelegateCommand AddFarmOwnerPhotoCommand { set; get; }
    }
}
