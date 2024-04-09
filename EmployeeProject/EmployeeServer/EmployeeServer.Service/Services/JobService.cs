using EmployeeServer.Core.Models;
using EmployeeServer.Core.Repositories;
using EmployeeServer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Service.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository) 
        {
            _jobRepository = jobRepository;
        }
        public async Task<Job> AddJobAsync(Job job)
        {
            return await _jobRepository.AddJobAsync(job);
        }

        public async Task DeleteJobAsync(int id)
        {
            await _jobRepository.DeleteJobAsync(id);
        }

        public async Task<Job> GetJobByIdAsync(int id)
        {
            return await _jobRepository.GetJobByIdAsync(id);
        }

        public async Task<IEnumerable<Job>> GetJobsAsync()
        {
            return await _jobRepository.GetJobsAsync();
        }

        public async Task<Job> UpdateJobAsync(int id, Job job)
        {
            return await _jobRepository.UpdateJobAsync(id,job);
        }
    }
}
