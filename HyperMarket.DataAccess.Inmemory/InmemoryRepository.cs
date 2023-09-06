using HyperMarket.Core.Contracts;
using HyperMarket.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace HyperMarket.DataAccess.Inmemory
{
    public class InmemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;
        public InmemoryRepository()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;
            if(items == null)
            { 
                items = new List<T>();
            }
        }
        public IQueryable<T> Collection()
        {
            return items. AsQueryable();
        }

        public void commit()
        {
            cache[className] = items;
        }

        public void Delete(string Id)
        {
            T tToDelete = items.Find(i => i.Id == Id);
            if (tToDelete == null)
                throw new Exception(className + "Not found");
            else
                items.Remove(tToDelete);
        }

        public T Find(string Id)
        {
            T t = items.Find(i => i.Id == Id);
            if (t != null)
                return t;
            else
                throw new Exception(className + " Not Found");
        }

        public void Insert(T t)
        {
            items.Add(t);
        }

        public void Update(T t)
        {
            T tToUpdate = items.Find(i => i.Id == t.Id);
            if (tToUpdate != null)
                tToUpdate = t;
            else
                throw new Exception(className + "Not  Found");
        }
    }
}
