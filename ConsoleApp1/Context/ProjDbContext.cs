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
        //建立連線SQLConnetion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationService.GetDbConnectionString());
        }

        //資料表DbSet
        public DbSet<QueueMessage> QueueMessage { get; set; }
        public DbSet<QueueMessageStatus> QueueMessageStatus { get; set; }
        /*可略過，如table 沒有PK 需要用以下設定*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QueueMessage>()
         //該table 沒有PK Key
         //modelBuilder.Entity<QueueMessage>().HasNoKey();
         //.HasMany(p => p.QueueMessage)
         //.HasNoKey()
         ;
        }
    }
}
