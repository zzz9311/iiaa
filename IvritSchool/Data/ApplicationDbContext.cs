using IvritSchool.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IvritSchool.Data
{
    public class ApplicationDbContext : IdentityDbContext, ISaveChangesCommand
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<BotUser> BotUsers { get; set; }
        public DbSet<Days> Days { get; set; }
        public DbSet<Message> Messages { get; set; }

        public void SaveChanges()
        { 
            base.SaveChanges();
        }
    }
}
