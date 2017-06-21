using _01Data.Model;
using _03GenericRepository.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03GenericRepository.AutoMapper
{
    public class SeverityProfile : Profile
    {
        public SeverityProfile()
        {
            CreateMap<SeverityDTO, Severity>();
            CreateMap<Severity, SeverityDTO>();
        }
    }
}
