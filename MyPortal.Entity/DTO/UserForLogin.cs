using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPortal.Entity.Dto_s
{
    public class UserForLogin
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8,MinimumLength = 4,ErrorMessage ="You must enter password between 4 and 8 characters")]
        public string Password { get; set; }
    }
}
