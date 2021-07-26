using System;

namespace DotNetLibrary.Data
{
    public class LogReadDto
    {
        public int Id { get; set; }

        public string Method { get; set; }

        public string Host { get; set; }

        public string Path { get; set; }

        public string RequestBody { get; set; }

        public DateTime Time { get; set; }
    }
}