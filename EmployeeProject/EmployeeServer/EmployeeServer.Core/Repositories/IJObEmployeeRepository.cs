using EmployeeServer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Repositories
{
    public interface IJObEmployeeRepository
    {
        Task<IEnumerable<JobEmployee>> GetJobEmployeeAsync();

        Task<JobEmployee> GetJobEmployeeByIdAsync(int id);

        Task<JobEmployee> AddJobEmployeeAsync(JobEmployee jobEmployee);

        Task<JobEmployee> UpdateJobEmployeeAsync(int id, JobEmployee jobEmployee);

        Task DeleteJobEmployeeAsync(int id);
 
    }
}
