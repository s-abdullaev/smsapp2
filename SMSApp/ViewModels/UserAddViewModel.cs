using Autofac;
using System;
using Prism.Mvvm;
using Prism.Commands;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;

namespace SMSApp.ViewModels
{
    public class UserAddViewModel : EntityAddViewModel<User>
    {
        public UserAddViewModel(IContainer container, bool isUpdate, IUnitOfWork unitOfWork, User model) : base(container, isUpdate, unitOfWork, model)
        {
        }

        ////Properties
        //private IUnitOfWork uw;
        //protected bool _isUpdate;

        //public User UserModel { get; set; }

        ////Constructor
        //public UserAddViewModel(IContainer container, IUnitOfWork unitOfWork, User model, bool isUpdate=false): base(container)
        //{
        //    _isUpdate = isUpdate;

        //    uw = unitOfWork;
        //    UserModel = model;

        //    UserModel.PropertyChanged += UserModel_PropertyChanged;
        //    AddUserCommand = new DelegateCommand(ExecuteAddUserCommand, CanExecuteAddUserCommand);
        //}

        //private void UserModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == "HasErrors") AddUserCommand.RaiseCanExecuteChanged();
        //}

        //private bool CanExecuteAddUserCommand()
        //{
        //    return UserModel != null && !UserModel.HasErrors;
        //}
        ////Add User Command
        //public DelegateCommand AddUserCommand { get; set; }
        //public void ExecuteAddUserCommand()
        //{
        //    //Perform data insertion using Repository operations
        //    if(!_isUpdate) uw.Users.Add(UserModel);
        //    uw.Complete();
        //    CloseAction();
        //}

        public bool CanUpdateUsers
        {
            get { return uw.Users.CheckPermission(Model, Enums.UserPermissions.CanUpdateUsers); }
            set {uw.Users.ChangePermission(Model, Enums.UserPermissions.CanUpdateUsers, value); RaisePropertyChanged(); }
        }

        public bool CanUpdateEntities
        {
            get { return uw.Users.CheckPermission(Model, Enums.UserPermissions.CanUpdateEntities); }
            set { uw.Users.ChangePermission(Model, Enums.UserPermissions.CanUpdateEntities, value); RaisePropertyChanged(); }
        }

        public bool CanSendBroadcasts
        {
            get { return uw.Users.CheckPermission(Model, Enums.UserPermissions.CanSendBroadcasts); }
            set { uw.Users.ChangePermission(Model, Enums.UserPermissions.CanSendBroadcasts, value); RaisePropertyChanged(); }
        }

        public bool CanReadEntities
        {
            get { return uw.Users.CheckPermission(Model, Enums.UserPermissions.CanReadEntities); }
            set { uw.Users.ChangePermission(Model, Enums.UserPermissions.CanReadEntities, value); RaisePropertyChanged(); }
        }

        public bool CanPrintReports
        {
            get { return uw.Users.CheckPermission(Model, Enums.UserPermissions.CanPrintReports); }
            set { uw.Users.ChangePermission(Model, Enums.UserPermissions.CanPrintReports, value); RaisePropertyChanged(); }
        }

    }
}