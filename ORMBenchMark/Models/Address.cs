﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ORMBenchMark.Models
{
    public class Address
    {
        public int SlNo { get; set; }
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryRegion { get; set; }
        public string PostalCode { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
