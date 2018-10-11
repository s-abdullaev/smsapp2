using Autofac;
using Microsoft.Win32;
using Prism.Commands;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SMSApp.ViewModels
{
    public class GeopositionAddViewModel : ViewModelBase
    {
        private Geoposition _model;

        protected IUnitOfWork uw;
        protected bool _isUpdate;

        public Geoposition Model
        {
            get { return _model; }
            set { _model = value; RaisePropertyChanged(); }
        }

        private string _shapeFilePath;

        public string ShapeFilePath
        {
            get { return _shapeFilePath; }
            set { _shapeFilePath = value; RaisePropertyChanged(); }
        }

        public DelegateCommand BrowseCmd { get; set; }
        public DelegateCommand SaveCmd { get; set; }

        public GeopositionAddViewModel(IContainer container, bool isUpdate, IUnitOfWork unitOfWork, Geoposition model, Farm farm) : base(container)
        {
            Model = model;
            
            _isUpdate = isUpdate;
            uw = unitOfWork;

            Model.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => { if (e.PropertyName == "HasErrors") SaveCmd.RaiseCanExecuteChanged(); };

            BrowseCmd = new DelegateCommand(() => {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                    ShapeFilePath = openFileDialog.FileName;
                    Model.GeoData = File.ReadAllText(ShapeFilePath);
            });

            SaveCmd = new DelegateCommand(() =>
            {
                if (!isUpdate)
                {
                    farm.Geopositions.Add(Model);
                }
                uw.Complete();
                CloseAction();
            }, () => !Model.HasErrors);
        }

    }
}
