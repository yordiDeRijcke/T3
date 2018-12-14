using System.Collections.Generic;
using T3.Core.Domain;

namespace T3.Core.Repositories
{
    public interface IEmployeeRepository
    {
        #region Methods
        Employee GetBy(int id);
        List<Employee> GetAll();
        List<Employee> GetAllSorted();
        void Add(Employee employee);
        void Remove(Employee employee);
        void SaveChanges();
        #endregion
    }
}
