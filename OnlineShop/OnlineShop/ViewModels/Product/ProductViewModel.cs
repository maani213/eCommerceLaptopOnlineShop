using OnlineShop.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string ProcessorType { get; set; }
        public string RAM { get; set; }
        public string HardDrive { get; set; }
        public string OperatingSystem { get; set; }
        public bool WebCam { get; set; }
        public string ScreenSize { get; set; }
        public string Status { get; set; }
        public string DedicatedGraphicMemory { get; set; }
        public string ImgUrl { get; set; }
        public long Price { get; set; }
    }
}