using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinImageGallery.AppView.Service;
using XamarinImageGallery.AppView.ViewModels;
using XamarinImageGallery.Model.Model.Image;

namespace XamarinImageGallery.AppView.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImagesListPage : ContentPage
	{
        ImagesListViewModel viewModel;
        public ImagesListPage(IViewModelFactory viewModelFactory)
        {
			InitializeComponent ();
            BindingContext = this.viewModel = viewModelFactory.Resolve<ImagesListViewModel>();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ImageItem;
            if (item == null)
                return;
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Images.Count == 0)
                viewModel.LoadMoreCommand.Execute(null);
        }
    }
}