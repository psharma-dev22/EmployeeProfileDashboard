using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspDotNetCore.EmployeeProfile.DAL.Entities;
using AspDotNetCore.EmployeeProfile.DTO.DTO;
using AutoMapper;

namespace AspDotNetCore.EmployeeProfile.BusinessLayer.Utilities
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserToReturnDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, EmployeeToAddDTO>().ReverseMap();
            CreateMap<Employee, EmployeeToUpdateDTO>().ReverseMap();
        }
    }
}
