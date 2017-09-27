using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InsCompany.DataModel.Repository
{
    interface IRepository
    {
        void Update<T>(T obj, params Expression<Func<T, object>>[] propertiesToUpdate) where T : class;
        
    }
}
