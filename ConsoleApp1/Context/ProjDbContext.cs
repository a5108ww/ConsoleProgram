using ConsoleApp1.Entity;
using ConsoleApp1.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Context
{
    public class ProjDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationService.GetDbConnectionString());
        }

       

        public DbSet<QueueMessage> QueueMessage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QueueMessage>()
            //.HasMany(p => p.QueueMessage)
            //.HasNoKey()
            ;
        }
    }
}
