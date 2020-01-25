using System.Web.Mvc;
using ToDoApp.Business.Abstract;

namespace ToDoApp.Web.Controllers
{
    public class IntroController : Controller
    {
        #region Ctor
        private readonly ITaskService _taskService;

        public IntroController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        #endregion

        public ActionResult Index()
        {
            return View(_taskService.GetTasks());
        }
    }
}