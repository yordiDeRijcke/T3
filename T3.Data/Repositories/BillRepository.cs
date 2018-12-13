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

        #region Methods
        public void Add(Bill bill)
        {
            _dbContext.Bills.Add(bill);
        }

        public List<Bill> GetAll()
        {
            return _dbContext.Bills.AsNoTracking().ToList();
        }

        public List<Bill> GetAllWithEmployees()
        {
            return _dbContext.Bills
                .Include(bill => bill.BillEmployees)
                .ThenInclude(BillEmployees => BillEmployees.Employee)
                .AsNoTracking()
                .ToList();
        }

        public List<Bill> GetAllWithEI()
        {
            return _dbContext.Bills
                .Include(bill => bill.BillEmployees)
                .ThenInclude(billEmployees => billEmployees.Employee)
                .Include(bill => bill.Items)
                .AsNoTracking()
                .ToList();
        }

        public Bill GetBy(int id)
        {
            return GetAllWithEI()
                .Find(bill => bill.Id == id);
        }

        public void Remove(Bill bill)
        {
            _dbContext.Bills.Remove(bill);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        #endregion
    }
}