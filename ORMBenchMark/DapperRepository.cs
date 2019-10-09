using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ORMBenchMark.Models;
using Dapper;

namespace ORMBenchMark
{
  public  class DapperRepository
    {
        public string connectionString = @"Host=localhost;Port=5432;Username=postgres;Password=reladmin@123;Database=SampleDB";

        public List<Customer> GetUsersWithDapper()
        {
            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
                return db.Query<Customer>
                ($"Select * from Customer").ToList();
            }
        }

        public Customer GetCustomer_Dapper()
        {
            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
                return db.Query<Customer>
                ($"select * from customer where CustomerId=1").FirstOrDefault();
            }
        }

        public bool InsertCustomer_Dapper()
        {
            string sqlQuery = "INSERT INTO customer VALUES (@slno, @customerid, @firstname, @middlename,@lastname, @companyname, @salesperson, @emailaddress, @phone, @modifieddate)";

            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
                var maxId = db.Query<int> ($"select max(customerId) from customer").FirstOrDefault();
                var customers = new[]
           {
           new Customer() {slno= Convert.ToInt32(maxId+1),customerid= Convert.ToInt32(maxId+1),firstname =  "Brian Hoskins", middlename = "Brian",lastname = "Hoskins",companyname ="Sales2", salesperson = "New York",emailaddress=  "NY12@gmail.com",phone =  "9999999999",modifieddate= DateTime.Now },
           new Customer() {slno= Convert.ToInt32(maxId+2),customerid= Convert.ToInt32(maxId+2),firstname =  "Brian Hoskins", middlename = "Brian",lastname = "Hoskins",companyname ="Sales2", salesperson = "New York",emailaddress=  "NY12@gmail.com",phone =  "9999999999",modifieddate= DateTime.Now },
           new Customer() {slno= Convert.ToInt32(maxId+3),customerid= Convert.ToInt32(maxId+3),firstname =  "Brian Hoskins", middlename = "Brian",lastname = "Hoskins",companyname ="Sales2", salesperson = "New York",emailaddress=  "NY12@gmail.com",phone =  "9999999999",modifieddate= DateTime.Now },
           new Customer() {slno= Convert.ToInt32(maxId+4),customerid= Convert.ToInt32(maxId+4),firstname =  "Brian Hoskins", middlename = "Brian",lastname = "Hoskins",companyname ="Sales2", salesperson = "New York",emailaddress=  "NY12@gmail.com",phone =  "9999999999",modifieddate= DateTime.Now },
           new Customer() {slno= Convert.ToInt32(maxId+5),customerid= Convert.ToInt32(maxId+5),firstname =  "Brian Hoskins", middlename = "Brian",lastname = "Hoskins",companyname ="Sales2", salesperson = "New York",emailaddress=  "NY12@gmail.com",phone =  "9999999999",modifieddate= DateTime.Now },
           new Customer() {slno= Convert.ToInt32(maxId+6),customerid= Convert.ToInt32(maxId+6),firstname =  "Brian Hoskins", middlename = "Brian",lastname = "Hoskins",companyname ="Sales2", salesperson = "New York",emailaddress=  "NY12@gmail.com",phone =  "9999999999",modifieddate= DateTime.Now },
           new Customer() {slno= Convert.ToInt32(maxId+7),customerid= Convert.ToInt32(maxId+7),firstname =  "Brian Hoskins", middlename = "Brian",lastname = "Hoskins",companyname ="Sales2", salesperson = "New York",emailaddress=  "NY12@gmail.com",phone =  "9999999999",modifieddate= DateTime.Now },
           new Customer() {slno= Convert.ToInt32(maxId+8),customerid= Convert.ToInt32(maxId+8),firstname =  "Brian Hoskins", middlename = "Brian",lastname = "Hoskins",companyname ="Sales2", salesperson = "New York",emailaddress=  "NY12@gmail.com",phone =  "9999999999",modifieddate= DateTime.Now },
           new Customer() {slno= Convert.ToInt32(maxId+9),customerid= Convert.ToInt32(maxId+9),firstname =  "Brian Hoskins", middlename = "Brian",lastname = "Hoskins",companyname ="Sales2", salesperson = "New York",emailaddress=  "NY12@gmail.com",phone =  "9999999999",modifieddate= DateTime.Now },
           new Customer() {slno= Convert.ToInt32(maxId+10),customerid= Convert.ToInt32(maxId+10),firstname =  "Brian Hoskins", middlename = "Brian",lastname = "Hoskins",companyname ="Sales2", salesperson = "New York",emailaddress=  "NY12@gmail.com",phone =  "9999999999",modifieddate= DateTime.Now },
           new Customer() {slno= Convert.ToInt32(maxId+11),customerid= Convert.ToInt32(maxId+11),firstname =  "Brian Hoskins", middlename = "Brian",lastname = "Hoskins",companyname ="Sales2", salesperson = "New York",emailaddress=  "NY12@gmail.com",phone =  "9999999999",modifieddate= DateTime.Now },
           new Customer() {slno= Convert.ToInt32(maxId+12),customerid= Convert.ToInt32(maxId+12),firstname =  "Brian Hoskins", middlename = "Brian",lastname = "Hoskins",companyname ="Sales2", salesperson = "New York",emailaddress=  "NY12@gmail.com",phone =  "9999999999",modifieddate= DateTime.Now },
           new Customer() {slno= Convert.ToInt32(maxId+13),customerid= Convert.ToInt32(maxId+13),firstname =  "Brian Hoskins", middlename = "Brian",lastname = "Hoskins",companyname ="Sales2", salesperson = "New York",emailaddress=  "NY12@gmail.com",phone =  "9999999999",modifieddate= DateTime.Now },
           new Customer() {slno= Convert.ToInt32(maxId+14),customerid= Convert.ToInt32(maxId+14),firstname =  "Brian Hoskins", middlename = "Brian",lastname = "Hoskins",companyname ="Sales2", salesperson = "New York",emailaddress=  "NY12@gmail.com",phone =  "9999999999",modifieddate= DateTime.Now },
           new Customer() {slno= Convert.ToInt32(maxId+15),customerid= Convert.ToInt32(maxId+15),firstname =  "Brian Hoskins", middlename = "Brian",lastname = "Hoskins",companyname ="Sales2", salesperson = "New York",emailaddress=  "NY12@gmail.com",phone =  "9999999999",modifieddate= DateTime.Now },
                };
              return db.Execute(sqlQuery, customers) >=0;
            }
        }

        public bool UpdateCustomer_Dapper()
        {
            string val = "PrathibhaR";
            bool result = false;
            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
                for(int i = 20; i <= 35; i++)
                {
                     result =  db.Execute("update customer set firstname = @val where customerid = @id", new { val = val, id = i })>=0;
                }
                return result;
            }
        }

        public bool DeleteCustomer_Dapper()
        {
            var result = false;
            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
                var maxId = db.Query<int>("select max(customerid) from customer").FirstOrDefault();
                for (int i = maxId - 100; i <= maxId; i++)
                {
                    string deleteQuery = @"DELETE FROM Customer WHERE CustomerId = @Id";
                    result = db.Execute(deleteQuery, new { Id = i }) >= 0;
                }
                return result;
            }
        }
    }
}
