using Microsoft.EntityFrameworkCore;
using MyPortal.Entity.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortal.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Logging> Logging { get; set; }


    }
}
