using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLogger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using MyPortal.DatabaseFactory;
using MyPortal.Entity.DTO;
using MyPortal.Services.Repository;

using Serilog;

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
        [Route("GetUserProfiles")]
        [HttpGet]
        [TrackUsage("MyPortal", "API", "GetUserProfiles")]
        public async Task<IActionResult> GetUserProfiles()
        {
            Log.Information("GetUserProfiles");
            List<UserProfile> userProfile = new List<UserProfile>();

            userProfile = await UserManager.GetUserProfileListAsync();
            
            return Ok(userProfile);
        }

        [Authorize]
        [Route("GetUserProfileById/{id}")]
        [HttpGet]
        [TrackUsage("MyPortal", "API", "GetUserProfileById")]
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
        [TrackUsage("MyPortal", "API", "GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            List<User> user = new List<User>();

            if (id > 0)
            {
                user = await UserManager.GetUserByIdAsync(id);
            }
               
            return Ok(user);
        }

        [Authorize]
        [Route("SaveUserDetails")]
        [HttpPost]
        [TrackUsage("MyPortal", "API", "SaveUserDetails")]
        public async Task<IActionResult> SaveUserDetails(Entity.DbEntities.User user)
        {
            int userId = 0;
            try
            {
                WebHelper.LogWebDiagnostic("MyPortal", "API", "SaveUserDetails", HttpContext, new Dictionary<string, object> { { "Very", "Important" } });
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
