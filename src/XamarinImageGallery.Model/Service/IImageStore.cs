using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinImageGallery.Model.Model.Image;

namespace XamarinImageGallery.Model.Service
{
    public interface IImageStore
    {
        Task<IEnumerable<ImageItem>> GetImagesListAsync();
    }

    public class ImageStore : IImageStore
    {
        public async Task<IEnumerable<ImageItem>> GetImagesListAsync()
        {
            var itemsTask = Task.Run(() => { return Enumerable.Range(0, 20).Select(s => new ImageItem()); });
            var items = await itemsTask.ConfigureAwait(false);
            return items;
        }
    }
}
