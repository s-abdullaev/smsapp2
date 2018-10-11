using Autofac;
using Prism.Commands;
using SMSApp.Controls.FilePicker;
using SMSApp.DataAccess;
using SMSApp.ExtensionMethods;
using SMSApp.Repositories.Core;
using SMSApp.Validation;
using System.Collections.ObjectModel;

namespace SMSApp.ViewModels
{
    public class EntityAddViewModel<T> : ViewModelBase where T : ValidationModelBase
    {
        public EntityAddViewModel(IContainer container,bool isUpdate , IUnitOfWork unitOfWork, T model) : base(container)
        {
            _isUpdate = isUpdate;
            uw = unitOfWork;
            Model = model;
            Model.PropertyChanged += Model_PropertyChanged;
            AddEntityCommand = new DelegateCommand(ExecuteAddEntityCommand, CanExecuteAddEntityCommand);

            FilePickerVwMdl = container.Resolve<FilePickerControlViewModel>();
            var photosProp = Model.GetType().GetProperty("Photos");

            if (photosProp != null)
            {
                FilePickerVwMdl.Files = (ObservableCollection<Photo>)photosProp.GetValue(Model);
            }
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "HasErrors") AddEntityCommand.RaiseCanExecuteChanged();
        }

        //Properties
        private FilePickerControlViewModel _filePickerVwMdl;
        public FilePickerControlViewModel FilePickerVwMdl { get => _filePickerVwMdl; set { _filePickerVwMdl = value; RaisePropertyChanged(); } }



        protected IUnitOfWork uw;
        protected bool _isUpdate;

        public T Model { get; set; }

        //Add User Command
        public DelegateCommand AddEntityCommand { get; set; }
        public virtual void ExecuteAddEntityCommand()
        {
            //Perform data insertion using Repository operations
            if (!_isUpdate) GetRepository().Add(Model);
            uw.Complete();
            CloseAction();
        }

        public IRepository<T> GetRepository()
        {
            return uw.GetRepository<T>(typeof(T).Name.xPluralize());
        }

        private bool CanExecuteAddEntityCommand()
        {
            return Model != null && !Model.HasErrors;
        }
    }
}
