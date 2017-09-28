using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using InsCompany.DataAccess.DataContext;
using InsCompany.DataAccess.Models;

namespace InsCompany.DataModel.Repository.PolicyRepository
{
    public class PolicyRepository : IPolicyRepository
    {
        private InsCompanyContext _db;

        public PolicyRepository(InsCompanyContext context)
        {
            _db = context;
        }
        public List<Policy> GetList()
        {
            return _db.Policies.ToList();
        }

        public Policy Get(int entityId)
        {
            return _db.Policies.Find(entityId);
        }

        public void Update(Policy[] entities)
        {
            _db.Policies.AddOrUpdate(entities);
            _db.SaveChanges();
        }

        public Policy Delete(int entityId)
        {
            Policy model = this.Get(entityId);
            Policy entity = _db.Policies.Remove(model);
            _db.SaveChanges();
            return entity;
        }

        public Policy RemoveRisk(int policyId, Risk risk)
        {

            Policy policy = _db.Policies.Find(policyId);
            if (policy != null)
            {
                policy.InsuredRisks.Remove(risk);
                _db.SaveChanges();
            }
            return policy;
        }

        public Policy AddRisk(int policyId, Risk risk)
        {
            Policy policy = _db.Policies.Find(policyId);
            if (policy != null)
            {
                policy.InsuredRisks.Add(risk);
                _db.SaveChanges();
            }
            return policy;
        }
    }
}