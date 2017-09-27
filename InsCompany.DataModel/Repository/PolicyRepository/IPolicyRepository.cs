using System.Collections.Generic;
using InsCompany.DataModel.Models;

namespace InsCompany.DataModel.Repository.PolicyRepository
{
    public interface IPolicyRepository
    {
        List<Policy> GetList();

        Policy Get(int policyId);

        void Add(Policy policy);

        void Edit(Policy policy);

        void Delete(int policyId);
    }
}
