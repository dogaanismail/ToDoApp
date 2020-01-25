using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using ToDoApp.Business.Abstract;
using ToDoApp.Business.Concrete.IdentityManagers;
using ToDoApp.DataDomain.Dto;

namespace ToDoApp.Api.Controllers
{
    [RoutePrefix("api/dashboard")]
    [AllowAnonymous]
    [EnableCors("*", "*", "*")]
    public class DashboardController : ApiController
    {
        #region Ctor
        private readonly ITaskService _taskService;
        private ApplicationUserManager _userManager;

        public DashboardController(ITaskService taskService, ApplicationUserManager userManager)
        {
            _taskService = taskService;
            _userManager = userManager;
        }

        #endregion

        [Route("getdata")]
        [HttpGet]
        public DashboardDto GetData()
        {
            DashboardDto dto = new DashboardDto
            {
                TotalTasks = _taskService.GetTasks().ToList().Count,
                TotalUsers = _userManager.Users.ToList().Count
            };

            return dto;
        }
    }
}
