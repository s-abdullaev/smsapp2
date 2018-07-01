using System;
using Prism.Mvvm;
using Prism.Commands;
using System.ComponentModel;

using SMSApp.Models;
using SMSApp.DataAccess;

namespace SMSApp.ViewModels
{
    internal class UserAddViewModel : BindableBase
    {
        //Properties
        private UserAddModel userAddModel;
        public UserAddModel UserAddModel
        {
            get
            {
                return userAddModel;
            }
            set
            {
                if (userAddModel != null) userAddModel.PropertyChanged -= UserPropertyChanged;
                SetProperty(ref userAddModel, value);
                if (userAddModel != null) userAddModel.PropertyChanged += UserPropertyChanged;
            }
        }

        //Constructor
        public UserAddViewModel(object parent)
        {
            UserAddModel = new UserAddModel();
            AddUserCommand = new DelegateCommand(ExecuteAddUserCommand, CanExecuteAddUserCommand);
            CancelCommand = new DelegateCommand(() => ExecuteCancelCommand(parent));
        }
        
        #region Commands
        //Add User Command
        public DelegateCommand AddUserCommand { get; set; }
        public void ExecuteAddUserCommand()
        {
            User user = new User()
            {
                Name = UserAddModel.Name,
                Login = UserAddModel.Login,
                Password = UserAddModel.Password,
                Email = UserAddModel.Email,
                Permissions = UserAddModel.GetPermissions(),
                CreatedDate = DateTime.Now
            };
            //Perform data insertion using Repository operations
        }
        public bool CanExecuteAddUserCommand()
        {
            if (UserAddModel == null)
                return false;
            if (String.IsNullOrWhiteSpace(UserAddModel.Name))
                return false;
            if (String.IsNullOrWhiteSpace(UserAddModel.Email))
                return false;
            if (String.IsNullOrWhiteSpace(UserAddModel.Login))
                return false;
            if (String.IsNullOrWhiteSpace(UserAddModel.Password))
                return false;
            return true;
        }

        //Cancel Command
        public DelegateCommand CancelCommand { get; private set; }
        private void ExecuteCancelCommand(object parent) => (parent as System.Windows.Window).Close();
        #endregion

        private void UserPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            AddUserCommand.RaiseCanExecuteChanged();
        }
    }
}