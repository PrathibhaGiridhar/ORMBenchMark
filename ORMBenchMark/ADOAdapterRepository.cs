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
                                    SlNo = Convert.ToInt32(dr["SlNo"]),
                                    CustomerId = Convert.ToInt32(dr["CustomerId"]),
                                    FirstName = Convert.ToString(dr["FirstName"]),
                                    MiddleName = Convert.ToString(dr["MiddleName"]),
                                    LastName = Convert.ToString(dr["LastName"]),
                                    CompanyName = Convert.ToString(dr["CompanyName"]),
                                    SalesPerson = Convert.ToString(dr["SalesPerson"]),
                                    EmailAddress = Convert.ToString(dr["EmailAddress"]),
                                    Phone = Convert.ToString(dr["Phone"]),
                                    ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"])
                                }).ToList();
                    }
                }
            }
        }
    }
}
