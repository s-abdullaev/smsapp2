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
    public class SoilReadingAddViewModel : ViewModelBase
    {
        private SoilReading _model;

        protected IUnitOfWork uw;
        protected bool _isUpdate;

        public SoilReading Model
        {
            get { return _model; }
            set { _model = value; RaisePropertyChanged(); }
        }
        
        public DelegateCommand SaveCmd { get; set; }

        public SoilReadingAddViewModel(IContainer container, bool isUpdate, IUnitOfWork unitOfWork, SoilReading model, Geoposition geop) : base(container)
        {
            Model = model;
            
            _isUpdate = isUpdate;
            uw = unitOfWork;

            Model.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e)=>{ if (e.PropertyName == "HasErrors") SaveCmd.RaiseCanExecuteChanged(); };

            SaveCmd = new DelegateCommand(() =>
            {
                if (!isUpdate)
                {
                    geop.SoilReadings.Add(Model);
                }
                uw.Complete();
                CloseAction();
            }, ()=>!Model.HasErrors);
        }

    }
}
