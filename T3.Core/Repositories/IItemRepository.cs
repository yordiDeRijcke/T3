using System.Collections.Generic;
using T3.Core.Domain;

namespace T3.Core.Repositories
{
    public interface IItemRepository
    {
        #region Methods
        Item GetBy(int id);
        List<Item> GetAll();
        void Add(Item item);
        void Remove(Item item);
        void SaveChanges();
        #endregion
    }
}
