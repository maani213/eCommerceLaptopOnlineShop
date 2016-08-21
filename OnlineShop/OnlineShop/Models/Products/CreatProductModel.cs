using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Products
{
    public class CreatProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ProcessorType { get; set; }
        public string RAM { get; set; }
        public string HardDrive { get; set; }
        public string SelectedOperatingSystem { get; set; }
        public bool SelectedWebCam { get; set; }
        public string ScreenSize { get; set; }
        public string Status { get; set; }
        public string DedicatedGraphicMemory { get; set; }
        //public List<string> ImgID { get; set; }
        public int SelectedCategoryId { get; set; }
    }
}