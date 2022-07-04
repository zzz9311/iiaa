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
        }

        public DbSet<BotUser> BotUsers { get; set; }
        public DbSet<Days> Days { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PayedUsers> PayedUsers { get; set; }
        public DbSet<MessagesToSend> MessagesToSend { get; set; }
        public void SaveChanges()
        { 
            base.SaveChanges();
        }
    }
}
