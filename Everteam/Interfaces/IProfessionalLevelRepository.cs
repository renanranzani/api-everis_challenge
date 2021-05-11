using Everteam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Interfaces
{
    public interface IProfessionalLevelRepository
    {
        public List<ProfessionalLevel> GetAllProfessionalLevels();
        public ProfessionalLevel GetProfessionalLevelById(int professionalLevelId);
        public int InsertProfessionalLevel(ProfessionalLevel professionalLevel);
        public void UpdateProfessionalLevel(ProfessionalLevel professionalLevel);
        public void DeleteProfessionalLevel(ProfessionalLevel professionalLevel);

    }
}
