using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels.Product
{
    public class ProductDetail
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "you must enter its title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "you must enter its description")]
        public string Description { get; set; }
        public string Color { get; set; }
        [Required(ErrorMessage = "you must enter its Processor type")]

        public string ProcessorType { get; set; }
        public string RAM { get; set; }
        public string HardDrive { get; set; }
        public string OperatingSystem { get; set; }
        public bool WebCam { get; set; }
        public string ScreenSize { get; set; }
        public string Status { get; set; }
        public string DedicatedGraphicMemory { get; set; }
        public List<string> ImgUrls { get; set; }
        public int Price { get; set; }
        public string category { get; set; }
    }
}