using MyPortal.Entity.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortal.Entity.DTO
{
    public class UserProfile
    {
        public string  Token { get; set; }
        public User User  { get; set; }

    }
}
