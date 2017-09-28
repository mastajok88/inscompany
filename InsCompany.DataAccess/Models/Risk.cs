using System.ComponentModel.DataAnnotations;

namespace InsCompany.DataAccess.Models
{
    public class Risk
    {
        [Key]
        public int RiskId { get; set; }

        public string Name { get; set; }

        public double YearlyPrice { get; set; }

    }

}