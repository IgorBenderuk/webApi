using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.DbSet
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = new Guid();

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdationDate { get; set; } = DateTime.UtcNow;

        public int Status { get; set; }


    }
}
