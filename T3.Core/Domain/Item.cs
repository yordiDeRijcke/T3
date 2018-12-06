using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace T3.Core.Domain
{
    public class Item
    {
        #region Fields
        private string _name;
        private double _amount;
        private double _price;
        #endregion

        #region Properties
        public int ItemId { get; set; }

        [ForeignKey("Bill")]
        public int BillId { get; set; }

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentException("Item name cannot be null!");
        }

        public string Info { get; set; }

        public double Amount
        {
            get => _amount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Item amount must be greater than 0!");
                }

                _amount = value;
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }

                _price = value;
            }
        }

        public double TotalPrice => Price * Amount;
        #endregion

        #region Constructor
        public Item(string name, string info, double amount, double price)
        {
            Name = name;
            Info = info;
            Amount = amount;
            Price = price;
        }
        #endregion
    }
}