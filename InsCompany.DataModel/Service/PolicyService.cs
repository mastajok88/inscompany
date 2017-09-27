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

        public void AddRiskToPolicy(int policyId, int riskId)
        {
            var policy = _policyRepository.Get(policyId);
            var risk = _riskRepository.Get(riskId);
            policy.InsuredRisks.Add(risk);
        }

        public void RemoveRiskFromPolicy(int policyId, int riskId)
        {
            var policy = _policyRepository.Get(policyId);
            var risk = _riskRepository.Get(riskId);
            policy.InsuredRisks.Remove(risk);
        }
    }
}