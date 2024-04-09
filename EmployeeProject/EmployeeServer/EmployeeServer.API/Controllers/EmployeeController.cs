using AutoMapper;
using EmployeeServer.API.Models;
using EmployeeServer.Core;
using EmployeeServer.Core.DTOs;
using EmployeeServer.Core.Models;
using EmployeeServer.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapping)
        {
            _employeeService = employeeService;
            _mapper = mapping;
        }


        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var e = await _employeeService.GetEmployeesAsync();
            var listDto = _mapper.Map<IEnumerable<EmployeeDto>>(e);
            return Ok(listDto);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var e = await _employeeService.GetEmployeeByIdAsync(id);
            var employeeDto = _mapper.Map<EmployeeDto>(e);
            return Ok(employeeDto);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeePostModel employee)
        {
            var e = await _employeeService.AddEmployeeAsync(_mapper.Map<Employee>(employee));
            return Ok(_mapper.Map<EmployeeDto>(e));
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeePostModel employee)
        {
            var e = await _employeeService.GetEmployeeByIdAsync(id);
            _mapper.Map(employee, e);
            await _employeeService.UpdateEmployeeAsync(e.Id,e);
            return Ok(_mapper.Map<EmployeeDto>(e));

        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }
    }
}
