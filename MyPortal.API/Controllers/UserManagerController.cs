using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortal.DatabaseFactory;
using MyPortal.Entity.DTO;
using MyPortal.Services.Repository;

namespace MyPortal.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagerController : ControllerBase
    {   
        private readonly IUserManager UserManager;

        public UserManagerController(IUserManager userManager)
        {            
            UserManager = userManager;
        }
                
        [Authorize]
        [Route("GetUserProfile")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {
            List<UserProfile> userProfile = new List<UserProfile>();

            userProfile = await UserManager.GetUserProfileListAsync();
            
            return Ok(userProfile);
        }

        [Authorize]
        [Route("GetUserProfileById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfileById(int id)
        {
            List<UserProfile> userProfile = new List<UserProfile>();

            if (id > 0)
            {
                userProfile = await UserManager.GetUserProfileByIdAsync(id);
            }

            return Ok(userProfile);
        }
    
        [Authorize]
        [Route("GetUser/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            List<User> user = new List<User>();

            if (id > 0)
            {
                user = await UserManager.GetUserByIdAsync(id);
            }
               
            return Ok(user);
        }

        //[Authorize]
        [Route("SaveUserDetails")]
        [HttpPost]
        public async Task<IActionResult> SaveUserDetails(Entity.DbEntities.User user)
        {
            int userId = 0;
            try
            {
                userId = await UserManager.SaveUserAsync(user);
                ///Todo: Logging
                return await Task.FromResult(Ok(userId));
            }
            catch (Exception ex)
            {
                //log.Error(ex);
                return await Task.FromResult(BadRequest(ex));
            }            
        }
    }
}
