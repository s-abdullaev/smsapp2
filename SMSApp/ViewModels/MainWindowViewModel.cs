using Prism.Mvvm;
using Prism.Commands;

using SMSApp.Views;

namespace SMSApp.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            OpenUserManagerCommand = new DelegateCommand(ExecuteOpenUserManagerCommand);
        }

        public DelegateCommand OpenUserManagerCommand { get; private set; }
        private void ExecuteOpenUserManagerCommand()
        {
            UserManagerView managerView = new UserManagerView();
            managerView.ShowDialog();
        }
    }
}
