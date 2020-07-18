using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestTaskServer.Models;

namespace TestTaskServer.Data
{
    public static class TestTaskServerContext 
    {
        //https://habr.com/ru/post/473352/
        //    Сoncurrent collections за 10 минут
        // - для записи из нескольких потоков классические коллекции непригодны

        /// <summary>
        /// Поступившая инф-я (LIFO), хранится как ConcurrentStack - потокобезопасная коллекция, обслуживаемую по принципу «последним поступил — первым обслужен» (LIFO).
        /// </summary>
        public static ConcurrentStack<Info> Infoes { get; set; } = new ConcurrentStack<Info>();
        public static long NextInfoId { get; set; } = 1;
    }
}
