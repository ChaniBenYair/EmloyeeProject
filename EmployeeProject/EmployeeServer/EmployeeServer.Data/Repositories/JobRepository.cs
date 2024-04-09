using EmployeeServer.Core.Models;
using EmployeeServer.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Data.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly DataContext _dataContext;

        public JobRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Job> AddJobAsync(Job job)
        {
            _dataContext.Add(job);
            await _dataContext.SaveChangesAsync();
            return job;        
        }

        public async Task DeleteJobAsync(int id)
        {
            var j = await GetJobByIdAsync(id);
            if (j != null)
            {
                _dataContext.Remove(j);
            }
            await _dataContext.SaveChangesAsync();
             
        }

        public async Task<Job> GetJobByIdAsync(int id)
        {
            return await _dataContext.Job.FirstAsync(j => j.Id == id);
        }

        public async Task<IEnumerable<Job>> GetJobsAsync()
        {
            return await _dataContext.Job.ToListAsync();
        }

        public async Task<Job> UpdateJobAsync(int id,Job job)
        {
            var jobId = await GetJobByIdAsync(id);
            if (jobId != null)
            {
                _dataContext.Entry(jobId).CurrentValues.SetValues(job);
            }
            await _dataContext.SaveChangesAsync();
            return job;
        }
    }
}
