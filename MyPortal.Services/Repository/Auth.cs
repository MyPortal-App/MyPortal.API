using Microsoft.EntityFrameworkCore;
using MyPortal.Entity.DbEntities;
using MyPortal.Entity.Dto_s;
using MyPortal.Persistance;
using MyPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPortal.Services.Repository
{
    public class Auth : IAuth
    {
        private readonly ApplicationDbContext _db;
        public Auth(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Entity.DbEntities.User> Login(string username, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Username == username && x.PasswordHash == password);
            if (user == null)
                return null;
          
            return user;
        }
    }
}
