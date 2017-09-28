using System;
using System.Collections.Generic;
using InsCompany.DataAccess.DataContext;
using InsCompany.DataAccess.Models;
using InsCompany.DataAccess.Repository.PolicyRepository;
using InsCompany.DataAccess.Repository.RiskRepository;
using InsCompany.DataModel.Service.PolicyService;
using NUnit.Framework;

namespace InsCompany.Tests
{
    public abstract class BaseServiceTest
    {
        internal InsCompanyContext _db;

        protected PolicyService _policyService;

        protected PolicyRepository _policyRepository;

        protected RiskRepository _riskRepository;

        public List<Risk> TestRisks { get; private set; }

        public Policy TestPolicy { get; private set; }

        [SetUp]
        public virtual void Init()
        {
            _db = new InsCompanyContext();

            _policyRepository = new PolicyRepository(_db);

            _riskRepository = new RiskRepository(_db);

            _policyService = new PolicyService(_policyRepository, _riskRepository);

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
