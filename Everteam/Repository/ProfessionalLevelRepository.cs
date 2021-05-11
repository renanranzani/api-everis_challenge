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
    public class ProfessionalLevelRepository : IProfessionalLevelRepository
    {
        private readonly IConfiguration _configuration;

        private readonly IRepositoryConnection _repositoryConnection;

        private readonly Dictionary<string, string> parameters = new Dictionary<string, string>();

        public ProfessionalLevelRepository(IConfiguration configuration, IRepositoryConnection repositoryConnection)
        {
            _configuration = configuration;
            _repositoryConnection = repositoryConnection;
        }

        public List<ProfessionalLevel> GetAllProfessionalLevels()
        {
            try
            {
                List<ProfessionalLevel> listProfessionalLevels = new List<ProfessionalLevel>();
                ProfessionalLevel professionalLevel = null;

                var read = _repositoryConnection.SearchCommand("GetAllProfessionalLevels", parameters);

                DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(read);

                foreach(DataRow row in dataTable.Rows)
                {
                    professionalLevel = new ProfessionalLevel();

                    professionalLevel.ProfessionalLevelId = Convert.ToInt32(row["ProfessionalLevelId"]);
                    professionalLevel.ProfessionalLevelName = row["ProfessionalLevelName"].ToString();
                    professionalLevel.ProfessionalLevelSection = Convert.ToInt32(row["ProfessionalLevelSection"]);
                    professionalLevel.DateRegister = Convert.ToDateTime(row["DateRegister"]);
                    professionalLevel.ProfessionalLevelStatus = Convert.ToBoolean(row["ProfessionalLevelStatus"]);

                    listProfessionalLevels.Add(professionalLevel);
                }
                return listProfessionalLevels;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ProfessionalLevel GetProfessionalLevelById(int professionalLevelId)
        {
            try
            {
                ProfessionalLevel professionalLevel = null;

                parameters.Clear();
                parameters.Add("@ProfessionalLevelId", professionalLevelId.ToString());

                var read = _repositoryConnection.SearchCommand("GetProfessionalLevelById", parameters);

                DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(read);

                foreach (DataRow row in dataTable.Rows)
                {
                    professionalLevel = new ProfessionalLevel();

                    professionalLevel.ProfessionalLevelId = Convert.ToInt32(row["ProfessionalLevelId"]);
                    professionalLevel.ProfessionalLevelName = row["ProfessionalLevelName"].ToString();
                    professionalLevel.ProfessionalLevelSection = Convert.ToInt32(row["ProfessionalLevelSection"]);
                    professionalLevel.DateRegister = Convert.ToDateTime(row["DateRegister"]);
                    professionalLevel.ProfessionalLevelStatus = Convert.ToBoolean(row["ProfessionalLevelStatus"]);
                }
                return professionalLevel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertProfessionalLevel(ProfessionalLevel professionalLevel)
        {
            try
            {
                parameters.Add("@ProfessionalLevelName", professionalLevel.ProfessionalLevelName);
                parameters.Add("@ProfessionalLevelSection", professionalLevel.ProfessionalLevelSection.ToString());
                parameters.Add("@DateRegister", professionalLevel.DateRegister.ToString());
                parameters.Add("@ProfessionalLevelStatus", professionalLevel.ProfessionalLevelStatus.ToString());

                int professionalLevelId = _repositoryConnection.InsertCommand("InsertProfessionalLevel", parameters);

                return professionalLevelId;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateProfessionalLevel(ProfessionalLevel professionalLevel)
        {
            try
            {
                parameters.Add("@ProfessionalLevelName", professionalLevel.ProfessionalLevelName);
                parameters.Add("@ProfessionalLevelSection", professionalLevel.ProfessionalLevelSection.ToString());
                parameters.Add("@DateRegister", professionalLevel.DateRegister.ToString());
                parameters.Add("@ProfessionalLevelStatus", professionalLevel.ProfessionalLevelStatus.ToString());
                parameters.Add("@ProfessionalLevelId", professionalLevel.ProfessionalLevelId.ToString());

                _repositoryConnection.SimpleExecuteCommand("UpdateProfessionalLevel", parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteProfessionalLevel(ProfessionalLevel professionalLevel)
        {
            try
            {
                parameters.Add("@ProfessionalLevelId", professionalLevel.ProfessionalLevelId.ToString());

                _repositoryConnection.SimpleExecuteCommand("DeleteProfessionalLevel", parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }        
    }
}
