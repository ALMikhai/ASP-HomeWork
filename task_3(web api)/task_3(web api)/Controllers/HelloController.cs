using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace task_3_web_api_.Controllers
{
    public class HelloController : Controller
    {

        // GET: Hello
        public ActionResult Index()
        {
            return View();
        }
    }
}