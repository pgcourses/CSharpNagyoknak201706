using _01Data.Model;
using _03GenericRepository.AutoMapper;
using _03GenericRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03GenericRepository.Repository
{
    public class SeverityRepository : GenericRepository<Severity, SeverityDTO, SeverityProfile>
    {
    }
}
