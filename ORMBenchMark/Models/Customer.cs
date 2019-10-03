using System;
using System.Collections.Generic;
using System.Text;

namespace ORMBenchMark.Models
{
   public  class Customer
    {
        public int SlNo { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string SalesPerson { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
