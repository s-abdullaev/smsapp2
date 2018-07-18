using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System.Collections;
using System.Collections.Generic;

namespace SMSApp.ViewModels
{
    public class BroadcastManagerViewModel : ViewModelBase
    {
        private IUnitOfWork unitOfWork;
        public BroadcastManagerViewModel(IContainer container,IUnitOfWork uow) : base(container)
        {
            unitOfWork = uow;
        }

        /// <summary>
        /// Message text
        /// </summary>
        public string MessageText{ get; set; }

        /// <summary>
        /// Farms for sending messages
        /// </summary>
        public IEnumerable<Farm> Farms{ get => unitOfWork.Farms.GetAll(); }
    }
}
