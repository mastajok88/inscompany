using System;
using System.Collections.Generic;
using InsCompany.DataAccess.Models;

namespace InsCompany.DataModel.InsuranceCompany.Interfaces
{
    public interface IInsuranceCompanyPolicy
    {
        /// <summary> 
        /// Sell the policy. 
        /// </summary> 
        /// <param name="nameOfInsuredObject">
        /// Name of the insured object. Must be unique in the given period.</param> 
        /// <param name="validFrom">Date and time when policy starts. Can not be in the past</param> 
        /// <param name="validMonthes">Policy period in months</param> 
        /// <param name="selectedRisks">List of risks that must be included in the policy</param> 
        /// <returns>Information about policy</returns>

        IPolicy SellPolicy(string nameOfInsuredObject, DateTime validFrom, short validMonths, IList<Risk> selectedRisks);

        /// <summary> 
        /// Get policy state at the given moment of time. 
        /// </summary> 
        /// <param name="nameOfInsuredObject">Name of insured object</param> 
        /// <param name="effectiveDate">Moment of date and time</param> 
        /// <returns></returns> 
        IPolicy GetPolicy(string nameOfInsuredObject, DateTime effectiveDate);
    }

}
