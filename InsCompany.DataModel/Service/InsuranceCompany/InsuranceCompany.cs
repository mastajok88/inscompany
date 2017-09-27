using System;
using System.Collections.Generic;
using InsCompany.DataModel.Models;
using InsCompany.DataModel.Service.InsuranceCompany.Interfaces;

namespace InsCompany.DataModel.Service.InsuranceCompany
{
    public class InsuranceCompany : IInsuranceCompany, IInsuranceCompanyPolicy, IInsuranceCompanyRisk
    {
        public string Name { get; }
        public IList<Risk> AvailableRisks { get; set; }
       
        public void AddRisk(string nameOfInsuredObject, Risk risk, DateTime validFrom)
        {
            throw new NotImplementedException();
        }

        public void RemoveRisk(string nameOfInsuredObject, Risk risk, DateTime validTill)
        {
            throw new NotImplementedException();
        }
        
        public IPolicy SellPolicy(string nameOfInsuredObject, DateTime validFrom, short validMonths, IList<Risk> selectedRisks)
        {
            throw new NotImplementedException();
        }

        public IPolicy GetPolicy(string nameOfInsuredObject, DateTime effectiveDate)
        {
            throw new NotImplementedException();
        }
    }
}