using System;
using System.Collections.Generic;
using System.Text;

namespace ORMBenchMark.Models
{
   public class CustomerAddress
    {
        public int SlNo { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public string AddressType { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
