using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.DbSet
{
    public class Driver : BaseEntity
    {
        public Driver()
        {
            Achivments = new HashSet<Achivment>();            
        }
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int DriverNumber { get; set; }

        public DateTime DataOfBirth { get; set; }

        public virtual ICollection<Achivment> Achivments { get; set; }


    }
}
