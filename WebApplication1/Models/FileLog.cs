using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class FileLog : ILog
    {
        public void Info(string str)
        {
            var line = new List<string>() { str };

            System.IO.File.AppendAllLines("log.txt", line);
        }
    }
}
