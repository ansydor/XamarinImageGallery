using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinImageGallery.Model.Model.Image
{
    public class ImageItem
    {
        public int Id { get; private set; }
        public string Url { get; private set; }
        public string Title { get; set; }

        public ImageItem(int id, string url)
        {
            Id = id;
            Url = url;
        }
    }
}
