using AutoMapper;
using EmployeeServer.API.Models;
using EmployeeServer.Core.Models;

namespace EmployeeServer.API.Mapping
{
    public class PostModelsMappingProfile : Profile
    {
        public PostModelsMappingProfile() 
        {
            CreateMap<EmployeePostModel, Employee>();
            CreateMap<JobEmployeePostModel, JobEmployee>();
            CreateMap<JobPostModel, Job>();
        }
    }
}
