using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public DateTime DateRegister { get; set; }
        public bool ServiceStatus { get; set; }

    }
}
