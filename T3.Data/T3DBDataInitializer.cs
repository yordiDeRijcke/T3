using System;
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
                Item ItemY = new Item("45° G1/8 bocht", null, 2, 0);

                List<Item> ItemList = new List<Item>();
                ItemList.Add(ItemX);
                ItemList.Add(ItemY);

                Employee EmployeeX = new Employee("Pascal");
                Employee EmployeeY = new Employee("Philip");

                Bill BillX = new Bill(
                    "Yordi De Rijcke",
                    "Plaatsing van bochten voor in de oliekoelerleiding.");

                // Create the BillEmployees needed for the mapping
                BillEmployee be1 = new BillEmployee();
                BillEmployee be2 = new BillEmployee();

                // Map BillEmployee1
                be1.Bill = BillX;
                be1.Employee = EmployeeX;

                // Map BillEmployee2
                be2.Bill = BillX;
                be2.Employee = EmployeeY;

                // Linking the Employees to the Bill
                BillX.BillEmployees.Add(be1);
                BillX.BillEmployees.Add(be2);

                // Update the DbSets
                _dbContext.Items.Add(ItemX);
                _dbContext.Items.Add(ItemY);

                _dbContext.Employees.Add(EmployeeX);
                _dbContext.Employees.Add(EmployeeY);

                _dbContext.Bills.Add(BillX);
                BillX.Items = ItemList;
                _dbContext.SaveChanges();
            }
        }
        #endregion
    }
}