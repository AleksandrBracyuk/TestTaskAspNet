﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestTaskClient.Model
{
    public class InfoRequest
    {
        public string ComputerName { get; set; }
        public DateTime UpdateTimestamp { get; set; }
        public decimal DiskCFreeSpace { get; set; }
    }
}
