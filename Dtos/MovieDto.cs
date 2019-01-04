using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
       
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedTime { get; set; }
 
        //[Min18IfAMember]
        public int Stock { get; set; }
        public byte GenreId { get; set; }
        public GenreDto Genre { get; set; }
    }
}