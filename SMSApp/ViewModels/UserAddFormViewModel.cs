using System;
using Prism.Mvvm;
using Prism.Commands;
using System.ComponentModel;

using SMSApp.Models;
using SMSApp.DataAccess;

namespace SMSApp.ViewModels
{
    internal class UserAddFormViewModel : BindableBase
    {
        //Properties
        private UserAddFormModel userAddFormModel;
        public UserAddFormModel UserAddFormModel
        {
            get
            {
                return userAddFormModel;
            }
            set
            {
                if (userAddFormModel != null) userAddFormModel.PropertyChanged -= UserPropertyChanged;
                SetProperty(ref userAddFormModel, value);
                if (userAddFormModel != null) userAddFormModel.PropertyChanged += UserPropertyChanged;
            }
        }

        //Constructor
        public UserAddFormViewModel(object parent)
        {
            UserAddFormModel = new UserAddFormModel();
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
                Name = UserAddFormModel.Name,
                Login = UserAddFormModel.Login,
                Password = UserAddFormModel.Password,
                Email = UserAddFormModel.Email,
                Permissions = UserAddFormModel.GetPermissions(),
                CreatedDate = DateTime.Now
            };
            //Perform data insertion using Repository operations
        }
        public bool CanExecuteAddUserCommand()
        {
            if (UserAddFormModel == null)
                return false;
            if (String.IsNullOrWhiteSpace(UserAddFormModel.Name))
                return false;
            if (String.IsNullOrWhiteSpace(UserAddFormModel.Email))
                return false;
            if (String.IsNullOrWhiteSpace(UserAddFormModel.Login))
                return false;
            if (String.IsNullOrWhiteSpace(UserAddFormModel.Password))
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