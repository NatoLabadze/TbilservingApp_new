using AutoMapper;
using Core.Application.Dtos.Statement;
using Core.Application.DTOs.UsersDTO;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.AutoMapperProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateUsersMapping();
            CreateMap<AddStatementDto, Statement>();
        }
       
        private void CreateUsersMapping()
        {
          
            CreateMap<UserDTO, User>();

        }
    }
}
