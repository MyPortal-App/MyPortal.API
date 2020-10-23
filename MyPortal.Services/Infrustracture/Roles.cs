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
    public class Roles
    {
        private IConfiguration Configuration { get; set; }
        private SqlConnection DbConnection { get { return new SqlConnection(Configuration.GetConnectionString("DefaultConnection")); } }
        public Roles(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<Role> GetAllRoles()
        {
            List<Role> roles = new List<Role>();
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                roles.AddRange(connection.Query<Role>("[dbo].[sp_GetRoles]", commandType: CommandType.StoredProcedure).ToList());
            }

            return roles;
        }

        public void AddNewRole(string RoleName)
        {
            if (string.IsNullOrEmpty(RoleName)) throw new Exception("Role Name cannot be empty");

            DynamicParameters param = new DynamicParameters();
            param.Add("@rolename", RoleName);
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                connection.Query("[dbo].[sp_AddNewRole]", param, commandType: CommandType.StoredProcedure).ToList();
            }

        }

        public List<Role> GetUserRoles(int userId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@userid", userId);
            List<Role> role = new List<Role>();
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                role.AddRange(connection.Query<Role>("[dbo].[sp_GetUserRolesByUserId]", param, commandType: CommandType.StoredProcedure).ToList());
            }
            return role;
        }

        public void AddroleToUser(int userid, int roleid)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@userid", userid);
            param.Add("@roleid", roleid);
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                connection.Query("[dbo].[sp_AddRolesToUser]", param, commandType: CommandType.StoredProcedure);
            }
        }

        public void RemoveroleFromUser(int userid, int roleid)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@userid", userid);
            param.Add("@roleid", roleid);
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                connection.Query("[dbo].[sp_RemoveRoleFromUser]", param, commandType: CommandType.StoredProcedure);
            }
        }

        public void RemoveRoleByRoleId(int roleid)
        {
            DynamicParameters param = new DynamicParameters();            
            param.Add("@roleid", roleid);
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                connection.Query("[dbo].[sp_RemoveRole]", param, commandType: CommandType.StoredProcedure);
            }            
        }
    }
}
