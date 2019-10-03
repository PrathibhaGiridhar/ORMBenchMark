using ORMBenchMark.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORMBenchMark
{
    public class EFRepository
    {
        public List<Customer> GetUsersWithEF()
        {
            using (var db = new EFCoreContext())
            {
                return db.Customers.FromSqlRaw("Select * from Customer").AsNoTracking().ToList();
            }
        }

        public Customer GetCustomer_EntityFramework()
        {
            using (var db = new EFCoreContext())
            {
                var id = 1;

                var aa = db.Customers.Where(x => x.CustomerId == id);
                return null;
            }
        }

        public bool InsertCustomer_EntityFramework()
        {
            using (var db = new EFCoreContext())
            {
                var cusObj = new Customer
                {
                    SlNo = 150000,
                    CustomerId = 150000,
                    FirstName = "Prathibha",
                    MiddleName = "KB",
                    LastName = "Raju",
                    CompanyName = "Relyon",
                    SalesPerson = "Sales1",
                    EmailAddress = "aaaa@gmail.com",
                    Phone = "1111111111",
                    ModifiedDate = DateTime.Now
                };
                db.Customers.Add(cusObj);
                var aaa = db.SaveChanges();
                return true;
            }
        }

        public bool UpdateCustomer_EntityFramework()
        {
            var id = 1;
            using (var db = new EFCoreContext())
            {
                var customer = db.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
                customer.LastName = "Andy";
                return db.SaveChanges() >= 0;
            }
        }

        public bool DeleteCustomer_EntityFramework()
        {
            var id = 3;
            using (var db = new EFCoreContext())
            {
                var customer = db.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
                db.Customers.Remove(customer);
                return db.SaveChanges() >= 0;
            }
        }

    }
}
