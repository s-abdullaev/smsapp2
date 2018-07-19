using Autofac;
using Prism.Mvvm;
using System;

namespace SMSApp.ViewModels
{
    public class ViewModelBase: BindableBase
    {
        protected IContainer _container;
        public Action CloseAction { get; set; }

        public ViewModelBase(IContainer container)
        {
            _container = container;
        }

    }
}
