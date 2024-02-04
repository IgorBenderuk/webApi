using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repos.Interfaces
{
    public interface IUnitOfWork
    {
        IDriverRepo Drivers {  get; }
        IAchivmentRepo Achivements { get; }

        Task<bool> CompleteAsync();
    }
}
