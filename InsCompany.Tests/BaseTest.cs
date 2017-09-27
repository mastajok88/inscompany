﻿using InsCompany.DataModel.DataContext;
using NUnit.Framework;

namespace InsCompany.Tests
{
    public abstract class BaseTest
    {
        internal InsCompanyContext _db;

        [SetUp]
        public virtual void Init()
        {
            _db = new InsCompanyContext();
            _db.Database.Create();
            _db.SaveChanges();
        }

        [TearDown]
        public virtual void Dispose()
        {
            _db.Database.Delete();
            _db.SaveChanges();
        }
    }
}