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
            AddUserCommand = new DelegateCommand(ExecuteAddUserCommand);
        }

        public bool CanUpdateUsers
        {
            get { return uw.Users.CheckPermission(UserModel, Enums.UserPermissions.CanUpdateUsers); }
            set { uw.Users.SetPermission(UserModel, Enums.UserPermissions.CanUpdateUsers); RaisePropertyChanged(); }
        }

        public bool CanUpdateEntities
        {
            get { return uw.Users.CheckPermission(UserModel, Enums.UserPermissions.CanUpdateEntities); }
            set { uw.Users.SetPermission(UserModel, Enums.UserPermissions.CanUpdateEntities); RaisePropertyChanged(); }
        }

        public bool CanSendBroadcasts
        {
            get { return uw.Users.CheckPermission(UserModel, Enums.UserPermissions.CanSendBroadcasts); }
            set { uw.Users.SetPermission(UserModel, Enums.UserPermissions.CanSendBroadcasts); RaisePropertyChanged(); }
        }

        public bool CanReadEntities
        {
            get { return uw.Users.CheckPermission(UserModel, Enums.UserPermissions.CanReadEntities); }
            set { uw.Users.SetPermission(UserModel, Enums.UserPermissions.CanReadEntities); RaisePropertyChanged(); }
        }

        public bool CanPrintReports
        {
            get { return uw.Users.CheckPermission(UserModel, Enums.UserPermissions.CanPrintReports); }
            set { uw.Users.SetPermission(UserModel, Enums.UserPermissions.CanPrintReports); RaisePropertyChanged(); }
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