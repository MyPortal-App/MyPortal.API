using Microsoft.EntityFrameworkCore;
using MyPortal.Entity.DbEntities;
using MyPortal.Persistance;
using MyPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPortal.Services.Repository
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        public DbInitializer(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Initialize()
        {
            if (_db.Database.GetPendingMigrations().Count() > 0)
            {
                _db.Database.Migrate();
            }
            _db.Database.EnsureCreated();

            var user = _db.Users.FirstOrDefault();
            if (user == null)
            {
                User user1 = new User();
                user1.Age = 30;
                user1.AppointmentDate = "February 2018";
                user1.ChiefDirectorate = "Strategic and Support";
                user1.ContactCell = "0987654433";
                user1.ContactNumberOffice = "02156789";
                user1.Designation = "DD.Health Systems";
                user1.Directorate = "Information Management";
                user1.Firstname = "Thompson";
                user1.Highestqualification = "Degree";
                user1.HomeAddress = "Tygervalley";
                user1.InductionStatus = "TBD";
                user1.JobTitle = "Information Technology and Related Pers";
                user1.LastName = "Mikes";
                user1.Manager = "Adam Loff";
                user1.Maritalstatus = "Married";
                user1.NextofKinName = "Tracy";
                user1.NextofKinRelation = "Sister";
                user1.NextofKinSurname = "Mikes";
                user1.OfficeLocation = "2nd Floor Norton Rose House CapeTown";
                user1.PasswordHash = "P@ssw0rd";
                user1.PasswordSalt = "P@ssw0rd";
                user1.Password = "P@ssw0rd";
                user1.ProbationPeriodstatus = "Completed";
                user1.Race = "Coloured";
                user1.SalaryLevel = 9;
                user1.Sex = "Male";
                user1.SpouseMaidenName = "Jamal";
                user1.SpouseName = "Susan";
                user1.SubDirectorate = "Systems Development";
                user1.Username = "user@westerncape.gov.za";
                _db.Users.Add(user1);
                _db.SaveChanges();


            }

        }
    }
}
