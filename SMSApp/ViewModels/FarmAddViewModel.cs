using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SMSApp.ViewModels
{
    public class FarmAddViewModel : EntityAddViewModel<Farm>
    {
        private List<FarmOwner> _farmOwners;

        public List<FarmOwner> FarmOwners
        {
            get { return _farmOwners; }
            set { _farmOwners = value; RaisePropertyChanged(); }
        }

        public FarmAddViewModel(IContainer container, IUnitOfWork unitOfWork, Farm model, bool isUpdate=false) : base(container, isUpdate, unitOfWork, model)
        {
            FarmOwners = (List<FarmOwner>)unitOfWork.FarmOwners.GetAll();
        }
    }
}
