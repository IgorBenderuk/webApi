using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.DTOS.Requests
{
    public class CreateDriverRequest
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastNAme { get; set; } = string.Empty;

        public int DriverNumber { get; set; }

        public DateTime DataOfBirth { get; set; }
    }
}
