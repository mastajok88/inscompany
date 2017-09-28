using System.Linq;
using InsCompany.DataAccess.Models;
using NUnit.Framework;

namespace InsCompany.Tests
{
    [TestFixture]
    public class PolicyServiceServiceTest : BaseServiceTest
    {
        [Test]
        public void AddRiskToPolicy()
        {
            _policyRepository.Update(new Policy[] { TestPolicy });
            Policy originalPolicy = _policyRepository.GetList().First();
            int originalPolicyRisksCount = originalPolicy.InsuredRisks.Count;
            var newRisk = new Risk
            {
                Name = "Accident",
                YearlyPrice = 150
            };
            _riskRepository.Update(new Risk[] { newRisk });
            var addedRisk = _riskRepository.GetList().First(x => x.Name == newRisk.Name);
            Policy modifiedPolicy = _policyService.AddRiskToPolicy(originalPolicy.PolicyId, addedRisk.RiskId);
            Assert.Equals(originalPolicyRisksCount + 1, modifiedPolicy.InsuredRisks.Count);
        }

        [Test]
        public void RemoveRiskFromPolicy()
        {
            _policyRepository.Update(new Policy[] { TestPolicy });
            Policy originalPolicy = _policyRepository.GetList().First();
            int originalPolicyRisksCount = originalPolicy.InsuredRisks.Count;
            var riskToDelete = originalPolicy.InsuredRisks.First();
            var modifiedPolicy = _policyRepository.RemoveRisk(originalPolicy.PolicyId, riskToDelete);
            Assert.Equals(originalPolicyRisksCount - 1, modifiedPolicy.InsuredRisks.Count);
        }
    }
}
