using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using MyPortal.Entity.DTO;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System;

namespace MyPortal.Services.Repository
{
    public class UserManager : IUserManager
    {
        private IConfiguration Configuration { get; set; }
        private SqlConnection DbConnection { get { return new SqlConnection(Configuration.GetConnectionString("DefaultConnection")); } }
        //public Roles(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //private IConfiguration Configuration { get; set; }
        public UserManager(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<UserProfile> GetUserProfileList() => GetUserProfileListAsync().Result;
        public async Task<List<UserProfile>> GetUserProfileListAsync()        
        {

            List<UserProfile> userProfiles1 = new List<UserProfile>();
            List<User> users = new List<User>();
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                users.AddRange(connection.Query<User>("[dbo].[sp_GetUsers]", commandType: CommandType.StoredProcedure).ToList());
            }

            List<UserProfile> userProfiles = new List<UserProfile>();
            foreach (var item in users)
            {
                User user = new User
                {
                    Id = item.Id,
                    Age = item.Age,
                    AppointmentDate = item.AppointmentDate,
                    ChiefDirectorate = item.ChiefDirectorate,
                    ContactCell = item.ContactCell,
                    ContactNumberOffice = item.ContactNumberOffice,
                    Designation = item.Designation,
                    Directorate = item.Directorate,
                    Firstname = item.Firstname,
                    Highestqualification = item.Highestqualification,
                    HomeAddress = item.HomeAddress,
                    InductionStatus = item.InductionStatus,
                    JobTitle = item.JobTitle,
                    LastName = item.LastName,
                    Manager = item.Manager,
                    Maritalstatus = item.Maritalstatus,
                    NextofKinName = item.NextofKinName,
                    NextofKinRelation = item.NextofKinRelation,
                    NextofKinSurname = item.NextofKinSurname,
                    OfficeLocation = item.OfficeLocation,
                    //PasswordHash = "P@ssw0rd",
                    //PasswordSalt = "P@ssw0rd",
                    //Password = "P@ssw0rd",
                    ProbationPeriodstatus = item.ProbationPeriodstatus,
                    Race = item.Race,
                    SalaryLevel = item.SalaryLevel,
                    Sex = item.Sex,
                    SpouseMaidenName = item.SpouseMaidenName,
                    SpouseName = item.SpouseName,
                    SubDirectorate = item.SubDirectorate,
                    Username = item.Username,
                };

                UserProfile userProfile = new UserProfile
                {
                    User = user
                };
                userProfiles.Add(userProfile);
            }
            
            return await Task.FromResult(userProfiles);
        }

        public List<UserProfile> GetUserProfileById(int id) => GetUserProfileByIdAsync(id).Result;
        public async Task<List<UserProfile>> GetUserProfileByIdAsync(int id)
        {
            List<UserProfile> userProfiles1 = new List<UserProfile>();
            List<User> users = new List<User>();
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);

            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                users.AddRange(connection.Query<User>("[dbo].[sp_GetUserBy_Id]", param, commandType: CommandType.StoredProcedure).ToList());
            }

            List<UserProfile> userProfiles = new List<UserProfile>();
            foreach (var item in users)
            {
                User user = new User
                {
                    Age = item.Age,
                    AppointmentDate = item.AppointmentDate,
                    ChiefDirectorate = item.ChiefDirectorate,
                    ContactCell = item.ContactCell,
                    ContactNumberOffice = item.ContactNumberOffice,
                    Designation = item.Designation,
                    Directorate = item.Directorate,
                    Firstname = item.Firstname,
                    Highestqualification = item.Highestqualification,
                    HomeAddress = item.HomeAddress,
                    InductionStatus = item.InductionStatus,
                    JobTitle = item.JobTitle,
                    LastName = item.LastName,
                    Manager = item.Manager,
                    Maritalstatus = item.Maritalstatus,
                    NextofKinName = item.NextofKinName,
                    NextofKinRelation = item.NextofKinRelation,
                    NextofKinSurname = item.NextofKinSurname,
                    OfficeLocation = item.OfficeLocation,
                    //PasswordHash = "P@ssw0rd",
                    //PasswordSalt = "P@ssw0rd",
                    //Password = "P@ssw0rd",
                    ProbationPeriodstatus = item.ProbationPeriodstatus,
                    Race = item.Race,
                    SalaryLevel = item.SalaryLevel,
                    Sex = item.Sex,
                    SpouseMaidenName = item.SpouseMaidenName,
                    SpouseName = item.SpouseName,
                    SubDirectorate = item.SubDirectorate,
                    Username = item.Username,
                };

                UserProfile userProfile = new UserProfile
                {
                    User = user
                };
                userProfiles.Add(userProfile);
            }

            return await Task.FromResult(userProfiles);
        }
                
        public List<User> GetUserById(int id) => GetUserByIdAsync(id).Result;
        public async Task<List<User>> GetUserByIdAsync(int id)
        {            
            List<User> users = new List<User>();
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);

            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                users.AddRange(connection.Query<User>("[dbo].[sp_GetUserBy_Id]", param, commandType: CommandType.StoredProcedure).ToList());
            }                        
                
            return await Task.FromResult(users);
        }

        public int SaveUser(User user) => SaveUserAsync(user).Result;
        public async Task<int> SaveUserAsync(User user)
        {
            //User _user = new User();
            int _userId = 0;
            //int _userId = Convert.ToInt32(user.Id);
            int i = 0;

            bool isNumber = int.TryParse(user.Id, out i);

            if (isNumber)
                _userId = Convert.ToInt16(user.Id);

            DynamicParameters dp = new DynamicParameters();
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();

                dp.Add("@Age", user.Age);
                dp.Add("@AppointmentDate", user.AppointmentDate);
                dp.Add("@ChiefDirectorate", user.ChiefDirectorate);
                dp.Add("@ContactCell", user.ContactCell);
                dp.Add("@ContactNumberOffice", user.ContactNumberOffice);
                dp.Add("@Designation", user.Designation);
                dp.Add("@Directorate", user.Directorate);
                dp.Add("@Firstname", user.Firstname);
                dp.Add("@Highestqualification", user.Highestqualification);
                dp.Add("@HomeAddress", user.HomeAddress);
                dp.Add("@InductionStatus", user.InductionStatus);
                dp.Add("@JobTitle", user.JobTitle);
                dp.Add("@LastName", user.LastName);
                dp.Add("@Manager", user.Manager);
                dp.Add("@Maritalstatus", user.Maritalstatus);
                dp.Add("@NextofKinName", user.NextofKinName);
                dp.Add("@NextofKinRelation", user.NextofKinRelation);
                dp.Add("@NextofKinSurname", user.NextofKinSurname);
                dp.Add("@OfficeLocation", user.OfficeLocation);
                dp.Add("@PasswordHash", "P@ssw0rd");
                dp.Add("@PasswordSalt", "P@ssw0rd");
                dp.Add("@Password", "P@ssw0rd");
                dp.Add("@ProbationPeriodstatus", user.ProbationPeriodstatus);
                dp.Add("@Race", user.Race);
                dp.Add("@SalaryLevel", Convert.ToInt16(user.SalaryLevel));
                dp.Add("@Sex", user.Sex);
                dp.Add("@SpouseMaidenName", user.SpouseMaidenName);
                dp.Add("@SpouseName", user.SpouseName);
                dp.Add("@SubDirectorate", user.SubDirectorate);
                dp.Add("@Username", user.Username);

                if (_userId > 0)
                {
                    dp.Add("@Id", _userId);
                    await connection.ExecuteAsync("sp_UpdateUser", dp, commandType: CommandType.StoredProcedure);
                    
                    return await Task.FromResult(_userId);
                }
                else
                {
                    return await connection.ExecuteAsync("sp_AddNewUser", dp, commandType: CommandType.StoredProcedure);
                }
            }
        }
    }
}
