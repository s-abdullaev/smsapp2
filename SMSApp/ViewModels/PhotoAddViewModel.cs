using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;

namespace SMSApp.ViewModels
{
    public class PhotoAddViewModel : EntityAddViewModel<Photo>
    {
        public PhotoAddViewModel(IContainer container, IUnitOfWork unitOfWork, Photo model, bool isUpdate=false) : base(container, isUpdate, unitOfWork, model)
        {
        }
        public override void ExecuteAddEntityCommand()
        {
            uw.Photos.AddAndStore(Model);
            uw.Complete();
            CloseAction();
        }
    }
}
