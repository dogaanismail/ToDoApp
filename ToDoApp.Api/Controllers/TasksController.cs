
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ToDoApp.Business.Abstract;
using ToDoApp.Core.Utilities.Mappings;
using ToDoApp.DataDomain.Api;
using ToDoApp.DataDomain.Dto;
using ToDoApp.Entities.EntityFramework;

namespace ToDoApp.Api.Controllers
{
    [RoutePrefix("api/tasks")]
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
        public List<TaskDto> GetTasks()
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

        [Route("gettask")]
        [HttpGet]
        public Tasks GetTaskById(int id)
        {
            Tasks tasks = AutoMapperHelper.MapToSameType(_taskService.GetById(id));

            return tasks;
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
                    Deadline = model.Deadline
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
                _taskService.Update(getTask);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }

        [Route("deletetask")]
        [HttpDelete]
        public IHttpActionResult DeleteTask(int id)
        {
            try
            {
                Tasks getTask = _taskService.GetById(id);
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