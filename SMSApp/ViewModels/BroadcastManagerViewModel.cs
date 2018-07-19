using Autofac;
using Prism.Commands;
using SMSApp.DataAccess;
using SMSApp.Enums;
using SMSApp.Repositories.Core;
using System.Linq;
using System.Collections.Generic;
using System;

namespace SMSApp.ViewModels
{
    public class BroadcastManagerViewModel : ViewModelBase
    {
        private IUnitOfWork unitOfWork;
        public BroadcastManagerViewModel(IContainer container, IUnitOfWork uow) : base(container)
        {
            
            unitOfWork = uow;
            WarningLevel = null;
            SendSMSCommand = new DelegateCommand(ExecuteSendSMSCommand, () => Farms.Select((el) => el.FarmOwner.IsSelected).Count() > 0);
        }

        public Array WarningLevels { get=> Enum.GetValues(typeof(BroadcastWarningLevels)); }

        /// <summary>
        /// Warning level
        /// </summary>
        public BroadcastWarningLevels? WarningLevel {get; set; }

        /// <summary>
        /// Message text
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// Farms for sending messages
        /// </summary>
        public IEnumerable<Farm> Farms { get => unitOfWork.Farms.GetAll(); }

        public DelegateCommand SendSMSCommand { get; private set; }

        private void ExecuteSendSMSCommand()
        {

        }
    }
}
