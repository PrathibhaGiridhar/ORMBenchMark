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
  public  class ADOAdapterRepository
    {
        public List<Customer> GetUsersWithADO()
        {
            using (var conn = new NpgsqlConnection(@"Host=localhost;Port=5432;Username=postgres;Password=reladmin@123;Database=SampleDB;"))
            {
                var sql = "Select * from Customer";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        var resultTable = new DataTable();
                        adapter.Fill(resultTable);

                        return (from DataRow dr in resultTable.Rows
                                select new Customer()
                                {
                                    slno = Convert.ToInt32(dr["slno"]),
                                    customerid = Convert.ToInt32(dr["customerid"]),
                                    firstname = Convert.ToString(dr["firstname"]),
                                    middlename = Convert.ToString(dr["middlename"]),
                                    lastname = Convert.ToString(dr["lastname"]),
                                    companyname = Convert.ToString(dr["companyname"]),
                                    salesperson = Convert.ToString(dr["salesperson"]),
                                    emailaddress = Convert.ToString(dr["emailaddress"]),
                                    phone = Convert.ToString(dr["phone"]),
                                    modifieddate = Convert.ToDateTime(dr["modifieddate"])
                                }).ToList();
                    }
                }
            }
        }
    }
}
