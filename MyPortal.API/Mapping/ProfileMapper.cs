using MyPortal.Entity.DbEntities;
using MyPortal.Entity.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortal.API.Mapping
{
    public class ProfileMapper
    {
        public static async Task<UserProfileDto> ProfileDtoMapper(string token, User user)
        {
            string Id = string.Empty;
            string Username = string.Empty;
            string Password = string.Empty;
            string Firstname = string.Empty;
            string LastName = string.Empty;
            string Age = string.Empty;
            string Sex = string.Empty;
            string Race = string.Empty;
            string Designation = string.Empty;
            string JobTitle = string.Empty;
            string SalaryLevel = string.Empty;
            string ChiefDirectorate = string.Empty;
            string Directorate = string.Empty;
            string SubDirectorate = string.Empty;
            string OfficeLocation = string.Empty;
            string ContactNumberOffice = string.Empty;
            string ContactCell = string.Empty;
            string AppointmentDate = string.Empty;
            string ProbationPeriodstatus = string.Empty;
            string InductionStatus = string.Empty;
            string Manager = string.Empty;
            string Highestqualification = string.Empty;
            string HomeAddress = string.Empty;
            string Maritalstatus = string.Empty;
            string SpouseName = string.Empty;
            string SpouseMaidenName = string.Empty;
            string NextofKinName = string.Empty;
            string NextofKinSurname = string.Empty;
            string NextofKinRelation = string.Empty;
            string Token = string.Empty;



            if (Check(user.Id.ToString()) == false)
            {
                Id = user.Id.ToString();
            }

            if (Check(user.Username) == false)
            {
                Username = user.Username;
            }

            if (Check(user.Password) == false)
            {
                Password = user.Password;
            }

            if (Check(user.Firstname) == false)
            {
                Firstname = user.Firstname;
            }

            if (Check(user.LastName) == false)
            {
                LastName = user.LastName;
            }

            if (Check(user.Sex) == false)
            {
                Sex = user.Sex;
            }

            if (Check(user.Age.ToString()) == false)
            {
                Age = user.Age.ToString();
            }

            if (Check(user.Race) == false)
            {
                Race = user.Race;
            }

            if (Check(user.Designation) == false)
            {
                Designation = user.Designation;
            }

            if (Check(user.JobTitle) == false)
            {
                JobTitle = user.JobTitle;
            }

            if (Check(user.SalaryLevel.ToString()) == false)
            {
                SalaryLevel = user.SalaryLevel.ToString();
            }

            if (Check(user.ChiefDirectorate) == false)
            {
                ChiefDirectorate = user.ChiefDirectorate;
            }

            if (Check(user.SubDirectorate) == false)
            {
                SubDirectorate = user.SubDirectorate;
            }

            if (Check(user.OfficeLocation) == false)
            {
                OfficeLocation = user.OfficeLocation;
            }

            if (Check(user.ContactNumberOffice) == false)
            {
                ContactNumberOffice = user.ContactNumberOffice;
            }

            if (Check(user.ContactCell) == false)
            {
                ContactCell = user.ContactCell;
            }

            if (Check(user.AppointmentDate) == false)
            {
                AppointmentDate = user.AppointmentDate;
            }

            if (Check(user.ProbationPeriodstatus) == false)
            {
                ProbationPeriodstatus = user.ProbationPeriodstatus;
            }

            if (Check(user.InductionStatus) == false)
            {
                InductionStatus = user.InductionStatus;
            }

            if (Check(user.Manager) == false)
            {
                Manager = user.Manager;
            }

            if (Check(user.Highestqualification) == false)
            {
                Highestqualification = user.Highestqualification;
            }

            if (Check(user.HomeAddress) == false)
            {
                HomeAddress = user.HomeAddress;
            }

            if (Check(user.Maritalstatus) == false)
            {
                Maritalstatus = user.Maritalstatus;
            }

            if (Check(user.SpouseName) == false)
            {
                SpouseName = user.SpouseName;
            }

            if (Check(user.SpouseMaidenName) == false)
            {
                SpouseMaidenName = user.SpouseMaidenName;
            }

            if (Check(user.NextofKinName) == false)
            {
                NextofKinName = user.NextofKinName;
            }

            if (Check(user.NextofKinSurname) == false)
            {
                NextofKinSurname = user.NextofKinSurname;
            }

            if (Check(user.NextofKinRelation) == false)
            {
                NextofKinRelation = user.NextofKinRelation;
            }

            if (Check(token.ToString()) == false)
            {
               Token = token;
            }

            UserProfileDto userProfileDto = new UserProfileDto();
            userProfileDto.User = new UserDto();
            userProfileDto.Token = Token;
            userProfileDto.User.Id = Id;
            userProfileDto.User.Username = Username;
            userProfileDto.User.Firstname = Firstname;
            userProfileDto.User.LastName = LastName;
            userProfileDto.User.Age = Age;
            userProfileDto.User.Sex = Sex;
            userProfileDto.User.Race = Race;
            userProfileDto.User.Designation = Designation;
            userProfileDto.User.JobTitle = JobTitle;
            userProfileDto.User.SalaryLevel = SalaryLevel;
            userProfileDto.User.ChiefDirectorate = ChiefDirectorate;
            userProfileDto.User.Directorate = Directorate;
            userProfileDto.User.SubDirectorate = SubDirectorate;
            userProfileDto.User.OfficeLocation = OfficeLocation;
            userProfileDto.User.ContactNumberOffice = ContactNumberOffice;
            userProfileDto.User.ContactCell = ContactCell;
            userProfileDto.User.AppointmentDate = AppointmentDate;
            userProfileDto.User.ProbationPeriodstatus = ProbationPeriodstatus;
            userProfileDto.User.InductionStatus = InductionStatus;
            userProfileDto.User.Manager = Manager;
            userProfileDto.User.Highestqualification = Highestqualification;
            userProfileDto.User.HomeAddress = HomeAddress;
            userProfileDto.User.Maritalstatus = Maritalstatus;
            userProfileDto.User.SpouseName = SpouseName;
            userProfileDto.User.SpouseMaidenName = SpouseMaidenName;
            userProfileDto.User.NextofKinName = NextofKinName;
            userProfileDto.User.NextofKinSurname = NextofKinSurname;
            userProfileDto.User.NextofKinRelation = NextofKinRelation;

            return userProfileDto;
        }
        private static bool Check(string sCheck)
        {
            return (sCheck == null || sCheck == string.Empty) ? true : false;
        }

    }
}




