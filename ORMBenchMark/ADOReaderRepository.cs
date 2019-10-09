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
                                    slno = Convert.ToInt32(reader["slno"]),
                                    customerid = Convert.ToInt32(reader["customerid"]),
                                    firstname = Convert.ToString(reader["firstname"]),
                                    middlename = Convert.ToString(reader["middlename"]),
                                    lastname = Convert.ToString(reader["lastname"]),
                                    companyname = Convert.ToString(reader["companyname"]),
                                    salesperson = Convert.ToString(reader["salesperson"]),
                                    emailaddress = Convert.ToString(reader["emailaddress"]),
                                    phone = Convert.ToString(reader["phone"]),
                                    modifieddate = Convert.ToDateTime(reader["modifieddate"])
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
