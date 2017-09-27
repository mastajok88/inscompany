using System;
using System.Collections.Generic;
using InsCompany.DataModel.InsuranceCompany.Interfaces;
using InsCompany.DataModel.Models;

namespace InsCompany.DataModel.InsuranceCompany
{
    sealed class InsuranceCompany : IInsuranceCompany, IInsuranceCompanyPolicy, IInsuranceCompanyRisk
    {

        private static readonly InsuranceCompany _instance = new InsuranceCompany();

        public InsuranceCompany()
        {
            
        }

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