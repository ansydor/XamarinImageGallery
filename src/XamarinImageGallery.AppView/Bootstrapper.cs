using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinImageGallery.AppView.Service;
using XamarinImageGallery.AppView.ViewModels;
using XamarinImageGallery.AppView.Views;
using XamarinImageGallery.Model.Manager;
using XamarinImageGallery.Model.Service;

namespace XamarinImageGallery.AppView
{
    public class Bootstrapper
    {
        private bool _isRunning = false;

        public Bootstrapper()
        {

        }

        public Page Start()
        {
            var container = Configure();
            var page = container.Resolve<RootPage>();
            return page;
        }

        public IContainer Configure()
        {
            if (_isRunning)
                throw new InvalidOperationException();
            _isRunning = true;

            var builder = new ContainerBuilder();

            //services
            builder.RegisterType<AutofacViewModelFactory>().As<IViewModelFactory>().SingleInstance();
            builder.RegisterType<ImageStore>().As<IImageStore>().SingleInstance();
            builder.RegisterType<ImageManager>().As<IImageManager>().SingleInstance();
                                    
            //viewModels
            builder.RegisterType<ImagesListViewModel>().AsSelf().InstancePerLifetimeScope();

            //view
            builder.RegisterType<ImagesListPage>().AsSelf().SingleInstance();
            builder.RegisterType<RootPage>().AsSelf().SingleInstance();

            var container = builder.Build();
            container.BeginLifetimeScope();

            return container;
        }
    }
}
