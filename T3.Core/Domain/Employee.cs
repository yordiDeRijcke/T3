using System;

namespace T3.Core.Domain
{
    public class Employee
    {
        #region Fields
        private string _name;
        #endregion

        #region Properties
        public int Id { get; set; }

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentException("Employee name cannot be null!");
        }
        #endregion

        #region Constructor
        public Employee(string name)
        {
            Name = name;
        }
        #endregion
    }
}