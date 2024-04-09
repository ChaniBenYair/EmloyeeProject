using EmployeeServer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string IdEmployee { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime StartOfWorkDate { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsMale { get; set; }

        public bool IsActive { get; set; } = true;

        public List<JobEmployee> Job { get; set; }

    }
}
