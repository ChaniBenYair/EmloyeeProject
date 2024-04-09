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
    public class JObEmployeeService : IJObEmployeeService
    {
        private readonly IJObEmployeeRepository _repository;

        public JObEmployeeService(IJObEmployeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<JobEmployee> AddJobEmployeeAsync(JobEmployee jobEmployee)
        {
            return await _repository.AddJobEmployeeAsync(jobEmployee);
        }

        public async Task DeleteJobEmployeeAsync(int id)
        {
            await _repository.DeleteJobEmployeeAsync(id);
        }

        public async Task<JobEmployee> GetJobEmployeeByIdAsync(int id)
        {
            return await _repository.GetJobEmployeeByIdAsync(id);
        }

        public async Task<IEnumerable<JobEmployee>> GetJobEmployeeAsync()
        {
            return await _repository.GetJobEmployeeAsync();
        }

        public async Task<JobEmployee> UpdateJobEmployeeAsync(int id, JobEmployee jobEmployee)
        {
            return await _repository.UpdateJobEmployeeAsync(id, jobEmployee);
        }
    }
}
