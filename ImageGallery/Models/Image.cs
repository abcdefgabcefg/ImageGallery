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
        public string ImageBase64 { get; set; }
    }
}