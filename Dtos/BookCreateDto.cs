using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetLibrary.Dtos
{
    public class BookCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Date must be in MM/DD/YYYY format")]
        public string PublishDate { get; set; }
    }
}