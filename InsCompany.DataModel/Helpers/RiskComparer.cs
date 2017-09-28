using System;
using System.Collections.Generic;
using InsCompany.DataAccess.Models;

namespace InsCompany.DataModel.Helpers
{
    public class RiskComparer : IEqualityComparer<Risk>
    {
        public bool Equals(Risk x, Risk y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.RiskId == y.RiskId && x.Name == y.Name && x.RiskId == y.RiskId;
        }

        public int GetHashCode(Risk risk)
        {
            if (Object.ReferenceEquals(risk, null)) return 0;

            int hashProductName = risk.Name == null ? 0 : risk.Name.GetHashCode();

            int hashProductCode = risk.YearlyPrice.GetHashCode();

            return hashProductName ^ hashProductCode;
        }
    }
}