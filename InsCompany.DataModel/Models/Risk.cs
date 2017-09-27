using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InsCompany.DataModel.Models
{
    public class Risk
    {
        [Key]
        public int RiskId { get; set; }

        [Index(IsUnique = true)]
        public string Name { get; set; }

        public double YearlyPrice { get; set; }



    }

}