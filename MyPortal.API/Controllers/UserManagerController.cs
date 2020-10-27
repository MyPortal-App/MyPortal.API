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
            var data = await UserManager.GetUserProfileListAsync();
            
            return Ok(data);
        }

        [Authorize]
        [Route("GetUserProfileById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfileById(int id)
        {
            var data = await UserManager.GetUserProfileByIdByAsync(id);

            return Ok(data);
        }
    }
}
