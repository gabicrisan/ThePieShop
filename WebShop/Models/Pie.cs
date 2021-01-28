using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebShop.Models
{
    public class Pie
    {
        public int PieId { get; set; }

        [Required(ErrorMessage = "Please enter a name for the pie")]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a short description")]
        [Display(Name = "ShortDescription")]
        [StringLength(50)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Please enter a long description")]
        [Display(Name = "LongDescription")]
        public string LongDescription { get; set; }

        public string AllergyInformation { get; set; }

        [Required(ErrorMessage = "Please enter a price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter URL for Image Url")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please enter URL for Image Thumbnail")]
        public string ImageThumbnailUrl { get; set; }

        public bool IsPieOfTheWeek { get; set; }
        public bool InStock { get; set; }

        [Required(ErrorMessage = "Please select a category ID")]
        public int CategoryId { get; set; }

        [BindNever]
        public Category Category { get; set; }

        [StringLength(100)]
        public string Notes { get; set; }

    }
}
