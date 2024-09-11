using AutoMapper;
using LMS.Model.Models;
using LMS.Model.Models.Dto;

namespace LMS.Api
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
          
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}
