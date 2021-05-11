using Everteam.Interfaces;
using Everteam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Repository
{
    public class CareerRepository : ICareerRepository
    {
        private readonly IConfiguration _configuration;

        private readonly IRepositoryConnection _repositoryConnection;

        private readonly Dictionary<string, string> parameters = new Dictionary<string, string>();

        public CareerRepository(IConfiguration configuration, IRepositoryConnection repositoryConnection)
        {
            _configuration = configuration;
            _repositoryConnection = repositoryConnection;
        }

        public List<Career> GetAllCareers()
        {
            try
            {
                List<Career> listCareers = new List<Career>();
                Career career = null;

                var read = _repositoryConnection.SearchCommand("GetAllCareers", parameters);

                DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(read);

                foreach (DataRow row in dataTable.Rows)
                {
                    career = new Career();

                    career.CareerId = Convert.ToInt32(row["CareerId"]);
                    career.CareerName = row["CareerName"].ToString();
                    career.DateRegister = Convert.ToDateTime(row["DateRegister"]);
                    career.CareerStatus = Convert.ToBoolean(row["CareerStatus"]);

                    listCareers.Add(career);
                }
                return listCareers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Career GetCareerById(int idCareer)
        {   
            try
            {
                Career career = null;

                parameters.Clear();
                parameters.Add("@CareerId", idCareer.ToString());

                var read = _repositoryConnection.SearchCommand("GetCareerById", parameters);
                DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(read);

                foreach (DataRow row in dataTable.Rows)
                {
                    career = new Career();

                    career.CareerId = Convert.ToInt32(row["CareerId"]);
                    career.CareerName = row["CareerName"].ToString();
                    career.DateRegister = Convert.ToDateTime(row["DateRegister"]);
                    career.CareerStatus = Convert.ToBoolean(row["CareerStatus"]);
                }
                return career;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertCareer([FromBody] Career career)
        {
            try
            {
                parameters.Add("@CareerName", career.CareerName);
                parameters.Add("@DateRegister", career.DateRegister.ToString());
                parameters.Add("@CareerStatus", career.CareerStatus.ToString());

                int careerId = _repositoryConnection.InsertCommand("InsertCareer", parameters);

                return careerId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCareer(Career career)
        {
            try
            {
                parameters.Add("@CareerName", career.CareerName);
                parameters.Add("@DateRegister", career.DateRegister.ToString());
                parameters.Add("@CareerStatus", career.CareerStatus.ToString());
                parameters.Add("@CareerId", career.CareerId.ToString());

                _repositoryConnection.SimpleExecuteCommand("UpdateCareer", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCareer(Career career)
        {
            try
            {
                parameters.Add("@CareerId", career.CareerId.ToString());

                _repositoryConnection.SimpleExecuteCommand("DeleteCareer", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
