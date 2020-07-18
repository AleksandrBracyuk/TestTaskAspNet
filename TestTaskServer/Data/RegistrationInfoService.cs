using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTaskServer.Models;

namespace TestTaskServer.Data
{
    public class RegistrationInfoService
    {
        internal IEnumerable<Info> GetAllInfoes()
        {
            return TestTaskServerContext.Infoes;
        }

        internal Info AddInfo(InfoRequest value)
        {
            var item = new Info()
            {
                Id = GetNextId(),
                UpdateTimestamp = DateTime.Now,
                ComputerName = value.ComputerName,
                DiskCFreeSpace = value.DiskCFreeSpace
            };
            TestTaskServerContext.Infoes.Add(item);
            return item;
        }
        private long GetNextId()
        {
            lock (TestTaskServerContext.Infoes)
            {
                var ret = TestTaskServerContext.NextInfoId;
                TestTaskServerContext.NextInfoId++;
                return ret;
            }
        }
    }
}