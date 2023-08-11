using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Business.Services
{
    public class Logger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[Logger] - " + message);
        }
    }
}