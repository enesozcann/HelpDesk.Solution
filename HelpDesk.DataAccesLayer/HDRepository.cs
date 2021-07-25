using HelpDesk.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HelpDesk.DataAccesLayer
{
    public class HDRepository<T> where T : class
    {
        private HDDatabaseContext db;
        private DbSet<T> _objSet;

        public HDRepository()
        {
            db = HDRepositoryBase.HDCreateContext();
            _objSet = db.Set<T>();
        }

        public List<T> List()
        {
            return _objSet.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _objSet.Where(where).ToList();
        }

        public IQueryable<T> ListQ()
        {
            return _objSet.AsQueryable<T>();
        }

        public IQueryable<T> ListQ(Expression<Func<T, bool>> where)
        {
            return _objSet.Where(where).AsQueryable<T>();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objSet.FirstOrDefault(where);

        }

        public int Insert(T obj)
        {
            _objSet.Add(obj);
            return Save();
        }

        public int Delete(T obj)
        {
            _objSet.Remove(obj);
            return Save();
        }

        public int Update(T obj)
        {
            if (obj is HDEntityBase)
            {
                HDEntityBase o = obj as HDEntityBase;

                o.ModifiedOn = DateTime.Now;
            }

            return Save();
        }

        private int Save()
        {
            return db.SaveChanges();
        }
    }
}