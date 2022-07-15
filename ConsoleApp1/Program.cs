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
        /*
        大意：每新增一個資料表的DAO，要做以下事情：
        1.新增 Table Class，欄位不能少且注意資料型態，該可null就要null，例如：public Datetime? dateStart { get;set; }
        2.將新增的Table Class設定在DbContext中(請參考QueueMessage)
        3.新增一個Repository，照QueueMessageRepository的設定方式，Repository使用詳細說明請至 QueueMessageRepository瀏覽

        Program 程式如何使用QueueMessageRepository，請參考以下有標記數字的部分
        
         */

        private static ProjDbContext db;

        //1.
        private static QueueMessageRepository queueMessageRepository;
        
       
        public static void Init()
        {
            db = new ProjDbContext();

            //2.
            queueMessageRepository = new QueueMessageRepository(db);
        }

        static void Main(string[] args)
        {
            Init();

            Console.WriteLine("Hello World!");
        }

        public void SaveData()
        {
            //新增資料
            QueueMessage queueMessage = new QueueMessage();
            queueMessage.MessageText = DateTime.Now.ToString();
            queueMessageRepository.Save(queueMessage, EntityState.Added);

            //編輯資料
            List<QueueMessage> queueMessages = queueMessageRepository.GetEntitiesQ();
            QueueMessage queueMessage1 = queueMessages.Where(p => p.Sn == 1).FirstOrDefault();
            queueMessageRepository.Save(queueMessage, EntityState.Modified);
        }
    }
}
