using EmployeeServer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Services
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetJobsAsync();

        Task<Job> GetJobByIdAsync(int id);

        Task<Job> AddJobAsync(Job job);

        Task<Job> UpdateJobAsync(int id, Job job);

        Task DeleteJobAsync(int id);
    }
}
