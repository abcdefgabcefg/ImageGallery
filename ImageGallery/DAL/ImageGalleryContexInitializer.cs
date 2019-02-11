using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;
using ImageGallery.Models;

namespace ImageGallery.DAL
{
    public class ImageGalleryContexInitializer : DropCreateDatabaseIfModelChanges<ImageGalleryContext>
    {
        protected override void Seed(ImageGalleryContext context)
        {
            var images = new List<Image>();
            foreach (var file in Directory.EnumerateFiles(HttpContext.Current.Server.MapPath(@"~/ImagesForGallery")))
            {
                string base64 = GetImage(file);
                if (base64 != null)
                {
                    Image image = new Image { ImageBase64 = base64 };
                    images.Add(image);
                } 
            }
            context.Images.AddRange(images);
            context.SaveChanges();
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