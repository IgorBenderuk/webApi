using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.DTOS.Responces
{
    public class DriverResponse
    {
        public  Guid DriverId { get; set; }

        public string FullName { get; set; }= string.Empty;

        public int DriverNumber { get; set; }

        public DateTime DataOfBirth { get; set; }
    }
}
