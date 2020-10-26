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


            //return UserProfile;

            //List<UserProfile> userProfiles = new List<UserProfile>();
            //    User user = new User
            //    {
            //        Age = "30",
            //        AppointmentDate = "February 2018",
            //        ChiefDirectorate = "Strategic and Support",
            //        ContactCell = "0987654433",
            //        ContactNumberOffice = "02156789",
            //        Designation = "DD.Health Systems",
            //        Directorate = "Information Management",
            //        Firstname = "Mike",
            //        Highestqualification = "Degree",
            //        HomeAddress = "Tygervalley",
            //        InductionStatus = "TBD",
            //        JobTitle = "Information Technology and Related Pers",
            //        LastName = "Tyson",
            //        Manager = "Adam Loff",
            //        Maritalstatus = "Married",
            //        NextofKinName = "Tracy",
            //        NextofKinRelation = "Sister",
            //        NextofKinSurname = "Mikes",
            //        OfficeLocation = "2nd Floor Norton Rose House CapeTown",
            //        //PasswordHash = "P@ssw0rd",
            //        //PasswordSalt = "P@ssw0rd",
            //        //Password = "P@ssw0rd",
            //        ProbationPeriodstatus = "Completed",
            //        Race = "Coloured",
            //        SalaryLevel = "9",
            //        Sex = "Male",
            //        SpouseMaidenName = "Jamal",
            //        SpouseName = "Susan",
            //        SubDirectorate = "Systems Development",
            //        Username = "user@westerncape.gov.za",
            //    };

            //    UserProfile userProfile1 = new UserProfile
            //    {
            //        User = user
            //    };

            //    userProfiles.Add(userProfile1);

            //    User user2 = new User
            //    {
            //        Age = "30",
            //        AppointmentDate = "February 2018",
            //        ChiefDirectorate = "Strategic and Support",
            //        ContactCell = "0987654433",
            //        ContactNumberOffice = "02156789",
            //        Designation = "DD.Health Systems",
            //        Directorate = "Information Management",
            //        Firstname = "Joe",
            //        Highestqualification = "Degree",
            //        HomeAddress = "Tygervalley",
            //        InductionStatus = "TBD",
            //        JobTitle = "Information Technology and Related Pers",
            //        LastName = "Mike",
            //        Manager = "Adam Loff",
            //        Maritalstatus = "Married",
            //        NextofKinName = "Tracy",
            //        NextofKinRelation = "Sister",
            //        NextofKinSurname = "Mikes",
            //        OfficeLocation = "2nd Floor Norton Rose House CapeTown",
            //        //PasswordHash = "P@ssw0rd",
            //        //PasswordSalt = "P@ssw0rd",
            //        //Password = "P@ssw0rd",
            //        ProbationPeriodstatus = "Completed",
            //        Race = "Coloured",
            //        SalaryLevel = "9",
            //        Sex = "Male",
            //        SpouseMaidenName = "Jamal",
            //        SpouseName = "Susan",
            //        SubDirectorate = "Systems Development",
            //        Username = "user@westerncape.gov.za",

            //    };

            //    UserProfile userProfile2 = new UserProfile
            //    {
            //        User =  user
            //    };

            //    userProfiles.Add(userProfile2);
            //using (Connection)
            //{
            //    devices = await Connection.GetAllAsync<Device>();
            //    DynamicParameters dp = new DynamicParameters();

            //    foreach (Device _device in devices)
            //    {
            //        dp.Add("deviceid", _device.id);
            //        IEnumerable<ColorSet> cs = await Connection.QueryAsync<ColorSet>("spGetColorSetByDeviceId", dp, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue);
            //        IEnumerable<DeviceImages> di = await Connection.QueryAsync<DeviceImages>("spGetDeviceImagesByDeviceId", dp, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue);
            //        cs.ToList().ForEach(x => x.Images.AddRange(di.Where(d => d.DeviceId == _device.id && x.id == d.ColorSetId).ToList()));
            //        _device.ColorSets = cs.ToList();
            //    }
            //}


            //return userProfiles;

            return await Task.FromResult(userProfiles);
        }        
    }
}
