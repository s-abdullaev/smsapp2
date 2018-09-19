using Autofac;
using Prism.Commands;
using SMSApp.Controls.FilePicker;
using SMSApp.DataAccess;
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

            AddFarmOwnerPhotoCommand = new DelegateCommand(() =>
            {
                var dialog = container.Resolve<PhotoAddView>();
                dialog.ShowDialog();
                RaisePropertyChanged("Model");
            });
        }

        public override void ExecuteAddEntityCommand()
        {
            Model.User = uw.Users.CurrentUser();
            base.ExecuteAddEntityCommand();
        }


        public DelegateCommand AddFarmOwnerPhotoCommand { set; get; }
    }
}
