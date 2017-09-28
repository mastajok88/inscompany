using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using InsCompany.DataAccess.DataContext;
using InsCompany.DataAccess.Models;

namespace InsCompany.DataModel.Repository.RiskRepository
{
    public class RiskRepository : IRiskRepository
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

        public Risk Get(int entityId)
        {
            return _db.Risks.Find(entityId);
        }

        public void Update(Risk[] entities)
        {
            _db.Risks.AddOrUpdate(entities);
            _db.SaveChanges();
        }

        public Risk Delete(int entityId)
        {
            var entity = this.Get(entityId);
            var model = _db.Risks.Remove(entity);
            _db.SaveChanges();
            return model;
        }
    }
}