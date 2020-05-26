﻿using System;
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
 
        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }
    }

    
}