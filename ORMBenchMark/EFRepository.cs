using ORMBenchMark.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ORMBenchMark
{
    public class EFRepository
    {
        public List<Customer> GetUsersWithEF()
        {
            using (var db = new EFCoreContext())
            {
                return db.customers.FromSqlRaw("Select * from Customer").ToList();
            }
        }

        public Customer GetCustomer_EntityFramework()
        {
            using (var db = new EFCoreContext())
            {
                var id = 1;

                var aa = db.customers.Where(x => x.customerid == id);
                return null;
            }
        }

        public bool InsertCustomer_EntityFramework()
        {
            using (var db = new EFCoreContext())
            {
                var id = db.customers.Max(x => x.customerid);
                var customers = new[]
           {
                    new Customer { slno = id+1,customerid = id+1,firstname = "Prathibha1", middlename = "KB",lastname = "Raju",companyname = "Relyon", salesperson = "Sales1",emailaddress = "aaaa@gmail.com",phone = "1111111111", modifieddate = DateTime.Now },
                    new Customer { slno = id+2,customerid = id+2,firstname = "Prathibha2", middlename = "KB",lastname = "Raju",companyname = "Relyon", salesperson = "Sales1",emailaddress = "aaaa@gmail.com",phone = "1111111111", modifieddate = DateTime.Now },
                    new Customer { slno = id+3,customerid = id+3,firstname = "Prathibha3", middlename = "KB",lastname = "Raju",companyname = "Relyon", salesperson = "Sales1",emailaddress = "aaaa@gmail.com",phone = "1111111111", modifieddate = DateTime.Now },
                    new Customer { slno = id+4,customerid = id+4,firstname = "Prathibha4", middlename = "KB",lastname = "Raju",companyname = "Relyon", salesperson = "Sales1",emailaddress = "aaaa@gmail.com",phone = "1111111111", modifieddate = DateTime.Now },
                    new Customer { slno = id+5,customerid = id+5,firstname = "Prathibha5", middlename = "KB",lastname = "Raju",companyname = "Relyon", salesperson = "Sales1",emailaddress = "aaaa@gmail.com",phone = "1111111111", modifieddate = DateTime.Now },
                    new Customer { slno = id+6,customerid = id+6,firstname = "Prathibha6", middlename = "KB",lastname = "Raju",companyname = "Relyon", salesperson = "Sales1",emailaddress = "aaaa@gmail.com",phone = "1111111111", modifieddate = DateTime.Now },
                    new Customer { slno = id+7,customerid = id+7,firstname = "Prathibha7", middlename = "KB",lastname = "Raju",companyname = "Relyon", salesperson = "Sales1",emailaddress = "aaaa@gmail.com",phone = "1111111111", modifieddate = DateTime.Now },
                    new Customer { slno = id+8,customerid = id+8,firstname = "Prathibha8", middlename = "KB",lastname = "Raju",companyname = "Relyon", salesperson = "Sales1",emailaddress = "aaaa@gmail.com",phone = "1111111111", modifieddate = DateTime.Now },
                    new Customer { slno = id+9,customerid = id+9,firstname = "Prathibha9", middlename = "KB",lastname = "Raju",companyname = "Relyon", salesperson = "Sales1",emailaddress = "aaaa@gmail.com",phone = "1111111111", modifieddate = DateTime.Now },
                    new Customer { slno = id+10,customerid = id+10,firstname = "Prathibha10", middlename = "KB",lastname = "Raju",companyname = "Relyon", salesperson = "Sales1",emailaddress = "aaaa@gmail.com",phone = "1111111111", modifieddate = DateTime.Now },
                    new Customer { slno = id+11,customerid = id+11,firstname = "Prathibha11", middlename = "KB",lastname = "Raju",companyname = "Relyon", salesperson = "Sales1",emailaddress = "aaaa@gmail.com",phone = "1111111111", modifieddate = DateTime.Now },
                    new Customer { slno = id+12,customerid = id+12,firstname = "Prathibha12", middlename = "KB",lastname = "Raju",companyname = "Relyon", salesperson = "Sales1",emailaddress = "aaaa@gmail.com",phone = "1111111111", modifieddate = DateTime.Now },
                    new Customer { slno = id+13,customerid = id+13,firstname = "Prathibha13", middlename = "KB",lastname = "Raju",companyname = "Relyon", salesperson = "Sales1",emailaddress = "aaaa@gmail.com",phone = "1111111111", modifieddate = DateTime.Now },
                    new Customer { slno = id+14,customerid = id+14,firstname = "Prathibha14", middlename = "KB",lastname = "Raju",companyname = "Relyon", salesperson = "Sales1",emailaddress = "aaaa@gmail.com",phone = "1111111111", modifieddate = DateTime.Now },
                    new Customer { slno = id+15,customerid = id+15,firstname = "Prathibha15", middlename = "KB",lastname = "Raju",companyname = "Relyon", salesperson = "Sales1",emailaddress = "aaaa@gmail.com",phone = "1111111111", modifieddate = DateTime.Now },
            };
                db.customers.AddRange(customers);
               return db.SaveChanges()>=0;
            }
        }

        public bool UpdateCustomer_EntityFramework()
        {
            using (var db = new EFCoreContext())
            {
                for (int id = 40; id <= 55; id++)
                {
                    var customer = db.customers.Where(x => x.customerid == id).FirstOrDefault();
                    customer.lastname = "Andy";
                }
                return db.SaveChanges() >= 0;
            }
        }

        public bool DeleteCustomer_EntityFramework()
        {
            using (var db = new EFCoreContext())
            {
                var maxId = db.customers.Max(x => x.customerid);
                for (int id = maxId-100; id <= maxId; id++)
                {
                    var customer = db.customers.Where(x => x.customerid == id).FirstOrDefault();
                    db.customers.Remove(customer);
                }
                return db.SaveChanges() >= 0;
            }
        }

    }
}
