using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestTaskServer.Data;
using TestTaskServer.Models;

namespace TestTaskServer.Controllers
{
    public class InfoesController : Controller
    {
        
        // GET: Infoes
        public ActionResult Index()
        {
            return View(TestTaskServerContext.Infoes);
        }

    }
}
