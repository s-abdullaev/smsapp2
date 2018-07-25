using Autofac;
using Prism.Events;
using SMSApp.DataAccess;
using SMSApp.ExtensionMethods;
using SMSApp.Repositories;
using SMSApp.Repositories.Core;
using SMSApp.Services;
using SMSApp.ViewModels;
using SMSApp.Views;


namespace SMSApp.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainWindowViewModel>().AsSelf();
            
            builder.RegisterType<UserManagerView>().AsSelf();
            builder.RegisterType<UserManagerViewModel>().AsSelf();

            builder.RegisterType<SendSMSView>().AsSelf();
            builder.RegisterType<SendSMSViewModel>().AsSelf();

            builder.RegisterType<NavigationMenuViewModel>().AsSelf();


            builder.RegisterType<FarmOwnerManagerView>().AsSelf();
            builder.RegisterType<FarmManagerView>().AsSelf();
            builder.RegisterType<PlantManagerView>().AsSelf();
            builder.RegisterType<DiseaseManagerView>().AsSelf();
            builder.RegisterType<PestManagerView>().AsSelf();

            builder.RegisterType<UserAddView>().AsSelf();
            builder.RegisterType<UserAddViewModel>().AsSelf();

            builder.RegisterType<SettingsView>().AsSelf();
            builder.RegisterType<BroadcastSettingsViewModel>().AsSelf();

            builder.RegisterType<BroadcastManagerView>().AsSelf();
            builder.RegisterType<BroadcastManagerViewModel>().AsSelf();

            //models
            builder.RegisterType<User>().AsSelf();
            
            //singleton instance of unitOfWork for data access
            builder.RegisterType<Context>().AsSelf().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterType<SMSService>().AsSelf().SingleInstance();
            builder.RegisterType<AlertsService>().AsSelf().SingleInstance();

            //registers container itself
            builder.RegisterSelf();

            return builder.Build();
        }

    }
}
