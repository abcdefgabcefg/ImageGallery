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
                byte[] base64 = GetImage(file);
                if (base64 != null)
                {
                    Image image = new Image { ImageBytes = base64 };
                    images.Add(image);
                } 
            }
            context.Images.AddRange(images);
            context.SaveChanges();
        }

        private byte[] GetImage(string path)
        {
            if (File.Exists(path))
            {
                 return File.ReadAllBytes(path);
            }
            return null;
        }
    }
}