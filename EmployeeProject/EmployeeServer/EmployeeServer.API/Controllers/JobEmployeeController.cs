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
    public class JobEmployeeController : ControllerBase
    {

        private readonly IJObEmployeeService _jobEmployeeService;
        private readonly IMapper _mapper;

        public JobEmployeeController(IJObEmployeeService jobEmployeeService, IMapper mapper)
        {
            _jobEmployeeService = jobEmployeeService;
            _mapper = mapper;
        }


        // GET: api/<JobController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var j = await _jobEmployeeService.GetJobEmployeeAsync();
            var listDto = _mapper.Map<IEnumerable<JobEmployeeDto>>(j);
            return Ok(listDto);
        }

        // GET api/<JobController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var j = await _jobEmployeeService.GetJobEmployeeByIdAsync(id);
            var listDto = _mapper.Map<JobEmployeeDto>(j);
            return Ok(listDto);
        }

        // POST api/<JobController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] JobEmployeePostModel job)
        {
            var j = await _jobEmployeeService.AddJobEmployeeAsync(_mapper.Map<JobEmployee>(job));
            return Ok(_mapper.Map<JobEmployeeDto>(j));
            //var e = await _employeeService.GetEmployeeByIdAsync(id);
            //var employeeDto = _mapper.Map<employeeDto>(e);
            //return Ok(employeeDto);
        }

        // PUT api/<JobController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] JobEmployeePostModel job)
        {
            var j = await _jobEmployeeService.GetJobEmployeeByIdAsync(id);
            _mapper.Map(job,j);
            await _jobEmployeeService.UpdateJobEmployeeAsync(j.Id, j);
            return Ok(_mapper.Map<JobEmployeeDto>(j));
        }

        // DELETE api/<JobController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var j = await _jobEmployeeService.GetJobEmployeeByIdAsync(id);
            if (j is null)
                return NotFound();
            await _jobEmployeeService.DeleteJobEmployeeAsync(id);
            return NoContent();
        }
    }
}
