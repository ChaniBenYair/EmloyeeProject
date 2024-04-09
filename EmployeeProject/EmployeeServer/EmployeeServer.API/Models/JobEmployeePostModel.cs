using EmployeeServer.Core.DTOs;
using EmployeeServer.Core.Models;

namespace EmployeeServer.API.Models
{
    public class JobEmployeePostModel
    {
        //public int Id { get; set; }
        //public Job Job { get; set; }
        public int JobId { get; set; }
        //public Employee Employee { get; set; }
        //public int EmployeeId { get; set; }
        public bool IsManagerialPosition { get; set; }

        public DateTime DateStartJob { get; set; }


    }
}
