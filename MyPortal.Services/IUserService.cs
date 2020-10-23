using System.Collections.Generic;

using MyPortal.Services.DTO;

namespace MyPortal.Services
{
    public interface IUserService
    {
        int AddNewUser(string Username, string Password, string FirstName, string LastName);
        int AddNewUser(string Username, string Password, string FirstName, string LastName, bool Enabled, bool ResetPassword);
        UserObject GetUserByEmailAddress(string emailAddress);
        bool IsPasswordValid(string password, string hashedPassword);
        bool IsExistingUser(string emailAddress);
        List<Role> GetUserRoles(int userId);
        List<Role> GetAllRoles();
        List<UserObject> GetAllUsers();
        void AddroleToUser(int userid, int roleid);
        void AddNewRole(string RoleName);        
        void RemoveroleFromUser(int userid, int roleid);        
        void RemoveRoleByRoleId(int roleid);
        //UserObject GetUserProfile();
        void UpdateUser(UserObject user);
        List<UserObject> GetUsersByRoleId(int roleId);
        List<UserObject> GetUsersByRoleName(string roleName);
    }
}
