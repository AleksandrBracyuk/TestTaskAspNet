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

        internal Info PushInfo(InfoRequest value)
        {
            var item = new Info()
            {
                Id = GetNextId(),
                UpdateTimestamp = value.UpdateTimestamp,
                ComputerName = value.ComputerName,
                DiskCFreeSpace = value.DiskCFreeSpace
            };
            TestTaskServerContext.Infoes.Push(item);
            return item;
        }
        private long GetNextId()
        {
            lock (TestTaskServerContext.Infoes)
            {
                return TestTaskServerContext.NextInfoId++;
            }
        }
    }
}