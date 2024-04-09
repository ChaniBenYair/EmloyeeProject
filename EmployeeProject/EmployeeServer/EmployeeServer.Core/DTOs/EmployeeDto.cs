using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string IdEmployee { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime StartOfWorkDate { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsMale { get; set; }

        public bool IsActive { get; set; }  

        public List<JobEmployeeDto> Job { get; set; }
    }
}
