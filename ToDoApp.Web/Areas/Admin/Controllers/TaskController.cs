using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDoApp.Web.Areas.Admin.Controllers
{
    public class TaskController : Controller
    {
        // GET: Admin/Task
        public ActionResult Index()
        {
            return View();
        }
    }
}