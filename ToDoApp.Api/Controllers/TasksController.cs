
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using ToDoApp.Business.Abstract;
using ToDoApp.Core.Aspects.PostsSharp.CacheAspects;
using ToDoApp.Core.CrossCuttingConcers.Caching.Microsoft;
using ToDoApp.Core.Utilities.Mappings;
using ToDoApp.DataDomain.Api;
using ToDoApp.DataDomain.Dto;
using ToDoApp.Entities.EntityFramework;

namespace ToDoApp.Api.Controllers
{
    [RoutePrefix("api/tasks")]
    [AllowAnonymous]
    [EnableCors("*", "*", "*")]
    public class TasksController : ApiController
    {
        #region Ctor
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        #endregion

        [Route("gettasks")]
        [HttpGet]
        [CacheAspect(typeof(MemoryCacheManager), 30)]
        public List<TaskDto> GetTasks()
        {
            List<TaskDto> tasks = _taskService.GetTasks().Select(p => new TaskDto
            {
                TaskId = p.TaskId,
                TaskName = p.TaskName,
                TaskTitle = p.TaskTitle,
                TaskDescription = p.TaskDescription,
                Deadline = p.Deadline,
                CreatedDate = p.CreatedDate,
                IsCompleted = p.IsCompleted
            }).ToList();

            return tasks;
        }

        [Route("gettaskbyid")]
        [HttpGet]
        [CacheAspect(typeof(MemoryCacheManager), 30)]
        public Tasks GetTaskById(int id)
        {
            Tasks tasks = AutoMapperHelper.MapToSameType(_taskService.GetById(id));

            return tasks;
        }

        [Route("checktasks")]
        [HttpGet]
        public List<TaskDto> CheckTasks()
        {
            var result = _taskService.GetTasks().Where(x => x.Deadline.Value.Year == DateTime.Now.Year
            && x.Deadline.Value.Month == DateTime.Now.Month
            && x.Deadline.Value.Year == DateTime.Now.Year && x.IsCompleted == false).ToList();

            if (result.Count > 0)
            {
                List<TaskDto> taks = result.Select(p => new TaskDto
                {
                    TaskId = p.TaskId,
                    TaskName = p.TaskName,
                    TaskTitle = p.TaskTitle,
                    TaskDescription = p.TaskDescription,
                    Deadline = p.Deadline,
                    CreatedDate = p.CreatedDate
                }).ToList();

                return taks;
            }
            return null;
        }

        [Route("createtask")]
        [HttpPost]
        public IHttpActionResult CreateTask([FromBody]TaskApi model)
        {
            try
            {
                Tasks newTask = new Tasks
                {
                    TaskName = model.TaskName,
                    TaskTitle = model.TaskTitle,
                    TaskDescription = model.TaskDescription,
                    CreatedDate = DateTime.Now,
                    Deadline = model.Deadline,
                    IsCompleted = false
                };

                _taskService.Create(newTask);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }

        [Route("updatetask")]
        [HttpPost]
        public IHttpActionResult UpdateTask([FromBody]TaskApi model)
        {
            try
            {
                Tasks getTask = _taskService.GetById(model.TaskId);
                getTask.TaskName = model.TaskName;
                getTask.TaskTitle = model.TaskTitle;
                getTask.TaskDescription = model.TaskDescription;
                getTask.ModifiedDate = DateTime.Now;
                getTask.Deadline = model.Deadline;
                getTask.IsCompleted = model.IsCompleted;
                _taskService.Update(getTask);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }

        [Route("deletetask")]
        [HttpPost]
        public IHttpActionResult DeleteTask([FromBody] TaskApi model)
        {
            try
            {
                Tasks getTask = _taskService.GetById(model.TaskId);
                _taskService.Delete(getTask);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }
    }
}