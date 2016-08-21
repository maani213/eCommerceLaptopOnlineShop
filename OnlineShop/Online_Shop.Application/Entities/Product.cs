using OnlineShop.Custom_Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shop.Application.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="you must enter its title")]
        [StringLength(40,ErrorMessage="Title must be less than 40 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "you must enter its description")] 
        [StringLength(300,ErrorMessage="Description must be less than 300 caracters")]
        public string Description { get; set; }

        public string Color { get; set; }
        [Required(ErrorMessage = "you must enter its Processor type")]

        public string ProcessorType { get; set; }
        [Required(ErrorMessage = "you must enter RAM size")]

        public string RAM { get; set; }
        [Required(ErrorMessage = "you must enter Hard Disk Size")]

        public string HardDrive { get; set; }
        [Required(ErrorMessage = "you must select a operating system")]

        public string OperatingSystem { get; set; }
        [Required(ErrorMessage = "you must select Webcam Availaility")]

        public bool WebCam { get; set; }
        //[Required(ErrorMessage = "you must enter its Screed size")]

        public string ScreenSize { get; set; }
        [Required(ErrorMessage = "Please mention its status")]

        public string Status { get; set; }
        [Required(ErrorMessage = "you must enter its Graphic memory (e.g) yes/no")]

        public string DedicatedGraphicMemory { get; set; }
        public List<string> ImgUrls { get; set; }
        [Required(ErrorMessage = "you must enter its Price")]

        public int Price { get; set; }
        [Required(ErrorMessage = "you select its category")]

        [SelectionListRequiredAttribute]

        public int categoryId { get; set; }
    }
}