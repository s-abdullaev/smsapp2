using Autofac;
using Prism.Commands;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using SMSApp.Views;
using System.Collections.ObjectModel;

namespace SMSApp.ViewModels
{
    public class FarmManagerViewModel : EntityManagerViewModel<Farm>
    {

        public DelegateCommand NewMapCmd { get; set; }
        public DelegateCommand ViewMapCmd { get; set; }
        public DelegateCommand RemoveMapCmd { get; set; }

        public DelegateCommand NewSoilReadingCmd { get; set; }
        public DelegateCommand ViewSoilReadingCmd { get; set; }
        public DelegateCommand RemoveSoilReadingCmd { get; set; }

        public FarmManagerViewModel(IContainer container, IUnitOfWork unitOfWork) : base(container, unitOfWork)
        {

            NewMapCmd = new DelegateCommand(ExecuteNewMapCommand, CanExecuteNewMapCommand);
            ViewMapCmd = new DelegateCommand(ExecuteEditMapCommand, CanExecuteEditMapCommand);
            RemoveMapCmd = new DelegateCommand(ExecuteRemoveMapCommand, CanExecuteEditMapCommand);


            NewSoilReadingCmd = new DelegateCommand(ExecuteNewSoilReadingCommand, CanExecuteNewSoilReadingCommand);
            ViewSoilReadingCmd = new DelegateCommand(ExecuteEditSoilReadingCommand, CanExecuteEditSoilReadingCommand);
            RemoveSoilReadingCmd = new DelegateCommand(ExecuteRemoveSoilReadingCommand, CanExecuteEditSoilReadingCommand);
        }


        private ObservableCollection<SoilReading> _soilReadings;
        public ObservableCollection<SoilReading> SoilReadings
        {
            get { return _soilReadings; }
            set {
                _soilReadings = value;

                RaisePropertyChanged();

                NewSoilReadingCmd.RaiseCanExecuteChanged();
                ViewSoilReadingCmd.RaiseCanExecuteChanged();
                RemoveSoilReadingCmd.RaiseCanExecuteChanged();


            }
        }

        private SoilReading _selectedSoilReading;
        public SoilReading SelectedSoilReading
        {
            get { return _selectedSoilReading; }
            set {
                _selectedSoilReading = value;

                RaisePropertyChanged();

                NewSoilReadingCmd.RaiseCanExecuteChanged();
                ViewSoilReadingCmd.RaiseCanExecuteChanged();
                RemoveSoilReadingCmd.RaiseCanExecuteChanged();
            }
        }



        private ObservableCollection<Geoposition> _geopositions;
        public ObservableCollection<Geoposition> Geopositions
        {
            get { return _geopositions; }
            set {
                _geopositions = value;
                RaisePropertyChanged();

                NewMapCmd.RaiseCanExecuteChanged();
                ViewMapCmd.RaiseCanExecuteChanged();
                RemoveMapCmd.RaiseCanExecuteChanged();
            }
        }

        private Geoposition _selectedGeoposition;
        public Geoposition SelectedGeoposition
        {
            get { return _selectedGeoposition; }
            set {
                _selectedGeoposition = value;

                RaisePropertyChanged();

                NewMapCmd.RaiseCanExecuteChanged();
                ViewMapCmd.RaiseCanExecuteChanged();
                RemoveMapCmd.RaiseCanExecuteChanged();

                SoilReadings = null;
                SelectedSoilReading = null;

                if (_selectedGeoposition == null) return;

                SoilReadings = SelectedGeoposition.SoilReadings;
            }
        }

        public override void ExecuteOpenAddItemCommand()
        {
            FarmAddView view = _container.Resolve<FarmAddView>();
            view.ShowDialog();
            RaisePropertyChanged("Items");
        }

        public override void ExecuteEditAddItemCommand()
        {
            FarmAddView view = _container.Resolve<FarmAddView>(
                new NamedParameter("viewModel", _container.Resolve<FarmAddViewModel>(
                    new NamedParameter("model", SelectedItem),
                    new NamedParameter("isUpdate", true)
                )));
            view.ShowDialog();
            RaisePropertyChanged("Items");
        }


        public void ExecuteNewMapCommand()
        {
            GeopositionAddView view = _container.Resolve<GeopositionAddView>(
                new NamedParameter("viewModel", _container.Resolve<GeopositionAddViewModel>(
                    new NamedParameter("isUpdate", false),
                    new NamedParameter("farm", SelectedItem)
                )));
            view.ShowDialog();
            RaisePropertyChanged("Geopositions");
        }

        public void ExecuteEditMapCommand()
        {
            GeopositionAddView view = _container.Resolve<GeopositionAddView>(
                new NamedParameter("viewModel", _container.Resolve<GeopositionAddViewModel>(
                    new NamedParameter("model", SelectedGeoposition),
                    new NamedParameter("isUpdate", true),
                    new NamedParameter("farm", SelectedItem)
                )));
            view.ShowDialog();
            RaisePropertyChanged("Geopositions");
        }

        public void ExecuteRemoveMapCommand()
        {
            if (_alerts.ShowQuestionYesNoMsg("Do you want to delete this record?") != System.Windows.MessageBoxResult.Yes) return;

            uw.Geopositions.Remove(SelectedGeoposition);
            uw.Complete();
            
            RaisePropertyChanged("Geopositions");
        }

        public bool CanExecuteNewMapCommand()
        {
            return SelectedItem != null;
        }

        public bool CanExecuteEditMapCommand()
        {
            return SelectedItem != null && SelectedGeoposition!=null;
        }


        public void ExecuteNewSoilReadingCommand()
        {
            SoilReadingAddView view = _container.Resolve<SoilReadingAddView>(
                new NamedParameter("viewModel", _container.Resolve<SoilReadingAddViewModel>(
                    new NamedParameter("isUpdate", false),
                    new NamedParameter("geop", SelectedGeoposition)
                )));
            view.ShowDialog();
            RaisePropertyChanged("SoilReadings");
        }

        public void ExecuteEditSoilReadingCommand()
        {
            SoilReadingAddView view = _container.Resolve<SoilReadingAddView>(
                new NamedParameter("viewModel", _container.Resolve<SoilReadingAddViewModel>(
                    new NamedParameter("model", SelectedSoilReading),
                    new NamedParameter("isUpdate", true),
                    new NamedParameter("geop", SelectedGeoposition)
                )));
            view.ShowDialog();
            RaisePropertyChanged("SoilReadings");
        }


        public void ExecuteRemoveSoilReadingCommand()
        {
            if (_alerts.ShowQuestionYesNoMsg("Do you want to delete this record?") != System.Windows.MessageBoxResult.Yes) return;

            uw.SoilReadings.Remove(SelectedSoilReading);
            uw.Complete();

            RaisePropertyChanged("SoilReadings");
        }

        public bool CanExecuteNewSoilReadingCommand()
        {
            return SelectedGeoposition != null;
        }

        public bool CanExecuteEditSoilReadingCommand()
        {
            return SelectedGeoposition != null && SelectedSoilReading != null;
        }

        public override void SelectedItemChanged()
        {
            base.SelectedItemChanged();

            SelectedGeoposition = null;
            Geopositions = null;

            if (SelectedItem == null) return;

            Geopositions = SelectedItem.Geopositions;
        }
    }
}
