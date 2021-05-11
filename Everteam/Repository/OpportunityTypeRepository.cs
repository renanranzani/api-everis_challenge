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
    public class OpportunityTypeRepository : IOpportunityTypeRepository
    {
        private readonly IConfiguration _configuration;

        private readonly IRepositoryConnection _repositoryConncetion;

        private readonly Dictionary<string, string> parameters = new Dictionary<string, string>();

        public OpportunityTypeRepository(IConfiguration configuration, IRepositoryConnection repositoryConnection)
        {
            _configuration = configuration;
            _repositoryConncetion = repositoryConnection;
        }

        public List<OpportunityType> GetAllOpportunityTypes()
        {
            try
            {
                List<OpportunityType> listOpportunityTypes = new List<OpportunityType>();
                OpportunityType opportunityType = null;

                var read = _repositoryConncetion.SearchCommand("GetAllOpportunityTypes", parameters);

                DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(read);

                foreach (DataRow row in dataTable.Rows)
                {
                    opportunityType = new OpportunityType();

                    opportunityType.OpportunityTypeId = Convert.ToInt32(row["OpportunityTypeId"]);
                    opportunityType.OpportunityName = row["OpportunityName"].ToString();
                    opportunityType.DateRegister = Convert.ToDateTime(row["DateRegister"]);
                    opportunityType.OpportunityTypeStatus = Convert.ToBoolean(row["OpportunityTypeStatus"]);

                    listOpportunityTypes.Add(opportunityType);
                }
                return listOpportunityTypes;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public OpportunityType GetOpportunityTypeById(int opportunityTypeId)
        {
            try
            {
                OpportunityType opportunityType = null;

                parameters.Clear();
                parameters.Add("@OpportunityTypeId", opportunityTypeId.ToString());

                var read = _repositoryConncetion.SearchCommand("GetOpportunityTypeById", parameters);

                DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(read);

                foreach (DataRow row in dataTable.Rows)
                {
                    opportunityType = new OpportunityType();

                    opportunityType.OpportunityTypeId = Convert.ToInt32(row["OpportunityTypeId"]);
                    opportunityType.OpportunityName = row["OpportunityName"].ToString();
                    opportunityType.DateRegister = Convert.ToDateTime(row["DateRegister"]);
                    opportunityType.OpportunityTypeStatus = Convert.ToBoolean(row["OpportunityTypeStatus"]);
                }
                return opportunityType;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int InsertOpportunityType(OpportunityType opportunityType)
        {
            try
            {
                parameters.Add("@OpportunityName", opportunityType.OpportunityName);
                parameters.Add("@DateRegister", opportunityType.DateRegister.ToString());
                parameters.Add("@OpportunityTypeStatus", opportunityType.OpportunityTypeStatus.ToString());

                int opportunityTypeId = _repositoryConncetion.InsertCommand("InsertOpportunityType", parameters);

                return opportunityTypeId;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateOpportunityType(OpportunityType opportunityType)
        {
            try
            {
                parameters.Add("@OpportunityName", opportunityType.OpportunityName);
                parameters.Add("@DateRegister", opportunityType.DateRegister.ToString());
                parameters.Add("@OpportunityTypeStatus", opportunityType.OpportunityTypeStatus.ToString());
                parameters.Add("@OpportunityTypeId", opportunityType.OpportunityTypeId.ToString());

                _repositoryConncetion.SimpleExecuteCommand("UpdateOpportunityType", parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteOpportunityType(OpportunityType opportunityType)
        {
            try
            {
                parameters.Add("@OpportunityTypeId", opportunityType.OpportunityTypeId.ToString());

                _repositoryConncetion.SimpleExecuteCommand("DeleteOpportunityType", parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
