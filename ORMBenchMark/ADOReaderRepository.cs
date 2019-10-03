using ORMBenchMark.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ORMBenchMark
{
  public  class ADOReaderRepository
    {
        public List<Customer> GetUsersWithADO()
        {
            using (var conn = new NpgsqlConnection(@"Host=localhost;Port=5432;Username=postgres;Password=reladmin@123;Database=SampleDB;"))
            {
                List<Customer> customerList = new List<Customer>();
                try {
                    var sql = "Select * from Customer";
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customerList.Add(new Customer()
                                {
                                    SlNo = Convert.ToInt32(reader["SlNo"]),
                                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                    FirstName = Convert.ToString(reader["FirstName"]),
                                    MiddleName = Convert.ToString(reader["MiddleName"]),
                                    LastName = Convert.ToString(reader["LastName"]),
                                    CompanyName = Convert.ToString(reader["CompanyName"]),
                                    SalesPerson = Convert.ToString(reader["SalesPerson"]),
                                    EmailAddress = Convert.ToString(reader["EmailAddress"]),
                                    Phone = Convert.ToString(reader["Phone"]),
                                    ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"])
                                });
                            }
                            conn.Close();
                            return customerList;
                        }
                    }
                }
                catch (Exception exp)
                {
                    
                    return null;
                }
            }
        }
    }
}
