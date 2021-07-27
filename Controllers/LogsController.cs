using AutoMapper;
using DotNetLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DotNetLibrary.Controllers
{
    [Route("api")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogRepo _repository;
        private readonly IMapper _mapper;

        public LogsController(ILogRepo repository, IMapper mapper)    
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET logs
        [HttpGet("logs")]
        public ActionResult <IEnumerable<LogReadDto>> GetAllBooks()
        {
            var logs = _repository.GetAllLogs();

            return Ok(_mapper.Map<IEnumerable<LogReadDto>>(logs));
        }

        public static bool StringInArray(string[] array, string check) {
            foreach (string str in array) {
                if (str.Equals(check, StringComparison.InvariantCultureIgnoreCase)) {
                    return true;
                }
            }

            return false;
        }
    }
}