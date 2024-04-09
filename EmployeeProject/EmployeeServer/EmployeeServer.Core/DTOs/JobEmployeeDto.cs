using EmployeeServer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.DTOs
{
    public class JobEmployeeDto
    {
        public int Id { get; set; }
        //public Job Job { get; set; }
        public int JobId { get; set; }
        //public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public bool IsManagerialPosition { get; set; }

        public DateTime DateStartJob { get; set; }


    }
}

