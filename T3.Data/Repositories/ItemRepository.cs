using System;
using System.Collections.Generic;
using System.Linq;
using T3.Core.Domain;
using T3.Core.Repositories;

namespace T3.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        #region Fields
        private readonly ApplicationDbContext _dbContext;
        #endregion

        #region Constructor
        public ItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        public void Add(Item item)
        {
            _dbContext.Items.Add(item);
        }

        public List<Item> GetAll()
        {
            return _dbContext.Items.ToList();
        }

        public Item GetBy(int id)
        {
            return _dbContext.Items.Find(id);
        }

        public void Remove(Item item)
        {
            _dbContext.Items.Remove(item);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}