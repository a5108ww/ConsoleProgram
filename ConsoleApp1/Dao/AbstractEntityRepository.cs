using ConsoleApp1.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Dao
{
    public abstract class AbstractEntityRepository<T>
    {
        protected readonly ProjDbContext db;

        public AbstractEntityRepository(ProjDbContext _db)
        {
            db = _db;
        }

        public abstract List<T> GetEntitiesQ();

        public void Delete(T entity)
        {
            if(entity != null)
            {
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(List<T> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (T entity in entities)
                {
                    Delete(entity);
                }
            }
        }

        public virtual void Save(T entity, EntityState entityState = EntityState.Modified)
        {
            if (entity != null)
            {
                Save(new List<T>() { entity }, entityState);
            }
        }

        public virtual void Save(List<T> entitys, EntityState entityState = EntityState.Modified)
        {
            if (entitys != null && entitys.Count > 0)
            {
                foreach (T entity in entitys)
                {
                    db.Entry(entity).State = entityState;
                }

                db.SaveChanges();
            }
        }
    }
}
