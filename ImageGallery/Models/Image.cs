using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ImageGallery.Models
{
    public class Image
    {
        public int ID { get; set; }
        [Required]
        public byte[] ImageBytes { get; set; }
    }
}