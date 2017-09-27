using System;
using System.Collections.Generic;
using InsCompany.DataModel.Models;

namespace InsCompany.DataModel.Service.InsuranceCompany.Interfaces
{
    internal interface IInsuranceCompanyRisk
    {
        /// <summary> 
        /// List of the risks that can be insured. List can be updated at any time 
        /// </summary> 

        IList<Risk> AvailableRisks { get; set; }
        
        /// <summary> 
        /// Add risk to the policy of insured object 
        /// </summary> 
        /// <param name="nameOfInsuredObject">Name of insured object</param> 
        /// <param name="risk">Risk tham must be added</param> 
        /// <param name="validFrom">Date when risk becomes active. Can not be in the past</param> 

        void AddRisk(string nameOfInsuredObject, Risk risk, DateTime validFrom);

        /// <summary> 
        /// Remove risk from the policy of insured object 
        /// </summary> 
        /// <param name="nameOfInsuredObject">Name of insured object</param> 
        /// <param name="risk">Risk tham must be removed</param> 
        /// <param name="validTill">Date when risk become inactive. Must be equal to or greater than date when risk become active</param> 
        void RemoveRisk(string nameOfInsuredObject, Risk risk, DateTime validTill);
    }
}