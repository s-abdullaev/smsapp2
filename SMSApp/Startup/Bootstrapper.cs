using Autofac;
using SMSApp.DataAccess;
using SMSApp.ExtensionMethods;
using SMSApp.Repositories;
using SMSApp.Repositories.Core;
using SMSApp.ViewModels;
using SMSApp.Views;


namespace SMSApp.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainWindowViewModel>().AsSelf();
            
            builder.RegisterType<UserManagerView>().AsSelf();
            builder.RegisterType<UserManagerViewModel>().AsSelf();

            builder.RegisterType<SendSMSView>().AsSelf();
            builder.RegisterType<SendSMSViewModel>().AsSelf();

            builder.RegisterType<FarmOwnerManagerView>().AsSelf();
            builder.RegisterType<FarmManagerView>().AsSelf();
            builder.RegisterType<PlantManagerView>().AsSelf();
            builder.RegisterType<DiseaseManagerView>().AsSelf();
            builder.RegisterType<PestManagerView>().AsSelf();


            builder.RegisterType<UserAddView>().AsSelf();
            builder.RegisterType<UserAddViewModel>().AsSelf();


            //models
            builder.RegisterType<User>().AsSelf();
            
            //singleton instance of unitOfWork for data access
            builder.RegisterInstance<UnitOfWork>(new UnitOfWork(new DataAccess.Context())).As<IUnitOfWork>();

            //registers container itself
            builder.RegisterSelf();
            

            return builder.Build();
        }

    }
}
