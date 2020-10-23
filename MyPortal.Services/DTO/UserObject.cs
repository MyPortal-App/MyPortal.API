using System.Collections.Generic;

namespace MyPortal.Services.DTO
{
    public class UserObject
    {        
        public UserObject()
        {
            Roles = new List<Role>();
        }
        
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool ResetPassword { get; set; }
        public string ResetPasswordId { get; set; }
        public bool Enabled { get; set; }
        public string AltId { get; set; }
        public List<Role> Roles { get; set; }

        public int[] SelectedRoleIds { get; set; }
    }
}
