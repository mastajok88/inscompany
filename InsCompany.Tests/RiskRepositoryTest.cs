using InsCompany.DataModel.Models;
using InsCompany.DataModel.Repository;
using NUnit.Framework;

namespace InsCompany.Tests
{
    [TestFixture]
    public class RiskRepositoryTest : BaseTest
    {
        [Test]
        public void Add()
        {
            var riskOne = new Risk
            {
                Name = "Risk One",
                YearlyPrice = 100
            };

            RiskRepository riskRepository = new RiskRepository(_db);
            riskRepository.Add(riskOne);
            
            Assert.Pass("Your first passing test");
        }

    }
}
