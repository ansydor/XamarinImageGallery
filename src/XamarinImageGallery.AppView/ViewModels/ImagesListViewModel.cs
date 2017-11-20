using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinImageGallery.Model.Manager;
using XamarinImageGallery.Model.Model.Image;
using XamarinImageGallery.AppView.Helpers;

namespace XamarinImageGallery.AppView.ViewModels
{
    public class ImagesListViewModel : ViewModelBase
    {
        private readonly IImageManager _imageManager;

        public ObservableRangeCollection<ImageItem> Images { get; private set; }

        public Command LoadMoreCommand { get; set; }

        public ImagesListViewModel(IImageManager imageManager)
        {
            _imageManager = imageManager;

            Title = "Gallery";
            Images = new ObservableRangeCollection<ImageItem>();

            LoadMoreCommand = new Command(async () => await ExecuteLoadMoreCommandAsync());
        }

        private async Task ExecuteLoadMoreCommandAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var images = await _imageManager.GetListAsync();
                Images.AddRange(images);
            }
            catch
            {

            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
