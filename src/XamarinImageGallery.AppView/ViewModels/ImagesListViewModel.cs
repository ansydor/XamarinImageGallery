using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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
        private int? _lastImageId = 0;
        public ObservableRangeCollection<ImageItem> Images { get; private set; }

        public Command LoadMoreCommand { get; set; }
        public Command RefreshCommand { get; set; }

        public ImagesListViewModel(IImageManager imageManager)
        {
            _imageManager = imageManager;

            Title = "Gallery";
            Images = new ObservableRangeCollection<ImageItem>();

            LoadMoreCommand = new Command(async () => await ExecuteLoadMoreCommandAsync(_lastImageId.HasValue ? _lastImageId.Value : 0));
            RefreshCommand = new Command(async () => await ExecuteLoadMoreCommandAsync());
        }

        private async Task ExecuteLoadMoreCommandAsync(int lastImageId = 0)
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var images = await _imageManager.GetListAsync(lastImageId);
                _lastImageId = images.Last()?.Id;
                if (lastImageId == 0)
                    Images.Clear();
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
