using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Features.Auth.Commands;
using Application.Features.Commands;
using Application.Features.Commands.EmployeeCommands;
using Application.Features.DepCommands;
using AutoMapper;    
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand, Product>();

            CreateMap<Department, DepartmentDto>().ReverseMap();

            CreateMap<CreateDepartmentCommand, Department>();

            CreateMap<RegisterCommand, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<CreateEmployeeCommand, EmployeeModel>();
            


        }
    }
}
