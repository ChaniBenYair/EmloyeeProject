using AutoMapper;
using EmployeeServer.Core.DTOs;
using EmployeeServer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<JobEmployee, JobEmployeeDto>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();

        }
    }
}
