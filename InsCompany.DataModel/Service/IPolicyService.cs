using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsCompany.DataModel.Service
{
    public interface IPolicyService
    {
        void AddRiskToPolicy(int policyId, int riskId);

        void RemoveRiskFromPolicy(int policyId, int riskId);

    }
}