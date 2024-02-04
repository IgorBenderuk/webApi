using FormulaOne.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repos.Interfaces
{
    public interface IAchivmentRepo : IGenericRepo<Achivment>
    {
        Task<IEnumerable<Achivment>?> GetDriverAchivmentsAasync(Guid driverId); 
    }
}
