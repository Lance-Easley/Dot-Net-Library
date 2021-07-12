using AutoMapper;
using DotNetLibrary.Dtos;
using DotNetLibrary.Models;

namespace DotNetLibrary.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookReadDto>();
        }
    }
}