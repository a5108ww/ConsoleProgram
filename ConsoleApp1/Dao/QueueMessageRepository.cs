using ConsoleApp1.Context;
using ConsoleApp1.Entity;
using ConsoleApp1.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Dao
{
    public class QueueMessageRepository : AbstractEntityRepository<QueueMessage>
    {
        private ProjDbContext db;
        public QueueMessageRepository(ProjDbContext _db) : base(_db)
        {
            db = _db;
        }

        public override List<QueueMessage> GetEntitiesQ()
        {
            return db.QueueMessage.ToListIQ();
        }
    }
}
