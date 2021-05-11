using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Models
{
    public class Career
    {
        public int CareerId { get; set; }
        public string CareerName { get; set; }
        public DateTime DateRegister { get; set; }
        public bool CareerStatus { get; set; }

    }
}
