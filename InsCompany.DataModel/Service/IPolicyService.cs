using InsCompany.DataAccess.Models;

namespace InsCompany.DataModel.Service
{
    public interface IPolicyService
    {
        Policy AddRiskToPolicy(int policyId, int riskId);

        Policy RemoveRiskFromPolicy(int policyId, int riskId);

    }
}