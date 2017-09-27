using System;
using System.Collections.Generic;
using System.Linq;
using InsCompany.DataModel.DataContext;
using InsCompany.DataModel.Models;

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

        public Policy Get(int policyId)
        {
            return _db.Policies.FirstOrDefault(x => x.PolicyId == policyId);
        }
    
        public void Add(Policy policy)
        {
            _db.Policies.Add(policy);
            _db.SaveChanges();
        }

        public void Edit(Policy risk)
        {
            throw new NotImplementedException();
        }

        public void Delete(int riskId)
        {
            throw new NotImplementedException();
        }
    }
}