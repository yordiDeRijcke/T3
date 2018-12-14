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
                // Employee 1
                Employee EmployeeX = new Employee("Fictieve werknemer 1");

                // Employee 2
                Employee EmployeeY = new Employee("Fictieve werknemer 2");

                // Employee 3
                Employee EmployeeZ = new Employee("Fictieve werknemer 3");

                // Add the Employees to the DbSet
                _dbContext.Employees.Add(EmployeeX);
                _dbContext.Employees.Add(EmployeeY);
                _dbContext.Employees.Add(EmployeeZ);

                // Item 1
                Item ItemX = new Item("Fictieve titel 1", "Fictieve beschrijving 1.", 2, 1.20);

                // Item 2
                Item ItemY = new Item("Fictieve titel 2", null, 1, 2);

                // Item 3
                Item ItemZ = new Item("Fictieve titel 3", "Fictieve beschrijving 3.", 2, 2);

                // Add the Items to the DbSet
                _dbContext.Items.Add(ItemX);
                _dbContext.Items.Add(ItemY);
                _dbContext.Items.Add(ItemZ);

                // Bill 1
                Bill BillX = new Bill(
                    "Fictieve klant 1",
                    "Fictieve beschrijving 1");

                // Create the list of Items
                List<Item> ItemList = new List<Item>
                {
                    ItemX,
                    ItemY,
                    ItemZ
                };

                // Add the Items to the Bill
                BillX.Items = ItemList;

                // Create the BillEmployees needed for the mapping
                BillEmployee be1 = new BillEmployee();
                BillEmployee be2 = new BillEmployee();
                BillEmployee be3 = new BillEmployee();

                // Map BillEmployee 1
                be1.Bill = BillX;
                be1.Employee = EmployeeX;

                // Map BillEmployee 2
                be2.Bill = BillX;
                be2.Employee = EmployeeY;

                // Map BillEmployee 3
                be3.Bill = BillX;
                be3.Employee = EmployeeZ;

                // Linking the Employees to the Bill
                BillX.BillEmployees.Add(be1);
                BillX.BillEmployees.Add(be2);
                BillX.BillEmployees.Add(be3);

                // Bill 2
                Bill BillY = new Bill(
                    "Fictieve klant 2",
                    "Fictieve beschrijving 2");

                // Create the list of Items
                ItemList = new List<Item>
                {
                    ItemX,
                    ItemY
                };

                // Add the Items to the Bill
                BillY.Items = ItemList;

                // Create the BillEmployees needed for the mapping
                be1 = new BillEmployee();
                be2 = new BillEmployee();

                // Map BillEmployee 1
                be1.Bill = BillY;
                be1.Employee = EmployeeX;

                // Map BillEmployee 2
                be2.Bill = BillY;
                be2.Employee = EmployeeY;

                // Linking the Employees to the Bill
                BillY.BillEmployees.Add(be1);
                BillY.BillEmployees.Add(be2);

                // Bill 3
                Bill BillZ = new Bill(
                    "Fictieve klant 3",
                    null);

                // Create the list of Items
                ItemList = new List<Item>
                {
                    ItemY,
                    ItemZ
                };

                // Add the Items to the Bill
                BillZ.Items = ItemList;

                // Create the BillEmployees needed for the mapping
                be1 = new BillEmployee();
                be2 = new BillEmployee();

                // Map BillEmployee 1
                be1.Bill = BillZ;
                be1.Employee = EmployeeY;

                // Map BillEmployee 2
                be2.Bill = BillZ;
                be2.Employee = EmployeeZ;

                // Linking the Employees to the Bill
                BillZ.BillEmployees.Add(be1);
                BillZ.BillEmployees.Add(be2);

                // Bill 3
                Bill BillA = new Bill(
                    "Fictieve klant 4",
                    "Fictieve beschrijving 4");

                // Create the list of Items
                ItemList = new List<Item>
                {
                    ItemZ
                };

                // Add the Items to the Bill
                BillA.Items = ItemList;

                // Create the BillEmployees needed for the mapping
                be1 = new BillEmployee();

                // Map BillEmployee 1
                be1.Bill = BillA;
                be1.Employee = EmployeeY;

                // Linking the Employees to the Bill
                BillA.BillEmployees.Add(be1);

                // Add the Bills to the DbSet
                _dbContext.Bills.Add(BillX);
                _dbContext.Bills.Add(BillY);
                _dbContext.Bills.Add(BillZ);
                _dbContext.Bills.Add(BillA);

                // save all changes
                _dbContext.SaveChanges();
            }
        }
        #endregion
    }
}