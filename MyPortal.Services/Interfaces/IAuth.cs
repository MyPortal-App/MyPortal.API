using MyPortal.Entity.DbEntities;
using MyPortal.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPortal.Services.Interfaces
{
    public interface IAuth
    {
        Task<Entity.DbEntities.User> Login(string username, string password);
    }
}
