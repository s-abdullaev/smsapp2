using Prism.Mvvm;
using Prism.Commands;
using SMSApp.DataAccess;
using System.Collections.ObjectModel;

using SMSApp.Views;
using System.Threading.Tasks;

namespace SMSApp.ViewModels
{
    internal class UserManagerViewModel : BindableBase
    {
        private ObservableCollection<User> usersList;
        public ObservableCollection<User> UsersList
        {
            get
            {
                return usersList;
            }
            set
            {
                SetProperty(ref usersList, value);
            }
        }

        public UserManagerViewModel()
        {
            OpenAddUserCommand = new DelegateCommand(ExecuteOpenAddUserCommand);
            LoadUsers();
        }

        private void LoadUsers()
        {
            Task.Factory.StartNew(() =>
            {
                using (Context context = new Context())
                {
                    UsersList = new ObservableCollection<User>(context.Users);
                }
            });
        }

        public DelegateCommand OpenAddUserCommand { get; private set; }
        public void ExecuteOpenAddUserCommand()
        {
            UserAddView view = new UserAddView();
            view.ShowDialog();
        }
    }
}