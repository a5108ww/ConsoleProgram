using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Extensions
{
    public static class CollectionExtension
    {
        public static List<T> ToListIQ<T>(this IQueryable<T> entities)
        {
            List<T> list = new List<T>();

            if(entities != null && entities.Count() > 0)
            {
                list = entities.ToList();
            }

            return list;
        }

        public static List<T> ToListIE<T>(this IEnumerable<T> entities)
        {
            List<T> list = new List<T>();

            if (entities != null && entities.Count() > 0)
            {
                list = entities.ToList();
            }

            return list;
        }
    }
}
