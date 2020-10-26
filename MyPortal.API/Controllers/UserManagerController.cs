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
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagerController : ControllerBase
    {        
        private IConnectionFactory ConnectionFactory { get; }
        private readonly IUserManager UserManager;

        public UserManagerController(IConnectionFactory connectionFactory, IUserManager userManager)
        {
            ConnectionFactory = connectionFactory;
            UserManager = userManager;
        }

        [Route("GetUserProfiles")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfiles()
        {
            var data = await UserManager.GetUserProfileListAsync();
            
            return Ok(data);
        }        
    }
}
