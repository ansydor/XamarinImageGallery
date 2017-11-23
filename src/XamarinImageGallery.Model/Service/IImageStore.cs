using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinImageGallery.Model.Model.Image;

namespace XamarinImageGallery.Model.Service
{

    public class ImageDto
    {
        public string Format { get; set; }
        public int Id { get; set; }
        public string Author { get; set; }
        public string FileName { get; set; }
    }
    public interface IImageStore
    {
        Task<IEnumerable<ImageItem>> GetImagesListAsync(int lastId = 0);
    }

    public class ImageStore : IImageStore
    {
        public async Task<IEnumerable<ImageItem>> GetImagesListAsync(int lastId = 0)
        {
            using (var httpClient = new HttpClient())
            {
                var source = await httpClient.GetStringAsync("https://picsum.photos/list");
                var items = JsonConvert.DeserializeObject<IEnumerable<ImageDto>>(source).Where(w => w.Id > lastId).Take(50).Select(s => new ImageItem(s.Id, string.Concat("https://picsum.photos/800/800?image=", s.Id))
                {
                    Title = string.Concat("Author : ", s.Author)
                });
                return items;
            }
        }
    }
}
