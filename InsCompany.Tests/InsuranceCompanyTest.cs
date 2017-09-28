using InsCompany.DataModel.Service.InsuranceCompanyService;
using NUnit.Framework;

namespace InsCompany.Tests
{
    [TestFixture]
    public class InsuranceCompanyTest : BaseServiceTest
    {
        private InsuranceCompany _insuranceCompany;

        private string Name = "TestInsuranceCompany";

        internal override void SetBaseTestData()
        {
            base.SetBaseTestData();
            _insuranceCompany = new InsuranceCompany(_policyService, _policyRepository);

        }

        [Test]
        public void InsuranceCompanyServiceTest()
        {
            _insuranceCompany.Name = Name;
            _insuranceCompany.AvailableRisks = TestRisks;
        }
    }
}
