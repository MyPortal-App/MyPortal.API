﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortal.Entity.DbEntities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
        public string Designation { get; set; }
        public string JobTitle { get; set; }
        public int SalaryLevel { get; set; }
        public string ChiefDirectorate { get; set; }
        public string Directorate { get; set; }
        public string SubDirectorate { get; set; }
        public string OfficeLocation { get; set; }
        public string ContactNumberOffice { get; set; }
        public string ContactCell { get; set; }
        public string AppointmentDate { get; set; }
        public string ProbationPeriodstatus { get; set; }
        public string InductionStatus { get; set; }
        public string Manager { get; set; }
        public string Highestqualification { get; set; }
        public string HomeAddress { get; set; }
        public string Maritalstatus { get; set; }
        public string SpouseName { get; set; }
        public string SpouseMaidenName { get; set; }
        public string NextofKinName { get; set; }
        public string NextofKinSurname { get; set; }
        public string NextofKinRelation { get; set; }
    }
}


