using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestTaskServer.Models;

namespace TestTaskServer.Data
{
    public static class TestTaskServerContext 
    {
        public static List<Info> Infoes { get; set; } = new List<Info>();
        public static long NextInfoId { get; set; } = 1;
    }
}
