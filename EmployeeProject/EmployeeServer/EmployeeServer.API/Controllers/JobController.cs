using AutoMapper;
using EmployeeServer.API.Models;
using EmployeeServer.Core.DTOs;
using EmployeeServer.Core.Models;
using EmployeeServer.Core.Services;
using EmployeeServer.Service.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
        public JobController(IJobService jobService, IMapper mapping)
        {
            _jobService = jobService;
            _mapper = mapping;
        }
        // GET: api/<JobController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var j = await _jobService.GetJobsAsync();
            var listDto = _mapper.Map<IEnumerable<JobDto>>(j);
            return Ok(listDto);
        }

        // GET api/<JobController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var e = await _jobService.GetJobByIdAsync(id);
            var jobDto = _mapper.Map<JobDto>(e);
            return Ok(jobDto);
        }

        // POST api/<JobController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] JobPostModel job)
        {
            var j = await _jobService.AddJobAsync(_mapper.Map<Job>(job));
            return Ok(_mapper.Map<JobDto>(j));
        }

        // PUT api/<JobController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] JobPostModel job)
        {
            var e = await _jobService.GetJobByIdAsync(id);
            _mapper.Map(job, e);
            await _jobService.UpdateJobAsync(e.Id, e);
            return Ok(_mapper.Map<JobDto>(e));
        }

        // DELETE api/<JobController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _jobService.DeleteJobAsync(id);
            return Ok();
        }
    }
}
