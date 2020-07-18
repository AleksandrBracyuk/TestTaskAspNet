using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTaskServer.Models
{
    public class InfoRequest
    {
        public string ComputerName { get; set; }
        public DateTime UpdateTimestamp { get; set; }
        public decimal DiskCFreeSpace { get; set; }
    }
}