using Everteam.Interfaces;
using Everteam.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IConfiguration _configuration;

        private readonly IRepositoryConnection _repositoryConnection;
        
        private readonly Dictionary<string, string> parameters = new Dictionary<string, string>();

        public ServiceRepository(IConfiguration configuration, IRepositoryConnection repositoryConnection)
        {
            _configuration = configuration;
            _repositoryConnection = repositoryConnection;
        }

        public List<Service> GetAllServices()
        {
            try
            {
                List<Service> listServices = new List<Service>();
                Service service = null;

                var read = _repositoryConnection.SearchCommand("GetAllServices", parameters);

                DataTable dateTable = JsonConvert.DeserializeObject<DataTable>(read);

                foreach (DataRow row in dateTable.Rows)
                {
                    service = new Service();

                    service.ServiceId = Convert.ToInt32(row["ServiceId"]);
                    service.ServiceName = row["ServiceName"].ToString();
                    service.DateRegister = Convert.ToDateTime(row["DateRegister"]);
                    service.ServiceStatus = Convert.ToBoolean(row["ServiceStatus"]);

                    listServices.Add(service);
                }
                return listServices;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Service GetServiceById(int serviceId)
        {
            try
            {
                Service service = null;

                parameters.Clear();
                parameters.Add("@ServiceId", serviceId.ToString());

                var read = _repositoryConnection.SearchCommand("GetServiceById", parameters);

                DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(read);

                foreach (DataRow row in dataTable.Rows)
                {
                    service = new Service();

                    service.ServiceId = Convert.ToInt32(row["ServiceId"]);
                    service.ServiceName = row["ServiceName"].ToString();
                    service.DateRegister = Convert.ToDateTime(row["DateRegister"]);
                    service.ServiceStatus = Convert.ToBoolean(row["ServiceStatus"]);
                }
                return service;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int InsertService(Service service)
        {
            try
            {
                parameters.Add("@ServiceName", service.ServiceName);
                parameters.Add("@DateRegister", service.DateRegister.ToString());
                parameters.Add("@ServiceStatus", service.ServiceStatus.ToString());

                int serviceId = _repositoryConnection.InsertCommand("InsertService", parameters);

                return serviceId;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateService(Service service)
        {
            try
            {
                parameters.Add("@ServiceName", service.ServiceName);
                parameters.Add("@DateRegister", service.DateRegister.ToString());
                parameters.Add("@ServiceStatus", service.ServiceStatus.ToString());
                parameters.Add("@ServiceId", service.ServiceId.ToString());

                _repositoryConnection.SimpleExecuteCommand("UpdateService", parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteService(Service service)
        {
            try
            {
                parameters.Add("@ServiceId", service.ServiceId.ToString());

                _repositoryConnection.SimpleExecuteCommand("DeleteService", parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
