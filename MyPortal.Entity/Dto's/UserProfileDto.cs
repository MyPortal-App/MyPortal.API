using MyPortal.Entity.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortal.Entity.Dto_s
{
    public class UserProfileDto
    {
        public string  Token { get; set; }
        public UserDto User  { get; set; }

    }
}
