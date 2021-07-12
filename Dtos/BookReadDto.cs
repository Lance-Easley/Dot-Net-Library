using System;

namespace DotNetLibrary.Dtos
{
    public class BookReadDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }
    }
}