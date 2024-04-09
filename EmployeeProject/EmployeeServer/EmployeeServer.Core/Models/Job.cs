using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Models
{
    
    public class Job
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<JobEmployee> JobEmployees { get; set; }
    }
}
