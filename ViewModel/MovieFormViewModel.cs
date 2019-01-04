using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genres> Genres { get; set; }
        public int? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display (Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }
        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
        [Display(Name = "Stock In Number")]
        [Required]
        [Min18IfAMember]
        [Range(1,20)]
        public int? Stock { get; set; }
        

        public string Title
        {
            get { return Id != 0 ? "Edit Movie" : "New Movie"; }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            Stock = movie.Stock;
        }
    }
}