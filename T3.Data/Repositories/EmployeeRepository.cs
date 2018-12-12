using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T3.Core.Domain;
using T3.Core.Repositories;

namespace T3.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Fields
        private readonly ApplicationDbContext _dbContext;
        #endregion

        #region Constructor
        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Methods
        public void Add(Employee employee)
        {
            _dbContext.Employees.Add(employee);
        }

        public List<Employee> GetAll()
        {
            return _dbContext.Employees.ToList();
        }

        public List<Employee> GetAllSorted()
        {
            return _dbContext.Employees.OrderBy(employee => employee.Name).ToList();
        }

        public Employee GetBy(int id)
        {
            return _dbContext.Employees.Find(id);
        }

        public void Remove(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        #endregion
    }
}