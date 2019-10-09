using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using ORMBenchMark.Models;

namespace ORMBenchMark
{
    public class EFCoreVsDapper
    {
        EFRepository _EFRepo;
        DapperRepository _DapperRepo;
        ADOAdapterRepository _ADOAdapterRepository;
        ADOReaderRepository _ADOReaderRepository;

        public EFCoreVsDapper()
        {
            _EFRepo = new EFRepository();
            _DapperRepo = new DapperRepository();
            _ADOAdapterRepository = new ADOAdapterRepository();
            _ADOReaderRepository = new ADOReaderRepository();
        }

        //[Benchmark]
        //public List<Customer> GetUsersWithEntityFramework()
        //{
        //    return _EFRepo.GetUsersWithEF();
        //}

        //[Benchmark]
        //public List<Customer> GetUsersWithDapper()
        //{
        //    return _DapperRepo.GetUsersWithDapper();
        //}

        //[Benchmark]
        //public Customer GetCustomer_EntityFramework()
        //{
        //    return _EFRepo.GetCustomer_EntityFramework();
        //}

        //[Benchmark]
        //public Customer GetCustomer_Dapper()
        //{
        //    return _DapperRepo.GetCustomer_Dapper();
        //}

        //[Benchmark]
        //public bool InsertCustomer_EntityFramework()
        //{
        //    return _EFRepo.InsertCustomer_EntityFramework();
        //}

        //[Benchmark]
        //public bool InsertCustomer_Dapper()
        //{
        //    return _DapperRepo.InsertCustomer_Dapper();
        //}

        //[Benchmark]
        //public bool UpdateCustomer_EntityFramework()
        //{
        //    return _EFRepo.UpdateCustomer_EntityFramework();
        //}

        //[Benchmark]
        //public bool UpdateCustomer_Dapper()
        //{
        //    return _DapperRepo.UpdateCustomer_Dapper();
        //}

        [Benchmark]
        public bool DeleteCustomer_Dapper()
        {
            return _DapperRepo.DeleteCustomer_Dapper();
        }

        [Benchmark]
        public bool DeleteCustomer_EntityFramework()
        {
            return _EFRepo.DeleteCustomer_EntityFramework();
        }

        //[Benchmark]
        //public List<Customer> GetUsersWithADOAdapter() => _ADOAdapterRepository.GetUsersWithADO();

        //[Benchmark]
        //public List<Customer> GetUsersWithADOReader() => _ADOReaderRepository.GetUsersWithADO();
    }
}
