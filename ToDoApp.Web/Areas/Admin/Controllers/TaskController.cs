using System.Web.Mvc;

namespace ToDoApp.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TaskController : Controller
    {
        // GET: Admin/Task
        public ActionResult Index()
        {
            return View();
        }
    }
}