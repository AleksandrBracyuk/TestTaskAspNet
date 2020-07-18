using System;
using System.Collections.Generic;
using System.Text;

namespace TestTaskClient.Model
{
    public class Info
    {
        public long Id { get; set; }
        public DateTime UpdateTimestamp { get; set; }
        public string ComputerName { get; set; }
        public decimal DiskCFreeSpace { get; set; }
    }
}
