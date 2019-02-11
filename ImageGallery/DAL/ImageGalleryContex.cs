using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ImageGallery.Models;

namespace ImageGallery.DAL
{
    public class ImageGalleryContext : DbContext
    {
        public ImageGalleryContext()
        {
            Database.SetInitializer(new ImageGalleryContexInitializer());
        }

        public DbSet<Image> Images { get; set; }
    }
}