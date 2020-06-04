﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Netbox.Models;
using System.ComponentModel.DataAnnotations;

namespace Netbox.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte GenreId { get; set; }
        public GenreDto Genre { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Range(1, 100)]
        public byte NumberInStock { get; set; }
    }
}