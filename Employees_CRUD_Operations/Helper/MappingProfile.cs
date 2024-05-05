using AutoMapper;
using Employee_CRUD_Operations.DAL.Models;
using Employees_CRUD_Operations.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_CRUD_Operations.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            
            CreateMap<Employees , EmployeeModelView>().ReverseMap();
        }
    }
}
