using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Models
{
    public class ProfessionalLevel
    {
        public int ProfessionalLevelId { get; set; }
        public string ProfessionalLevelName { get; set; }
        public int ProfessionalLevelSection { get; set; }
        public DateTime DateRegister { get; set; }
        public bool ProfessionalLevelStatus { get; set; }

    }
}
