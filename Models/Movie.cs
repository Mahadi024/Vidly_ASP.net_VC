using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedTime { get; set; }
        [Display(Name = "Number In Stock")]
        [Range(1,20)]
        public int Stock { get; set; }
        public byte NumberAvailable { get; set; }
        public Genres Genre { get; set; }
        public byte GenreId { get; set; }
    }
}