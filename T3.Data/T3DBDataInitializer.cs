﻿using System;
using System.Collections.Generic;
using T3.Core.Domain;

namespace T3.Data
{
    public class T3DBDataInitializer
    {
        #region Fields
        private readonly ApplicationDbContext _dbContext;
        #endregion

        #region Constructor
        public T3DBDataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Methods
        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();

            if (_dbContext.Database.EnsureCreated())
            {
                Item ItemX = new Item("90° G1/8 bocht", "kleur: zwart", 2, 1.20);
                _dbContext.Items.Add(ItemX);
                Item ItemY = new Item("45° G1/8 bocht", null, 2, 0);
                _dbContext.Items.Add(ItemY);

                Employee employeeX = new Employee("Pascal");
                _dbContext.Employees.Add(employeeX);
                Employee employeeY = new Employee("Philip");
                _dbContext.Employees.Add(employeeY);

                Bill BillX = new Bill(
                    "Rekening 1",
                    "Yordi De Rijcke",
                    "Plaatsing van bochten voor in de oliekoelerleiding.",
                    new List<Employee> { employeeX, employeeY },
                    new List<double> { 2, 1.5 },
                    new List<Item> { ItemX, ItemY });
                _dbContext.Bills.Add(BillX);
                _dbContext.SaveChanges();
            }
        }
        #endregion
    }
}