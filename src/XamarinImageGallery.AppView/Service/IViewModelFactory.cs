using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinImageGallery.AppView.Service
{
    public interface IViewModelFactory
    {
        T Resolve<T>();
    }

    public class AutofacViewModelFactory : IViewModelFactory
    {
        private readonly ILifetimeScope _scope;
        public AutofacViewModelFactory(ILifetimeScope scope)
        {
            _scope = scope;

        }
        public T Resolve<T>()
        {
            return _scope.Resolve<T>();
        }
    }
}
