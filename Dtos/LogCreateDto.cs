using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetLibrary.Data
{
    public class LogCreateDto
    {
        [Required]
        [MaxLength(8)]
        public string Method { get; set; }

        [Required]
        [MaxLength(250)]
        public string Host { get; set; }

        [Required]
        [MaxLength(250)]
        public string Path { get; set; }

        public string RequestBody { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}