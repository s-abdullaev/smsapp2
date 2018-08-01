using Autofac;
using Prism.Commands;
using SMSApp.ExtensionMethods;
using SMSApp.Repositories.Core;
using SMSApp.Validation;

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
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "HasErrors") AddEntityCommand.RaiseCanExecuteChanged();
        }

        //Properties
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
