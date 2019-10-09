using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMBenchMark.Models
{
    [Table("customer")]
   public  class Customer
    {
        public int slno { get; set; }
        public int customerid { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string companyname { get; set; }
        public string salesperson { get; set; }
        public string emailaddress { get; set; }
        public string phone { get; set; }
        public DateTime modifieddate { get; set; }
    }
}
