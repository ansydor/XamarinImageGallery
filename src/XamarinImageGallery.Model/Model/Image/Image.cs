using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinImageGallery.Model.Model.Image
{
    public class ImageItem
    {
        public Guid Id { get; private set; }
        public string Url { get; private set; }
        public string Title { get; set; }
        public ImageItem()
        {
            Id = Guid.NewGuid();
            Title = "Image title for " + Id.ToString();
            Url = "http://lorempixel.com/650/800/?q=" + Id.ToString();
        }

    }
}
