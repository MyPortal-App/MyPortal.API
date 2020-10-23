using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using Dapper;
using Microsoft.Extensions.Configuration;

using MyPortal.Services.DTO;

namespace MyPortal.Services.Infrustracture
{
    internal class User
    {
        private IConfiguration Configuration { get; set; }
        private SqlConnection DbConnection { get { return new SqlConnection(Configuration.GetConnectionString("DefaultConnection")); } }

        public User(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<UserObject> GetAllUsers()
        {
            List<UserObject> userobject = new List<UserObject>();
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                userobject.AddRange(connection.Query<UserObject>("[dbo].[sp_GetAllUsers]", commandType: CommandType.StoredProcedure).ToList());
            }
            return userobject;
        }
        public int AddNewUser(string Username, string Password, string FirstName, string LastName, bool Enabled = true, bool ResetPassword = false)
        {
            int userid = 0;
            try
            {
                if (IsExistingUser(Username)) throw new Exception("User Already exists");

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@firstname", FirstName);
                parameters.Add("@lastname", LastName);
                parameters.Add("@username", Username);
                parameters.Add("@password", EncryptPassword(Password));
                parameters.Add("@enabled", Enabled ? 1 : 0);
                parameters.Add("@resetpassword", ResetPassword ? 1 : 0);
                parameters.Add("@resetpasswordid", GetNewGuid());
                parameters.Add("@altid", GetNewGuid());


                using (IDbConnection connection = DbConnection)
                {
                    connection.Open();
                    userid = connection.Query<int>("[dbo].[sp_AddNewUser]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return userid;
        }


        public void UpdateUser(UserObject user)
        {

            using (IDbConnection connection = DbConnection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@firstname", user.FirstName);
                parameters.Add("@lastname", user.LastName);
                parameters.Add("@username", user.Username);
                parameters.Add("@password", !string.IsNullOrEmpty(user.Password) ? EncryptPassword(user.Password) : null);
                parameters.Add("@altid", user.AltId);
                parameters.Add("@enabled", user.Enabled ? 1 : 0);

                connection.Execute("[dbo].[sp_UpdateUser]", parameters, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue);
            }

        }
        
        public UserObject GetUserByEmailAddress(string emailAddress)
        {
            UserObject user = new UserObject();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@email", emailAddress);

            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                user = connection.Query<UserObject>("[dbo].[sp_GetUserByEmailAddress]", dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            if (user != null)
                user.Roles = new Roles(Configuration).GetUserRoles(user.Id);

            return user;

        }

        
        public bool IsExistingUser(string emailAddress)
        {
            bool result;
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                result = Convert.ToBoolean(connection.Query<int>($"select count(*) from users where username = '{emailAddress}'").FirstOrDefault());
            }

            return result;
        }

        public void ResetPassword(int userId, string password)
        {
            string newPassword = EncryptPassword(password);
        }

        public bool IsPasswordValid(string password, string hashedPassword) => BCrypt.Net.BCrypt.Verify(password, hashedPassword);

        private string EncryptPassword(string Password) => BCrypt.Net.BCrypt.HashPassword(Password, Convert.ToInt32(Configuration["EncryptionWorkerFactor"]));

        private Guid GetNewGuid() => Guid.NewGuid();

        public List<UserObject> GetUserByRoleId(int roleId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@roleid", roleId);

            List<UserObject> userobject = new List<UserObject>();
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                userobject.AddRange(connection.Query<UserObject>("[dbo].[sp_GetUserByRoleId]", dynamicParameters, commandType: CommandType.StoredProcedure).ToList());
            }
            return userobject;
        }

        public List<UserObject> GetUserByRoleName(string roleName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@rolename", roleName);

            List<UserObject> userobject = new List<UserObject>();
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                userobject.AddRange(connection.Query<UserObject>("[dbo].[sp_GetUserByRoleName]", dynamicParameters, commandType: CommandType.StoredProcedure).ToList());
            }
            return userobject;
        }
    }
}
