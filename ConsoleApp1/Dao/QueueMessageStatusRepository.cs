using ConsoleApp1.Context;
using ConsoleApp1.Entity;
using ConsoleApp1.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Dao
{
    public class QueueMessageStatusRepository : AbstractEntityRepository<QueueMessageStatus>
    {
        private ProjDbContext db;

        //2.
        public QueueMessageStatusRepository(ProjDbContext _db) : base(_db)
        {
            db = _db;
        }

        //3.
        public override List<QueueMessageStatus> GetEntitiesQ()
        {
            return db.QueueMessageStatus.ToListIQ();
        }
    }
}
