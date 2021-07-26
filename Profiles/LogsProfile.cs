using AutoMapper;
using DotNetLibrary.Data;
using DotNetLibrary.Dtos;
using DotNetLibrary.Models;

namespace DotNetLibrary.Profiles
{
    public class LogsProfile : Profile
    {
        public LogsProfile()
        {
            CreateMap<Log, LogReadDto>();
            CreateMap<LogCreateDto, Log>();
        }
    }
}