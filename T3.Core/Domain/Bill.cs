using System;
using System.Collections.Generic;

namespace T3.Core.Domain
{
    public class Bill
    {
        #region Fields
        private string _client;
        private IList<Item> _items;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Client
        {
            get => _client;
            set => _client = value ?? throw new ArgumentException("Client name cannot be empty!");
        }
        public string Info { get; set; }
        public IList<BillEmployee> BillEmployees { get; set; } = new List<BillEmployee>();

        public IList<Item> Items
        {
            get => _items;
            set => _items = value ?? throw new ArgumentException("Bill cannot be empty!");
        }
        #endregion

        #region Constructor
        public Bill(string client, string info)
        {
            Client = client;
            Info = info;
        }
        #endregion

        #region Methods
        public double getTotalPrice()
        {
            double total = 0;

            foreach (Item item in Items)
            {
                total += item.TotalPrice;
            }

            return total;
        }

        public void addItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentException("Item cannot be null!");
            }

            _items.Add(item);
        }

        public void removeItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentException("Item cannot be null!");
            }

            _items.Remove(item);
        }
        #endregion
    }
}