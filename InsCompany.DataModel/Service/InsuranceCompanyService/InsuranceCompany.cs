using System;
using System.Collections.Generic;
using System.Linq;
using InsCompany.DataAccess.Models;
using InsCompany.DataAccess.Repository.PolicyRepository;
using InsCompany.DataModel.Helpers;
using InsCompany.DataModel.Service.InsuranceCompanyService.Interfaces;
using InsCompany.DataModel.Service.PolicyService;

namespace InsCompany.DataModel.Service.InsuranceCompanyService
{

    // That can be done also using Singlton 
    public sealed class InsuranceCompany : IInsuranceCompany, IInsuranceCompanyPolicy, IInsuranceCompanyRisk
    {

        private IPolicyService _policyService;
        private IPolicyRepository _policyRepository;

        public InsuranceCompany(IPolicyService policyService, IPolicyRepository policyRepository)
        {
            _policyService = policyService;
            _policyRepository = policyRepository;
        }

        public string Name { get; set; }

        public IList<Risk> AvailableRisks { get; set; }

        public void AddRisk(string nameOfInsuredObject, Risk risk, DateTime validFrom)
        {
            Policy policy = _policyRepository.GetList()
                .FirstOrDefault(p => p.NameOfInsuredObject == nameOfInsuredObject &&
                                     (DateTime.Compare(p.ValidFrom, validFrom) == 0 ||
                                      DateTime.Compare(p.ValidFrom, validFrom) < 0));
            if (policy != null)
            {
                _policyService.AddRiskToPolicy(policy.PolicyId, risk.RiskId);
            }
        }

        public void RemoveRisk(string nameOfInsuredObject, Risk risk, DateTime validTill)
        {
            Policy policy = _policyRepository.GetList()
                .FirstOrDefault(p => p.NameOfInsuredObject == nameOfInsuredObject &&
                                     (DateTime.Compare(p.ValidTill, validTill) == 0 ||
                                      DateTime.Compare(p.ValidTill, validTill) > 0));
            if (policy != null)
            {
                _policyService.RemoveRiskFromPolicy(policy.PolicyId, risk.RiskId);
            }
        }

        public IPolicy SellPolicy(string nameOfInsuredObject, DateTime validFrom, short validMonths, IList<Risk> selectedRisks)
        {
            return _policyRepository.GetList()
                .FirstOrDefault(p => p.NameOfInsuredObject == nameOfInsuredObject &&
                            (DateTime.Compare(p.ValidFrom, validFrom) == 0 || DateTime.Compare(p.ValidFrom, validFrom) < 0) 
                             && p.InsuredRisks.Except(selectedRisks, new RiskComparer()).ToList().Count == selectedRisks.Count
                             && validMonths >= (p.ValidTill.Month - p.ValidFrom.Month));

        }

        public IPolicy GetPolicy(string nameOfInsuredObject, DateTime effectiveDate)
        {
            return _policyRepository.GetList()
                .FirstOrDefault(policy => policy.NameOfInsuredObject == nameOfInsuredObject
                                          && DateTime.Compare(effectiveDate, policy.ValidFrom) > 0
                                          && DateTime.Compare(effectiveDate, policy.ValidTill) < 0);
        }



    }
}