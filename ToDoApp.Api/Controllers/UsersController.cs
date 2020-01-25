using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using ToDoApp.Business.Concrete.IdentityManagers;
using ToDoApp.Core.Aspects.PostsSharp.CacheAspects;
using ToDoApp.Core.Aspects.PostsSharp.TransactionAspects;
using ToDoApp.Core.CrossCuttingConcers.Caching.Microsoft;
using ToDoApp.DataDomain.Api;
using ToDoApp.DataDomain.Dto;
using ToDoApp.Entities.Identity.Entities;

namespace ToDoApp.Api.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        #region Ctor
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public UsersController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        #endregion

        [Route("getusers")]
        [HttpGet]
        [CacheAspect(typeof(MemoryCacheManager), 30)]
        public List<UsersDto> GetUsers()
        {
            List<UsersDto> users = _userManager.Users.Select(p => new UsersDto
            {
                Id = p.Id,
                UserName = p.UserName,
                Email = p.Email
            }).ToList();

            return users;
        }


        [Route("getuser")]
        [HttpGet]
        [CacheAspect(typeof(MemoryCacheManager), 30)]
        public UsersDto GetUserById(string id)
        {
            UsersDto user = _userManager.Users.Where(x => x.Id == id).Select(p => new UsersDto
            {
                Id = p.Id,
                UserName = p.UserName,
                Email = p.Email
            }).FirstOrDefault();

            return user;
        }


        [Route("createuser")]
        [HttpPost]
        [TransactionScopeAspect]
        public async Task<IHttpActionResult> CreateUser([FromBody] UserApi model)
        {
            try
            {
                User newUser = new User
                {
                    UserName = model.UserName,
                    Email = model.UserName
                };

                //Creates a user without no password.
                var result = await _userManager.CreateAsync(newUser); 
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    //Adding a password to the user that has just been created.
                    var addResult = await _userManager.AddPasswordAsync(user.Id, model.Password);

                    if (result.Succeeded)
                    {
                        return Ok(200);
                    }
                    else
                    {
                        return BadRequest(addResult.Errors.ToString());
                    }
                }              
                else
                {
                    return BadRequest(result.Errors.ToString());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }


        [Route("deleteuser")]
        [HttpDelete]
        [TransactionScopeAspect]
        public async Task<IHttpActionResult> DeleteUser(string userId)
        {
            try
            {
                var getUser = await _userManager.FindByIdAsync(userId);
                var result = await _userManager.DeleteAsync(getUser);
                if (result.Succeeded)
                {
                    return Ok(200);
                }
                else
                {
                    return BadRequest(result.Errors.ToString());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }


        [Route("updateUser")]
        [HttpPost]
        [TransactionScopeAspect]
        public async Task<IHttpActionResult> UpdateUser([FromBody] UserApi model)
        {
            try
            {
                var getUser = await _userManager.FindByIdAsync(model.Id);
                getUser.Email = model.Email;
                getUser.UserName = model.UserName;

                var result = await _userManager.UpdateAsync(getUser);
                if (result.Succeeded)
                {
                    return Ok(200);
                }
                else
                {
                    return BadRequest(result.Errors.ToString());
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message.ToString());
            }

        }
    }
}
