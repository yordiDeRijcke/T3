using System;
using System.Collections.Generic;
using T3.Core.Domain;

namespace T3.Core.Repositories
{
    public interface IBillRepository
    {
        #region Methods
        Bill GetBy(int id);
        List<Bill> GetAll();
        List<Bill> GetAllWithEI();
        void Add(Bill bill);
        void Remove(Bill bill);
        void SaveChanges();
        #endregion
    }
}
