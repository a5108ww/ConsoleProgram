using ConsoleApp1.Context;
using ConsoleApp1.Entity;
using ConsoleApp1.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Dao
{
    public class QueueMessageRepository : AbstractEntityRepository<QueueMessage>
    {
        /*
        每新增一個新的 Repository，以下3部分缺一不可，
        如有取得特定的資料，請自行新增public方法讓Program使用
         */

        //1.
        private ProjDbContext db;

        //2.
        public QueueMessageRepository(ProjDbContext _db) : base(_db)
        {
            db = _db;
        }

        //3.
        public override List<QueueMessage> GetEntitiesQ()
        {
            return db.QueueMessage.ToListIQ();
        }

        public void SaveEntity(QueueMessage queueMessage)
        {
            QueueMessage editQueueMessage = queueMessage;

            if (editQueueMessage != null)
            {
                if(editQueueMessage.Sn > 0)
                {
                    editQueueMessage = GetBySnWithSql(editQueueMessage.Sn);

                    editQueueMessage.MessageID = queueMessage.MessageID;
                    editQueueMessage.MessageText = queueMessage.MessageText;
                    editQueueMessage.QueueID = queueMessage.QueueID;
                    editQueueMessage.InsertionTime = queueMessage.InsertionTime;
                    editQueueMessage.DequeueCount = queueMessage.DequeueCount;
                    editQueueMessage.QueueMessageStatusID = queueMessage.QueueMessageStatusID;

                    Save(editQueueMessage, EntityState.Modified);
                }
                else
                {
                    //如果有新增情境，取消以下註解
                    //Save(editQueueMessage,EntityState.Added);
                }
            }
        }

        /// <summary>
        /// EntityFrame 下sql
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public QueueMessage GetBySnWithSql(int sn)
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();

            sb.Append(" Select * From [" + QueueMessage.TableName + "] as " + QueueMessage.TableName + " ");
            sb.Append(" Where 1 = 1 ");

            if (sn > 0)
            {
                sb.Append(" And Sn = @Sn");
                parameters.Add(new SqlParameter("Sn", sn));
            }
           
            return db.QueueMessage.FromSqlRaw(sb.ToString(), parameters.ToArray()).FirstOrDefault();
            //return db.QueueMessage.Where(p => p.Sn == sn).FirstOrDefault();
        }

        public QueueMessage GetBySN(int sn)
        {
            return GetEntitiesQ().Where(p => p.Sn == sn).FirstOrDefault();
        }
    }
}
