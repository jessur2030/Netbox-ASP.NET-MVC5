using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Netbox.Models;
using System.ComponentModel.DataAnnotations;

namespace Netbox.ViewModels
{
    public class NewMovieViewModel
    {
        //public List<Genre> Genres { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        //public Movie Movie { get; set; }
        public int? Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 100)]
        [Required]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public NewMovieViewModel()
        {
            Id = 0;
        }

        public NewMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

    }
}