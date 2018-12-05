using System;
using System.Collections.Generic;

namespace T3.Core.Domain
{
    public class Bill
    {
        #region Fields
        private string _name;
        private string _client;
        private List<Employee> _employees;
        private List<double> _labourHours;
        private List<Item> _items;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentException("Bill name cannot be null!");
        }
        public string Client
        {
            get => _client;
            set => _client = value ?? throw new ArgumentException("Client name cannot be empty!");
        }
        public string Info { get; set; }
        public List<Employee> Employees
        {
            get => _employees;
            private set => _employees = value ?? throw new ArgumentException("Employee cannot be empty!");
        }
        public List<double> LabourHours
        {
            get => _labourHours;
            private set => _labourHours = value ?? throw new ArgumentException("Hours of labour cannot be empty!");
        }
        public List<Item> Items
        {
            get => _items;
            private set => _items = value ?? throw new ArgumentException("Bill cannot be empty!");
        }
        #endregion

        #region Constructor
        public Bill(string name, string client, string info, List<Employee> employees, List<double> labourHours, List<Item> items)
        {
            Name = name;
            Client = client;
            Info = info;
            Employees = employees;
            LabourHours = labourHours;
            Items = items;
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

        public void addEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException("Employee cannot be null!");
            }

            _employees.Add(employee);
        }

        public void removeEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException("Employee cannot be null!");
            }

            _employees.Remove(employee);
        }

        public void changeLabourHours(Employee employee, double labourHours)
        {
            if (labourHours < 0)
            {
                throw new ArgumentException("labourHours must be greater than 0!");
            }

            int employeeIndex = _employees.FindIndex(e => e.Id == employee.Id);
            _labourHours[employeeIndex] = labourHours;
        }
        #endregion
    }
}