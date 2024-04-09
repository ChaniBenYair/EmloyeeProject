using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Models
{
    public class JobEmployee
    {
        [Key]
        public int Id { get; set; }
        public Job Job { get; set; }
        public int JobId { get; set; }
        public Employee Employee { get; set; }            
        public int EmployeeId { get; set; }
        public bool IsManagerialPosition { get; set; }

        public DateTime DateStartJob { get; set; }


        //public int EmloyeeId { get; set; }

        ////public List<Employee> Employee { get; set; }
    }
}
