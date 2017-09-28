using System.Collections.Generic;
using InsCompany.DataAccess.Models;

namespace InsCompany.DataAccess.Repository.PolicyRepository
{
    public interface IPolicyRepository
    {
        List<Policy> GetList();

        Policy Get(int entityId);

        void Update(Policy[] entities);

        Policy Delete(int entityId);

        Policy RemoveRisk(int entityId, Risk risk);

        Policy AddRisk(int entityId, Risk risk);
    }
}
