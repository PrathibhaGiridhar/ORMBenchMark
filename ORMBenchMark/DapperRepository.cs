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
                var maxId = db.Query<int> ($"select max(CustomerId) from customer").FirstOrDefault(); 
                Customer c = new Customer() {
                   SlNo= Convert.ToInt32(maxId+1),
                    CustomerId= Convert.ToInt32(maxId+1),
                  FirstName =  "Brian Hoskins", 
                  MiddleName = "Brian", 
                  LastName = "Hoskins",
                  CompanyName ="Sales2",
                  SalesPerson = "New York", 
                  EmailAddress=  "NY12@gmail.com", 
                  Phone =  "9999999999", 
                  ModifiedDate= DateTime.Now };
              return db.Execute(sqlQuery, c) >=0;
            }
        }

        public bool UpdateCustomer_Dapper()
        {
            string val = "PrathibhaR";

            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
               return  db.Execute("update customer set firstname = @val where customerid = @id", new { val= val, id = 1 }) >=0;
            }
        }

        public bool DeleteCustomer_Dapper()
        {
            var val = 150001;
            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
                string deleteQuery = @"DELETE FROM Customer WHERE CustomerId = @Id";
                var result = db.Execute(deleteQuery, new { Id=val })>=0;
                return result;
            }
        }
    }
}
