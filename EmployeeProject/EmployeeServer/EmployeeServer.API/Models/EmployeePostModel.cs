using EmployeeServer.Core.DTOs;
using EmployeeServer.Core.Models;

namespace EmployeeServer.API.Models
{
    public class EmployeePostModel
    {
        public string IdEmployee { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime StartOfWorkDate { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsMale { get; set; }

        public List<JobEmployeePostModel> Job { get; set; }
    }
}
