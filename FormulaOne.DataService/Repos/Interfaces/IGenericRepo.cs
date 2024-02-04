using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repos.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetALL();

        Task<T?> GetSingle(Guid Id);

        Task<bool> Create(T entity);

        Task<bool> UpDate(T entity);

        Task<bool> Remove(Guid Id);

    }
}
