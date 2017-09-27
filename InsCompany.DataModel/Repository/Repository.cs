﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace InsCompany.DataModel.Repository
{
    public class Repository : DbContext, IRepository
    {
        public void Update<T>(T obj, params Expression<Func<T, object>>[] propertiesToUpdate) where T : class
        {
            Set<T>().Attach(obj);
            propertiesToUpdate.ToList().ForEach(p => Entry(obj).Property(p).IsModified = true);
            SaveChanges();
        }
    }
}