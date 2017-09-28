using System;
using System.Collections.Generic;
using System.Linq;
using InsCompany.DataAccess.Models;
using InsCompany.DataAccess.Repository.PolicyRepository;
using InsCompany.DataAccess.Repository.RiskRepository;
using NUnit.Framework;

namespace InsCompany.DataAccess.Test
{
    [TestFixture]
    public class PolicyRepositoryTest : BaseDataAccessTest
    {
        private PolicyRepository _policyRepository;

        

        internal override void SetBaseTestData()
        {
            base.SetBaseTestData();
          
            _policyRepository = new PolicyRepository(_db);
        }
        
        [Test]
        public void AddAndGet()
        {
            RiskRepository riskRepository = new RiskRepository(_db);
            riskRepository.Update(TestRisks.ToArray());
            _policyRepository.Update(new Policy[]{TestPolicy});
            var policyList = _policyRepository.GetList();
            Assert.AreEqual(1, policyList.Count);
        }

        [Test]
        public void Delete()
        {
            _policyRepository.Update(new Policy[] { TestPolicy });
            List<Policy> originalPolicyList = _policyRepository.GetList();
            Assert.Contains(TestPolicy, originalPolicyList);
            Policy policy = originalPolicyList.First();
            _policyRepository.Delete(policy.PolicyId);
            Policy deletedPolicy = _policyRepository.Get(policy.PolicyId);
            Assert.IsNull(deletedPolicy);
        }

        [Test]
        public void Update()
        {
            _policyRepository.Update(new Policy[] { TestPolicy });
            Policy policy = _policyRepository.GetList().First();
            int policyRiskCount = policy.InsuredRisks.Count;
            Risk risk = policy.InsuredRisks.First();
            policy.InsuredRisks.Remove(risk);
            policy.NameOfInsuredObject = "Appartment policy modified";
            policy.ValidFrom = new DateTime(2017, 01, 01);
            policy.ValidTill = new DateTime(2017, 12, 31);
            _policyRepository.Update(new Policy[] { TestPolicy });
            Policy updatedPolicy = _policyRepository.Get(policy.PolicyId);
            Assert.AreEqual(policyRiskCount - 1, updatedPolicy.InsuredRisks.Count);
        }
    }
}

