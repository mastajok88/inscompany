using System.Linq;
using InsCompany.DataAccess.Models;
using InsCompany.DataModel.Repository.PolicyRepository;
using InsCompany.DataModel.Repository.RiskRepository;
using InsCompany.DataModel.Service;
using NUnit.Framework;

namespace InsCompany.Tests
{
    [TestFixture]
    public class PolicyServiceTest : BaseTest
    {
        private PolicyService _policyService;
        private PolicyRepository _policyRepository;
        private RiskRepository _riskRepository;

        internal override void SetBaseTestData()
        {
            base.SetBaseTestData();

            _policyRepository = new PolicyRepository(_db);

            _riskRepository = new RiskRepository(_db);

            _policyService = new PolicyService(_policyRepository, _riskRepository);

        }

        [Test]
        public void AddRiskToPolicy()
        {
            _policyRepository.Update(new Policy[] { TestPolicy });

            var policy = _policyRepository.GetList().First();


            var newRisk = new Risk
            {
                Name = "Accident",
                YearlyPrice = 150
            };

            _riskRepository.Update(new Risk[]{ newRisk });

            var addedRisk = _riskRepository.GetList().First(x => x.Name == newRisk.Name);

            var modifiedPolicy = _policyService.AddRiskToPolicy(policy.PolicyId, addedRisk.RiskId);

            //Assert.Contains();
        }

        [Test]
        public void RemoveRiskFromPolicy()
        {

        }
    }
}
