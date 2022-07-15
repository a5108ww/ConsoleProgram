using ConsoleApp1.Context;
using ConsoleApp1.Dao;
using ConsoleApp1.Entity;
using ConsoleApp1.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        private static QueueMessageRepository queueMessageRepository;
        private static ProjDbContext db;

        public static void Init()
        {
            db = new ProjDbContext();

            //
            queueMessageRepository = new QueueMessageRepository(db);
        }

        static void Main(string[] args)
        {
            Init();

            List<QueueMessage> queueMessages = queueMessageRepository.GetEntitiesQ();
            QueueMessage queueMessage1 = queueMessages.Where(p => p.Sn == 1).FirstOrDefault();
            queueMessage1.MessageText = DateTime.Now.ToString(); 
            queueMessageRepository.Save(queueMessage1, EntityState.Modified);

            QueueMessage queueMessage2 = queueMessages.Where(p => p.Sn == 1).FirstOrDefault();
            queueMessageRepository.Delete(queueMessage2);

            Console.WriteLine("Hello World!");
        }
    }
}
