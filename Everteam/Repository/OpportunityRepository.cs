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
    public class OpportunityRepository : IOpportunityRepository
    {
        private readonly IConfiguration _configuration;

        private readonly IRepositoryConnection _repositoryConnection;

        private readonly ICareerRepository _careerRepository;

        private readonly IServiceRepository _serviceRepository;

        private readonly IProfessionalLevelRepository _professionalLevelRepository;

        private readonly IOpportunityTypeRepository _opportunityTypeRepository;

        private readonly Dictionary<string, string> parameters = new Dictionary<string, string>();

        public OpportunityRepository(IConfiguration configuration, ICareerRepository careerRepository, 
                                     IServiceRepository serviceRepository, IProfessionalLevelRepository professionalLevelRepository, 
                                     IOpportunityTypeRepository opportunityTypeRepository, IRepositoryConnection repositoryConnection)
        {
            _configuration = configuration;
            _careerRepository = careerRepository;
            _serviceRepository = serviceRepository;
            _professionalLevelRepository = professionalLevelRepository;
            _opportunityTypeRepository = opportunityTypeRepository;
            _repositoryConnection = repositoryConnection;
        }

        public List<Opportunity> GetAllOpportunities()
        {
            try
            {
                List<Opportunity> listOpportunities = new List<Opportunity>();
                Opportunity opportunity = null;

                var read = _repositoryConnection.SearchCommand("GetAllOpportunities", parameters);

                DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(read);

                foreach (DataRow row in dataTable.Rows)     
                {
                    opportunity = new Opportunity();

                    opportunity.OpportunityId = Convert.ToInt32(row["OpportunityId"]);
                    opportunity.OpportunityName = row["OpportunityName"].ToString();
                    opportunity.OpportunityRequirements = row["OpportunityRequirements"].ToString();
                    opportunity.DesirableRequirements = row["DesirableRequirements"].ToString();
                    opportunity.DateRegister = Convert.ToDateTime(row["DateRegister"]);
                    opportunity.ClosingDate = Convert.ToDateTime(row["ClosingDate"]);
                    opportunity.CancellationDate = Convert.ToDateTime(row["CancellationDate"]);
                    opportunity.OpportunityStatus = Convert.ToBoolean(row["OpportunityStatus"]);

                    opportunity.Career = new Career();
                    opportunity.Career.CareerId = Convert.ToInt32(row["CareerId"]);
                    opportunity.Career = _careerRepository.GetCareerById(opportunity.Career.CareerId);

                    opportunity.Service = new Service();
                    opportunity.Service.ServiceId = Convert.ToInt32(row["ServiceId"]);
                    opportunity.Service = _serviceRepository.GetServiceById(opportunity.Service.ServiceId);

                    opportunity.ProfessionalLevel = new ProfessionalLevel();
                    opportunity.ProfessionalLevel.ProfessionalLevelId = Convert.ToInt32(row["ProfessionalLevelId"]);
                    opportunity.ProfessionalLevel = _professionalLevelRepository.GetProfessionalLevelById(opportunity.ProfessionalLevel.ProfessionalLevelId);

                    opportunity.OpportunityType = new OpportunityType();
                    opportunity.OpportunityType.OpportunityTypeId = Convert.ToInt32(row["OpportunityTypeId"]);
                    opportunity.OpportunityType = _opportunityTypeRepository.GetOpportunityTypeById(opportunity.OpportunityType.OpportunityTypeId);

                    listOpportunities.Add(opportunity);
                }
                return listOpportunities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Opportunity GetOpportunityByName(string opportunityName)
        {
            try
            {
                Opportunity opportunity = null;

                parameters.Add("@OpportunityName", opportunityName);

                var read = _repositoryConnection.SearchCommand("GetOpportunityByName", parameters);

                DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(read);

                foreach (DataRow row in dataTable.Rows)
                {
                    opportunity = new Opportunity();

                    opportunity.OpportunityId = Convert.ToInt32(row["OpportunityId"]);
                    opportunity.OpportunityName = row["OpportunityName"].ToString();
                    opportunity.OpportunityRequirements = row["OpportunityRequirements"].ToString();
                    opportunity.DesirableRequirements = row["DesirableRequirements"].ToString();
                    opportunity.DateRegister = Convert.ToDateTime(row["DateRegister"]);
                    opportunity.ClosingDate = Convert.ToDateTime(row["ClosingDate"]);
                    opportunity.CancellationDate = Convert.ToDateTime(row["CancellationDate"]);
                    opportunity.OpportunityStatus = Convert.ToBoolean(row["OpportunityStatus"]);

                    opportunity.Career = new Career();
                    opportunity.Career.CareerId = Convert.ToInt32(row["CareerId"]);
                    opportunity.Career = _careerRepository.GetCareerById(opportunity.Career.CareerId);

                    opportunity.Service = new Service();
                    opportunity.Service.ServiceId = Convert.ToInt32(row["ServiceId"]);
                    opportunity.Service = _serviceRepository.GetServiceById(opportunity.Service.ServiceId);

                    opportunity.ProfessionalLevel = new ProfessionalLevel();
                    opportunity.ProfessionalLevel.ProfessionalLevelId = Convert.ToInt32(row["ProfessionalLevelId"]);
                    opportunity.ProfessionalLevel = _professionalLevelRepository.GetProfessionalLevelById(opportunity.ProfessionalLevel.ProfessionalLevelId);

                    opportunity.OpportunityType = new OpportunityType();
                    opportunity.OpportunityType.OpportunityTypeId = Convert.ToInt32(row["OpportunityTypeId"]);
                    opportunity.OpportunityType = _opportunityTypeRepository.GetOpportunityTypeById(opportunity.OpportunityType.OpportunityTypeId);
                }
                return opportunity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void InsertOpportunity(Opportunity opportunity)
        {
            try
            {
                parameters.Add("@OpportunityName", opportunity.OpportunityName);
                parameters.Add("@OpportunityRequirements", opportunity.OpportunityRequirements);
                parameters.Add("@DesirableRequirements", opportunity.DesirableRequirements);
                parameters.Add("@DateRegister", opportunity.DateRegister.ToString());
                parameters.Add("@ClosingDate", opportunity.ClosingDate.ToString());
                parameters.Add("@CancellationDate", opportunity.CancellationDate.ToString());
                parameters.Add("@OpportunityStatus", opportunity.OpportunityStatus.ToString());
                parameters.Add("@CareerId", opportunity.Career.CareerId.ToString());
                parameters.Add("@ProfessionalLevelId", opportunity.ProfessionalLevel.ProfessionalLevelId.ToString());
                parameters.Add("@ServiceId", opportunity.Service.ServiceId.ToString());
                parameters.Add("@OpportunityTypeId", opportunity.OpportunityType.OpportunityTypeId.ToString());

                _repositoryConnection.SimpleExecuteCommand("InsertOpportunity", parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateOpportunity(Opportunity opportunity)
        {
            try
            {
                parameters.Add("@OpportunityName", opportunity.OpportunityName);
                parameters.Add("@OpportunityRequirements", opportunity.OpportunityRequirements);
                parameters.Add("@DesirableRequirements", opportunity.DesirableRequirements);
                parameters.Add("@DateRegister", opportunity.DateRegister.ToString());
                parameters.Add("@ClosingDate", opportunity.ClosingDate.ToString());
                parameters.Add("@CancellationDate", opportunity.CancellationDate.ToString());
                parameters.Add("@OpportunityStatus", opportunity.OpportunityStatus.ToString());
                parameters.Add("@OpportunityId", opportunity.OpportunityId.ToString());

                _repositoryConnection.SimpleExecuteCommand("UpdateOpportunity", parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public void DeleteOpportunity(Opportunity opportunity)
        {
            parameters.Add("@OpportunityId", opportunity.OpportunityId.ToString());
            _repositoryConnection.SimpleExecuteCommand("DeleteOpportunity", parameters);
        }
    }
}
