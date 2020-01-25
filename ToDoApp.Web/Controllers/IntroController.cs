using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ToDoApp.Business.Abstract;
using ToDoApp.Core.Aspects.PostsSharp.CacheAspects;
using ToDoApp.Core.Constants;
using ToDoApp.Core.CrossCuttingConcers.Caching.Microsoft;
using ToDoApp.DataDomain.Dto;
using ToDoApp.DataDomain.ViewModels;
using ToDoApp.Web.Manager;

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

        [CacheAspect(typeof(MemoryCacheManager), 30)]
        public ActionResult Index()
        {
            List<TasksViewModel> data = _taskService.GetTasks().Select(p => new TasksViewModel
            {
                TaskId = p.TaskId,
                TaskName = p.TaskName,
                TaskTitle = p.TaskTitle,
                TaskDescription = p.TaskDescription,
                Deadline = p.Deadline,
                CreatedDate = p.CreatedDate,
                IsCompleted = p.IsCompleted
            }).ToList();
            return View(data);
        }

        /* ------------------------------------------  IMPORTANT ----------------------------------- */
        /* We can call rest api by using Service Manager and RestSharpGet instead of using business services. */
        /* Using of business services are faster than service manager, but we may need to use it for some implementations.
        /*
        public ActionResult Tasks()
        {
            return View(ServiceManager.RestSharpGet<List<TaskDto>>(ApiUrlConstants.GetTasks));
        }
        */
    }
}