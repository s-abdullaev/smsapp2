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

            using (Context context = new Context())
            {
                Console.WriteLine(context.Users.Find(1));
                context.SaveChanges();
            }
        }
    }
}