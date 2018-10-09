using Autofac;

namespace SMSApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public FarmOwnerManagerViewModel FarmOwnerVwMdl { get; }
        public PlantManagerViewModel PlantVwMdl { get; }
        public PestManagerViewModel PestVwMdl { get; }
        public DiseaseManagerViewModel DiseaseVwMdl { get; }
        public FarmManagerViewModel FarmVwMdl { get; }

        public MainWindowViewModel(IContainer container) : base(container)
        {
            FarmOwnerVwMdl = container.Resolve<FarmOwnerManagerViewModel>();
            PlantVwMdl = container.Resolve<PlantManagerViewModel>();
            PestVwMdl = container.Resolve<PestManagerViewModel>();
            DiseaseVwMdl = container.Resolve<DiseaseManagerViewModel>();
            FarmVwMdl = container.Resolve<FarmManagerViewModel>();
        }

        
    }
}
