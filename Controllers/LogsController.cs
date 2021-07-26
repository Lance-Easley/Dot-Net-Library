using System.Collections.Generic;
using AutoMapper;
using DotNetLibrary.Data;
using DotNetLibrary.Dtos;
using DotNetLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System;

namespace DotNetLibrary.Controllers
{
    [Controller]
    public class LogsController : Controller
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
        public string Index()
        {
            var logs = _repository.GetAllLogs();

            string logString = "";

            string[] filters = HttpContext.Request.Query["filter"];

            foreach (Log log in logs) {
                if (!StringInArray(filters, log.Method)) {
                    logString += $"[{log.Method}] {log.Time} FROM: {log.Host}{log.Path}\n";

                    if (log.RequestBody.Length > 0) {
                        logString += $"    Body: {log.RequestBody}\n";
                    }
                }
            }

            return logString;
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