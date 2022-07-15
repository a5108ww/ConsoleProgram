using ConsoleApp1.Context;
using ConsoleApp1.Entity;
using ConsoleApp1.Extensions;
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
                    editQueueMessage = GetBySN(editQueueMessage.Sn);

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

        public QueueMessage GetBySN(int sn)
        {
            return db.QueueMessage.Where(p => p.Sn == sn).FirstOrDefault();
        }
    }
}
