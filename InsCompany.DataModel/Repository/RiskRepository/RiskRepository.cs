using System.Collections.Generic;
using System.Linq;
using InsCompany.DataModel.DataContext;
using InsCompany.DataModel.Models;

namespace InsCompany.DataModel.Repository.RiskRepository
{
    public class RiskRepository : Repository, IRiskRepository
    {
        private readonly InsCompanyContext _db;

        public RiskRepository(InsCompanyContext context)
        {
            _db = context;
        }
        public List<Risk> GetList()
        {
            return _db.Risks.ToList();
        }

        public Risk Get(int riskId)
        {
            return _db.Risks.FirstOrDefault(x => x.RiskId == riskId);
        }

        public void Add(Risk risk)
        {
            _db.Risks.Add(risk);
            _db.SaveChanges();
        }

        public void Edit(Risk updatedRisk)
        {
            Update(updatedRisk, risk => risk.Name, risk => risk.YearlyPrice);
        }

        public void Delete(int riskId)
        {
            var model = this.Get(riskId);
            _db.Risks.Remove(model);
            _db.SaveChanges();
        }
    }
}