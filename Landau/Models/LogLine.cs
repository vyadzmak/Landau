using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models
{
    public enum LogLineStates : int
    {
        Success = 1,
        Warning = 2,
        Error = 3
    };
    public class LogLine
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public string FullDescription { get; set; }

        public LogLine(string type, string message, string date, string description)
        {
            Type = type;
            Message = message;
            Date = date;
            FullDescription = description;
        }
    }
}