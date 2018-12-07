using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using T3.Core.Domain;
using T3.Core.Repositories;

namespace T3.Data.Repositories
{
    public class BillRepository : IBillRepository
    {
        #region Fields
        private readonly ApplicationDbContext _dbContext;
        #endregion

        #region Constructor
        public BillRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        public void Add(Bill bill)
        {
            _dbContext.Bills.Add(bill);
        }

        public List<Bill> GetAll()
        {
            return _dbContext.Bills.ToList();
        }

        public List<Bill> GetAllWithEI()
        {
            return _dbContext.Bills
                .Include(bill => bill.BillEmployees)
                .ThenInclude(billEmployees => billEmployees.Employee)
                .Include(bill => bill.Items)
                .ToList();
        }

        public Bill GetBy(int id)
        {
            return _dbContext.Bills.Find(id);
        }

        public void Remove(Bill bill)
        {
            _dbContext.Bills.Remove(bill);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}