﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            Context = applicationDbContext;
        }
        public ApplicationDbContext Context { get; set; }

        //Get(id)
        public abstract TEntity Get(int id, bool includeRelatedEntity = true);
        public virtual TEntity Get(string id)
        {
            var set = Context.Set<TEntity>();
            return set.Find(id);

        }
        //GetList()
        public abstract IList<TEntity> GetList();

        //Add(entity)
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }
        //Update(entity)
        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
        //Delete(id)
        public void Delete(int id)
        {
            var set = Context.Set<TEntity>();
            var entity = set.Find(id);
            set.Remove(entity);
            Context.SaveChanges();
        }
        public void Delete(string id)
        {
            var set = Context.Set<TEntity>();
            var entity = set.Find(id);
            set.Remove(entity);
            Context.SaveChanges();
        }



    }
}