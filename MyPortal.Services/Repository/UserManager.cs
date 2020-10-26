using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using MyPortal.Entity.DTO;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

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

        public IList<UserProfile> GetUserProfileList() => GetUserProfileListAsync().Result;
        public async Task<IList<UserProfile>> GetUserProfileListAsync()        
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

        public IList<UserProfile> GetUserProfileById(int id) => GetUserProfileByIdByAsync(id).Result;
        public async Task<IList<UserProfile>> GetUserProfileByIdByAsync(int id)
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
    }
}
