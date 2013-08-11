// ****************************************************************
// <copyright file="DbRepository.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace MusicStore.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using MusicStore.Data;
    using MusicStore.Model;
    using System.Data;

    public class DbRepository<T> : IRepository<T>
        where T : class
    {
        private DbContext dbContext;
        private DbSet<T> entitySet;

        public DbRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<T>();
        }

        public T Add(T item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public T Update(int id, T album)
        {
            dbContext.Entry(album).State = EntityState.Modified;
            this.dbContext.SaveChanges();

            return album;
        }

        public void Delete(int id)
        {
            var album = this.entitySet.Find(id);
            if (album == null)
            {
                throw new ArgumentException("Album does not exists!");
            }

            this.Delete(album);
        }

        public void Delete(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("Album does not exists!");
            }

            this.entitySet.Remove(item);
            this.dbContext.SaveChanges();
        }

        public T Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<T> All()
        {
            return this.entitySet;
        }

        public IQueryable<T> Find(Expression<Func<T, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
