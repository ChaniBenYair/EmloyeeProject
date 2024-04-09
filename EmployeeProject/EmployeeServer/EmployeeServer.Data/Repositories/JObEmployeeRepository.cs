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
    public class JObEmployeeRepository : IJObEmployeeRepository
    {
        private readonly DataContext _dataContext;

        public JObEmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<JobEmployee> AddJobEmployeeAsync(JobEmployee jobEmployee)
        {
            _dataContext.Add(jobEmployee);
            await _dataContext.SaveChangesAsync();
            return jobEmployee;
        }

        public async Task DeleteJobEmployeeAsync(int id)
        {
            var j = await GetJobEmployeeByIdAsync(id);
            if (j != null)
            {
                _dataContext.Remove(j);
            }
            await _dataContext.SaveChangesAsync();

        }

        public async Task<JobEmployee> GetJobEmployeeByIdAsync(int id)
        {
            return await _dataContext.JobEmployee.FirstAsync(j => j.Id == id);
        }

        public async Task<IEnumerable<JobEmployee>> GetJobEmployeeAsync()
        {
            return await _dataContext.JobEmployee.ToListAsync();
        }

        public async Task<JobEmployee> UpdateJobEmployeeAsync(int id, JobEmployee jobEmployee)
        {
            var jobId = await GetJobEmployeeByIdAsync(id);
            if (jobId != null)
            {
                _dataContext.Entry(jobId).CurrentValues.SetValues(jobEmployee);
            }
            await _dataContext.SaveChangesAsync();
            return jobEmployee;
        }
    }
   
}
