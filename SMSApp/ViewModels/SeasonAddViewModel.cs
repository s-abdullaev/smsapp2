using Autofac;
using Prism.Commands;
using SMSApp.Controls.ItemPicker;
using SMSApp.DataAccess;
using System.Linq;
using SMSApp.Repositories.Core;
using SMSApp.ExtensionMethods;

namespace SMSApp.ViewModels
{
    public class SeasonAddViewModel : ViewModelBase
    {
        private Season _model;

        public ItemPickerControlViewModel<Plant> PlantsPickerVwMdl { get; set; } = new ItemPickerControlViewModel<Plant>();

        protected IUnitOfWork uw;
        protected bool _isUpdate;

        public Season Model
        {
            get { return _model; }
            set { _model = value; RaisePropertyChanged(); }
        }
        
        public DelegateCommand SaveCmd { get; set; }

        public SeasonAddViewModel(IContainer container, bool isUpdate, IUnitOfWork unitOfWork, Season model, Geoposition geop) : base(container)
        {
            Model = model;
            
            _isUpdate = isUpdate;
            uw = unitOfWork;

            SaveCmd = new DelegateCommand(() =>
            {
                Model.Plants.Clear();
                uw.SeasonPlants.AddSeasonPlants(Model, PlantsPickerVwMdl.ChosenItems);

                if (!isUpdate)
                {
                    geop.Seasons.Add(Model);
                }
                uw.Complete();
                CloseAction();
            }, ()=>!Model.HasErrors);

            Model.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => { if (e.PropertyName == "HasErrors") SaveCmd.RaiseCanExecuteChanged(); };

            PlantsPickerVwMdl.ChosenItems = (from sp in model.Plants select sp.Plant).xToObservableCollection<Plant>();
            PlantsPickerVwMdl.AvailableItems = uw.Plants.GetAll().Where((p) => !PlantsPickerVwMdl.ChosenItems.Contains(p)).xToObservableCollection<Plant>();
        }

    }
}
