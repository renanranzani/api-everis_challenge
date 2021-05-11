using Everteam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Interfaces
{
    public interface ICareerRepository
    {
        public List<Career> GetAllCareers();
        public Career GetCareerById(int careerId);
        public int InsertCareer(Career career);
        public void UpdateCareer(Career career);
        public void DeleteCareer(Career career);
    }
}
