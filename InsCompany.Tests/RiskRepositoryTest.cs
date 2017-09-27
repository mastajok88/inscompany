using System.Collections.Generic;
using InsCompany.DataModel.Models;
using InsCompany.DataModel.Repository.RiskRepository;
using NUnit.Framework;

namespace InsCompany.Tests
{
    [TestFixture]
    public class RiskRepositoryTest : BaseTest
    {
        public List<Risk> TestRisks { get; private set; }
       

        internal override void SetTestData()
        {
            base.SetTestData();

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
        }

        [Test]
        public void Add()
        {
            RiskRepository riskRepository = new RiskRepository(_db);
            TestRisks.ForEach(testRisk => { riskRepository.Add(testRisk); });
            var risks = riskRepository.GetList();
            Assert.AreEqual(3, risks.Count);
        }

    }
}
