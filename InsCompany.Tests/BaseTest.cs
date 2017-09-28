using System;
using System.Collections.Generic;
using InsCompany.DataAccess.DataContext;
using InsCompany.DataAccess.Models;
using NUnit.Framework;

namespace InsCompany.Tests
{
    public abstract class BaseTest
    {
        internal InsCompanyContext _db;
        public List<Risk> TestRisks { get; private set; }

        public Policy TestPolicy { get; private set; }

        [SetUp]
        public virtual void Init()
        {
            _db = new InsCompanyContext();

            if (!_db.Database.Exists())
            {
                _db.Database.Create();
                _db.SaveChanges();
            }

            SetBaseTestData();

        }

        [TearDown]
        public virtual void Dispose()
        {
            _db.Database.Delete();
            _db.Dispose();
        }

        internal virtual void SetBaseTestData()
        {
            TestRisks = new List<Risk>(){
                new Risk
                {
                    Name = "Fire",
                    YearlyPrice = 100
                },

                new Risk
                {
                    Name = "Flooding",
                    YearlyPrice = 100
                },
                new Risk
                {
                    Name = "Thief",
                    YearlyPrice = 100
                }};

            TestPolicy = new Policy
            {
                InsuredRisks = TestRisks,
                NameOfInsuredObject = "Appartment policy",
                ValidFrom = new DateTime(2016, 12, 31),
                ValidTill = new DateTime(2017, 12, 31)
            };
        }

    }
}
