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


            // Views
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<UserManagerView>().AsSelf();
            builder.RegisterType<SendSMSView>().AsSelf();
            builder.RegisterType<FarmOwnerManagerView>().AsSelf();
            builder.RegisterType<FarmOwnerAddView>().AsSelf();
            builder.RegisterType<FarmManagerView>().AsSelf();
            builder.RegisterType<FarmAddView>().AsSelf();
            builder.RegisterType<PlantManagerView>().AsSelf();
            builder.RegisterType<PlantAddView>().AsSelf();
            builder.RegisterType<DiseaseManagerView>().AsSelf();
            builder.RegisterType<DiseaseAddView>().AsSelf();
            builder.RegisterType<PestManagerView>().AsSelf();
            builder.RegisterType<PestAddView>().AsSelf();
            builder.RegisterType<UserAddView>().AsSelf();
            builder.RegisterType<SettingsView>().AsSelf();
            builder.RegisterType<BroadcastManagerView>().AsSelf();
            builder.RegisterType<LoginView>().AsSelf();

            // ViewModels
            builder.RegisterType<MainWindowViewModel>().AsSelf();
            builder.RegisterType<FarmOwnerManagerViewModel>().AsSelf();
            builder.RegisterType<FarmOwnerAddViewModel>().AsSelf();
            builder.RegisterType<FarmManagerViewModel>().AsSelf();
            builder.RegisterType<FarmAddViewModel>().AsSelf();
            builder.RegisterType<PlantManagerViewModel>().AsSelf();
            builder.RegisterType<PlantAddViewModel>().AsSelf();
            builder.RegisterType<DiseaseManagerViewModel>().AsSelf();
            builder.RegisterType<DiseaseAddViewModel>().AsSelf();
            builder.RegisterType<PestManagerViewModel>().AsSelf();
            builder.RegisterType<PestAddViewModel>().AsSelf();
            builder.RegisterType<SendSMSViewModel>().AsSelf();
            builder.RegisterType<NavigationMenuViewModel>().AsSelf();
            builder.RegisterType<UserManagerViewModel>().AsSelf();
            builder.RegisterType<UserAddViewModel>().AsSelf();
            builder.RegisterType<BroadcastSettingsViewModel>().AsSelf();
            builder.RegisterType<BroadcastManagerViewModel>().AsSelf();
            builder.RegisterType<LoginViewModel>().AsSelf();

            //models
            builder.RegisterType<User>().AsSelf();
            builder.RegisterType<FarmOwner>().AsSelf();
            
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
