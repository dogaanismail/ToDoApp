
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ToDoApp.Business.Abstract;
using ToDoApp.DataDomain.Dto;

namespace ToDoApp.Api.Controllers
{
    [RoutePrefix("api/Tasks")]
    public class TasksController : ApiController
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        [Route("GetTasks")]
        [HttpGet]
        public List<TaskDto> Get()
        {
            List<TaskDto> tasks = _taskService.GetTasks().Select(p => new TaskDto
            {
                TaskId = p.TaskId,
                TaskName = p.TaskName,
                TaskTitle = p.TaskTitle,
                TaskDescription = p.TaskDescription,
                Deadline = p.Deadline,
                CreatedDate = p.CreatedDate
            }).ToList();

            return tasks;
        }
    }
}