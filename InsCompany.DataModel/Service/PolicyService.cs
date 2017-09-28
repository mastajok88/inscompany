using InsCompany.DataAccess.Models;
using InsCompany.DataModel.Repository.PolicyRepository;
using InsCompany.DataModel.Repository.RiskRepository;

namespace InsCompany.DataModel.Service
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository _policyRepository;

        private readonly IRiskRepository _riskRepository;

        public PolicyService(IPolicyRepository policyRepository, IRiskRepository riskRepository)
        {
            _policyRepository = policyRepository;
            _riskRepository = riskRepository;
        }

        public Policy AddRiskToPolicy(int policyId, int riskId)
        {

            var risk = _riskRepository.Get(riskId);
            return _policyRepository.AddRisk(policyId, risk);
        }

        public Policy RemoveRiskFromPolicy(int policyId, int riskId)
        {
            var risk = _riskRepository.Get(riskId);
            return _policyRepository.RemoveRisk(policyId, risk);
        }
    }
}