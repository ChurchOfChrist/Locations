using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Locations.Core.Entities;
using Locations.Core.IRepositories;
using Locations.DataAccessLayer.Context;

namespace Locations.DataAccessLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext Context;
        protected DbSet<T> EntitySet;

        public Repository()
        {
            Context = new ChurchDb();
            EntitySet = Context.Set<T>();
        }

        public Repository(DbContext context)
        {
            Context = context;
            EntitySet = context.Set<T>();
        }
        public T Add(T entity)
        {
            return EntitySet.Add(entity);
        }

        public IEnumerable<T> All()
        {
            return EntitySet;
        }

        public T GetById(int id)
        {
            return EntitySet.Find(id);
        }

        public void SaveChanges()
        {
            //Avoid updating creation date and maybe other future property 
            //When an entity is created the first time
            foreach (var entry in Context.ChangeTracker.Entries<Entity>()
                .Where(entry => entry.State == EntityState.Added))
            {
                entry.Entity.CreationDate = DateTime.Now;
            }
            Context.SaveChanges();
        }
    }
}
