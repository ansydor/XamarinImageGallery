using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinImageGallery.Model.Model.Image;
using XamarinImageGallery.Model.Service;

namespace XamarinImageGallery.Model.Manager
{
    public interface IImageManager
    {
        Task<IEnumerable<ImageItem>> GetListAsync();
    }

    public class ImageManager : IImageManager
    {
        private readonly IImageStore _imageStore;
        public ImageManager(IImageStore imageStore)
        {
            _imageStore = imageStore;
        }

        public async Task<IEnumerable<ImageItem>> GetListAsync()
        {
            return await _imageStore.GetImagesListAsync().ConfigureAwait(false);
        }
    }
}
