using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinImageGallery.AppView.Service;

namespace XamarinImageGallery.AppView.Views
{
    public class RootPage : MasterDetailPage
    {
        private readonly IViewModelFactory _factory;

        public RootPage(IViewModelFactory factory)
        {
            _factory = factory;

            Master = new MenuPage();
            Detail = new NavigationPage(new ImagesListPage(_factory));
        }    

    }
}
