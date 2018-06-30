using System;
using System.Windows;
using SMSApp.DataAccess;

namespace SMSApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (DataAccess.AppContext context = new DataAccess.AppContext())
            {
                var uow = new UnitOfWork(context);
                uow.Users.Add(new User
                {
                    UserId=1,
                    Login = "Logger",
                    Name = "somename",
                    CreatedDate = DateTime.Now,
                    Permissions = 3,
                });
                uow.Complete();
                var temp = uow.Users.Get(1);
            }
        }
    }
}