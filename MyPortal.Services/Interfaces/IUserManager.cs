using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using MyPortal.Entity.DTO;

namespace MyPortal.Services.Repository
{
    public interface IUserManager
    {        
        List<UserProfile> GetUserProfileList();
        Task<List<UserProfile>> GetUserProfileListAsync();
        List<UserProfile> GetUserProfileById(int id);
        Task<List<UserProfile>> GetUserProfileByIdAsync(int id);
        int SaveUserProfile(User user);
        Task<int> SaveUserProfileAsync(User user);

        List<User> GetUserById(int id);
        Task<List<User>> GetUserByIdAsync(int id);
        int SaveUser(Entity.DbEntities.User user);
        Task<int> SaveUserAsync(Entity.DbEntities.User user);
    }
}
