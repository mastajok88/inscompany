using System.Linq;
using InsCompany.DataModel.Repository.RiskRepository;
using NUnit.Framework;

namespace InsCompany.Tests
{
    [TestFixture]
    public class RiskRepositoryTest : BaseTest
    {
        private RiskRepository _riskRepository;

        internal override void SetBaseTestData()
        {
            base.SetBaseTestData();

            _riskRepository = new RiskRepository(_db);
            _riskRepository.Update(TestRisks.ToArray());
        }

        [Test]
        public void AddAndGet()
        {
            var risks = _riskRepository.GetList();
            Assert.AreEqual(3, risks.Count);
        }

        [Test]
        public void Delete()
        {
            var risks = _riskRepository.GetList();
            var originalRisksCount = risks.Count;
            var riskToDelete = risks.First();
            _riskRepository.Delete(riskToDelete.RiskId);
            var modifiedRisks = _riskRepository.GetList();
            Assert.AreEqual(originalRisksCount - 1, modifiedRisks.Count);
        }

        [Test]
        public void Update()
        {
            var risks = _riskRepository.GetList();
            for (int i = 0; i < risks.Count; i++)
            {
                risks[i].Name = $"Risk {i}";
                risks[i].YearlyPrice = risks[i].YearlyPrice * 2;
            }
            _riskRepository.Update(risks.ToArray());

            var modifiedRisks = _riskRepository.GetList();
            Assert.AreNotEqual(risks, modifiedRisks);

        }

    }
}
