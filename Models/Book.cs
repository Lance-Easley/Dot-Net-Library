using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetLibrary.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

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
        [StringLength(10)]
        public string PublishDate { get; set; } // "mm/dd/yyyy"
    }
}