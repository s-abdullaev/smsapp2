using Autofac;
using System;
using Prism.Mvvm;
using Prism.Commands;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;

namespace SMSApp.ViewModels
{
    public class UserAddViewModel : ViewModelBase
    {
        //Properties
        private IUnitOfWork uw;
        private bool _isUpdate;

        public User UserModel { get; set; }
        
        //Constructor
        public UserAddViewModel(IContainer container, IUnitOfWork unitOfWork, User userModel, bool isUpdate=false): base(container)
        {
            _isUpdate = isUpdate;

            uw = unitOfWork;
            UserModel = userModel;

            UserModel.PropertyChanged += UserModel_PropertyChanged;
            AddUserCommand = new DelegateCommand(ExecuteAddUserCommand, CanExecuteAddUserCommand);
        }

        private void UserModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "HasErrors") AddUserCommand.RaiseCanExecuteChanged();
        }

        private bool CanExecuteAddUserCommand()
        {
            return UserModel != null && !UserModel.HasErrors;
        }

        public bool CanUpdateUsers
        {
            get { return uw.Users.CheckPermission(UserModel, Enums.UserPermissions.CanUpdateUsers); }
            set {uw.Users.ChangePermission(UserModel, Enums.UserPermissions.CanUpdateUsers, value); RaisePropertyChanged(); }
        }

        public bool CanUpdateEntities
        {
            get { return uw.Users.CheckPermission(UserModel, Enums.UserPermissions.CanUpdateEntities); }
            set { uw.Users.ChangePermission(UserModel, Enums.UserPermissions.CanUpdateEntities, value); RaisePropertyChanged(); }
        }

        public bool CanSendBroadcasts
        {
            get { return uw.Users.CheckPermission(UserModel, Enums.UserPermissions.CanSendBroadcasts); }
            set { uw.Users.ChangePermission(UserModel, Enums.UserPermissions.CanSendBroadcasts, value); RaisePropertyChanged(); }
        }

        public bool CanReadEntities
        {
            get { return uw.Users.CheckPermission(UserModel, Enums.UserPermissions.CanReadEntities); }
            set { uw.Users.ChangePermission(UserModel, Enums.UserPermissions.CanReadEntities, value); RaisePropertyChanged(); }
        }

        public bool CanPrintReports
        {
            get { return uw.Users.CheckPermission(UserModel, Enums.UserPermissions.CanPrintReports); }
            set { uw.Users.ChangePermission(UserModel, Enums.UserPermissions.CanPrintReports, value); RaisePropertyChanged(); }
        }

        //Add User Command
        public DelegateCommand AddUserCommand { get; set; }
        public void ExecuteAddUserCommand()
        {
            //Perform data insertion using Repository operations
            if(!_isUpdate) uw.Users.Add(UserModel);
            uw.Complete();
            CloseAction();
        }
    }
}