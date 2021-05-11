using Everteam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Interfaces
{
    public interface IServiceRepository
    {
        public List<Service> GetAllServices();
        public Service GetServiceById(int serviceId);
        public int InsertService(Service service);
        public void UpdateService(Service service);
        public void DeleteService(Service service);

    }
}
