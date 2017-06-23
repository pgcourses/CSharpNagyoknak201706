using _01Data.Model;
using _03GenericRepository.AutoMapper;
using _03GenericRepository.DTO;
using _03GenericRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10RepositoryPerformanceCounters
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo1 = new GenericRepository<Severity, SeverityDTO, SeverityProfile>();
            var repo2 = new GenericRepositoryWithUsing<Severity, SeverityDTO, SeverityProfile>();

            var dto1 = new SeverityDTO { Title = "teszt1" };

            Action work1 = () =>
            {
                while (true)
                {
                    //repo1.Add(dto1);
                    repo1.Find(1);
                }
            };

            var dto2 = new SeverityDTO { Title = "teszt2" };
            Action work2 = () =>
            {
                while (true)
                {
                    //repo2.Add(dto2);
                    repo2.Find(2);
                }
            };

            work1.BeginInvoke(null, null);
            work2.BeginInvoke(null, null);

            Console.ReadLine();
        }
    }
}
