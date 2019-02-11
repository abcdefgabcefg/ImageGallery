using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;
using ImageGallery.Models;

namespace ImageGallery.DAL
{
    public class ImageGalleryContexInitializer : DropCreateDatabaseAlways<ImageGalleryContext>
    {
        protected override void Seed(ImageGalleryContext context)
        {
            string base64 = GetImage(HttpContext.Current.Server.MapPath(@"~/ImagesForGallery/agriculture-asia-china-235648.jpg"));
            if (base64 != null)
            {
                Image image = new Image { ImageBase64 = base64};
                context.Images.Add(image);
                context.SaveChanges();
            }
        }

        private string GetImage(string path)
        {
            if (File.Exists(path))
            {
                byte[] bytes = File.ReadAllBytes(path);
                string base64 = Convert.ToBase64String(bytes);
                return string.Format("data:image/jpg;base64,{0}", base64);
            }
            return null;
        }
    }
}