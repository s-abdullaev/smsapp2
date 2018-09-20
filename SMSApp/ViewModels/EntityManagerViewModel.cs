using Autofac;
using Prism.Commands;
using SMSApp.Repositories.Core;
using System.Collections.Generic;
using SMSApp.ExtensionMethods;
using SMSApp.Services;

namespace SMSApp.ViewModels
{
    public class EntityManagerViewModel<T> : ViewModelBase where T:class
    {
        public EntityManagerViewModel(IContainer container, IUnitOfWork unitOfWork) : base(container)
        {
            uw = unitOfWork;
            OpenAddEntityCommand = new DelegateCommand(ExecuteOpenAddItemCommand);
            OpenEditEntityCommand = new DelegateCommand(ExecuteEditAddItemCommand, () => selectedItem != null);
            RemoveEntityCommand = new DelegateCommand(ExecuteRemoveItemCommand, () => selectedItem != null);
            _alerts = container.Resolve<AlertsService>();
        }

        private IUnitOfWork uw;
        private AlertsService _alerts;

        public DelegateCommand OpenAddEntityCommand { get; private set; }
        public DelegateCommand OpenEditEntityCommand { get; private set; }
        public DelegateCommand RemoveEntityCommand { get; private set; }

        public IEnumerable<T> Items
        {
            // TODO: refactor entitynbame pluralization
            get => GetRepository().GetAll();
        }

        public IRepository<T> GetRepository()
        {
            return uw.GetRepository<T>(typeof(T).Name.xPluralize());
        }

        private T selectedItem;

        public T SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
                OpenEditEntityCommand.RaiseCanExecuteChanged();
                RemoveEntityCommand.RaiseCanExecuteChanged();
            }
        }

        public virtual void ExecuteOpenAddItemCommand()
        {
        }

        public virtual void ExecuteEditAddItemCommand()
        {
        }

        public virtual void ExecuteRemoveItemCommand()
        {
            if (_alerts.ShowQuestionYesNoMsg("Do you want to delete this record?") != System.Windows.MessageBoxResult.Yes) return;

            GetRepository().Remove(SelectedItem);
            uw.Complete();
            RaisePropertyChanged("Items");
        }
    }
}
