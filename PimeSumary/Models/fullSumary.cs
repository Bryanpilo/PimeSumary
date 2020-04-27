using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PimeSumary.Models
{
    public class FullSumary
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string NameProduct { get; set; }

        public Nullable<decimal> UnitPrice { get; set; }

        public int IdBillingType { get; set; }

        public string Reference { get; set; }
    }
}