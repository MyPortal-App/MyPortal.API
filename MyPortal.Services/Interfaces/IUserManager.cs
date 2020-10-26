using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using MyPortal.Entity.DTO;

namespace MyPortal.Services.Repository
{
    public interface IUserManager
    {        
        IList<UserProfile> GetUserProfileList();

        Task<IList<UserProfile>> GetUserProfileListAsync();
    }
}
