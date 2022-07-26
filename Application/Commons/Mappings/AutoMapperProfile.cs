
using AutoMapper;
using Core;
using Core.Dtos.Permission;
using Core.Dtos.Permission.UserRoles;
using Core.Dtos.Settings;
using Core.Dtos.UserLoginDto;
using Core.Dtos.UserLoginDto.UserRoles;
using Core.Entities;

namespace Application.Commons.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AspNetUser, UserForDetailsDto>();
            CreateMap<UserForDetailsDto, AspNetUser>();

            CreateMap<AspNetUser, UserForRegisterDto>();
            CreateMap<UserForRegisterDto, AspNetUser>();

            CreateMap<Agent, AgentDto>();
            CreateMap<AgentDto, Agent>();

        }
    }
}
