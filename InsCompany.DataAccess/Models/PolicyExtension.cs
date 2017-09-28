using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace InsCompany.DataAccess.Models
{
    public partial class Policy : IPolicy
    {
        [NotMapped]
        public decimal Premium
        {
            get { return Convert.ToDecimal(InsuredRisks.Sum(x => x.YearlyPrice)); }
            set { }
        }
    }
}