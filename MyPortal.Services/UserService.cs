using System.Collections.Generic;

using Microsoft.Extensions.Configuration;

using MyPortal.Services.DTO;
using MyPortal.Services.Infrustracture;

namespace MyPortal.Services
{
    public class UserService : IUserService
    {
        private IConfiguration Configuration { get; set; }
        public UserService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public int AddNewUser(string Username, string Password, string FirstName, string LastName)
        {
            User u = new User(Configuration);
            return u.AddNewUser(Username, Password, FirstName, LastName);
        }
        public int AddNewUser(string Username, string Password, string FirstName, string LastName, bool Enabled, bool ResetPassword)
        {
            User u = new User(Configuration);
            return u.AddNewUser(Username, Password, FirstName, LastName, Enabled, ResetPassword);
        }

        public UserObject GetUserByEmailAddress(string emailAddress)
        {
            User u = new User(Configuration);
            return u.GetUserByEmailAddress(emailAddress);
        }

        public bool IsPasswordValid(string password, string hashedPassword)
        {
            User u = new User(Configuration);
            return u.IsPasswordValid(password, hashedPassword);
        }

        public bool IsExistingUser(string emailAddress)
        {
            User u = new User(Configuration);
            return u.IsExistingUser(emailAddress);
        }

        public List<Role> GetUserRoles(int userId)
        {
            Roles r = new Roles(Configuration);
            return r.GetUserRoles(userId);
        }

        public List<Role> GetAllRoles()
        {
            Roles r = new Roles(Configuration);
            return r.GetAllRoles();
        }

        public List<UserObject> GetAllUsers()
        {
            User u = new User(Configuration);
            return u.GetAllUsers();
        }

        public void AddroleToUser(int userid, int roleid)
        {
            Roles r = new Roles(Configuration);

            r.AddroleToUser(userid, roleid);
        }

        public void AddNewRole(string RoleName)
        {
            Roles r = new Roles(Configuration);
            string[] roleSplit = RoleName.Split(';');
            foreach (string role in roleSplit)
            {
                if (!string.IsNullOrEmpty(role.Trim()))
                    r.AddNewRole(role);
            }

        }
                
        public void RemoveroleFromUser(int userid, int roleid)
        {
            Roles r = new Roles(Configuration);

            r.RemoveroleFromUser(userid, roleid);
        }
                
        public void RemoveRoleByRoleId(int roleid)
        {
            Roles r = new Roles(Configuration);
            r.RemoveRoleByRoleId(roleid);
        }

        //public UserObject getUserProfile()
        //{
            
        //}

        public void UpdateUser(UserObject user)
        {
            User u = new User(Configuration);
            u.UpdateUser(user);
        }

        public List<UserObject> GetUsersByRoleId(int roleId)
        {
            User u = new User(Configuration);
            return u.GetUserByRoleId(roleId);
        }

        public List<UserObject> GetUsersByRoleName(string roleName)
        {
            User u = new User(Configuration);
            return u.GetUserByRoleName(roleName);
        }
    }
}
