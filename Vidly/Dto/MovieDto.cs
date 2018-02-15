using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dto
{
    public class MovieDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(55)]
        public string Name { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Range(1, 20)]
        public byte NumberInStock { get; set; }

    }
}