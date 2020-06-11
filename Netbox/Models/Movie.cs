using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Razor;

namespace Netbox.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }
 
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
    
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        //[Range(1, 100, ErrorMessage = "The Field Number in Stock must be between 1 and 100.")]
     
        [Display(Name = "Number in Stock")]
        [Range(1, 100)]
        public byte NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }


    }

    
}