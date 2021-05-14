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
    public class VacationOpportunityRepository : IVacationOpportunityRepository
    {
        private readonly IConfiguration _configuration;

        private readonly IRepositoryConnection _repositoryConnection;

        private readonly ICareerRepository _careerRepository;

        private readonly IProfessionalLevelRepository _professionalLevelRepository;

        private readonly IOpportunityTypeRepository _opportunityTypeRepository;

        private readonly Dictionary<string, string> parameters = new Dictionary<string, string>();

        public VacationOpportunityRepository(IConfiguration configuration, IRepositoryConnection repositoryConnection, 
                                             ICareerRepository careerRepository, IProfessionalLevelRepository professionalLevelRepository, 
                                             IOpportunityTypeRepository opportunityTypeRepository)
        {
            _configuration = configuration;
            _repositoryConnection = repositoryConnection;
            _careerRepository = careerRepository;
            _professionalLevelRepository = professionalLevelRepository;
            _opportunityTypeRepository = opportunityTypeRepository;
        }
        public List<VacationOpportunity> GetAllVacationOpportunities()
        {
            try
            {
                List<VacationOpportunity> listVacationOpportunities = new List<VacationOpportunity>();
                VacationOpportunity vacationOpportunity = null;

                var read = _repositoryConnection.SearchCommand("GetAllVacationOpportunities", parameters);

                DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(read);

                foreach(DataRow row in dataTable.Rows)
                {
                    vacationOpportunity = new VacationOpportunity();

                    vacationOpportunity.VacationOpportunityId = Convert.ToInt32(row["VacationOpportunityId"]);
                    vacationOpportunity.VacationOpeningNumber = row["VacationOpeningNumber"].ToString();
                    vacationOpportunity.VacationOpeningDate = Convert.ToDateTime(row["VacationOpeningDate"]);
                    vacationOpportunity.VacationOfferLetterDate = Convert.ToDateTime(row["VacationOfferLetterDate"]);
                    vacationOpportunity.VacationLeader = row["VacationLeader"].ToString();
                    vacationOpportunity.VacationCancellationDate = Convert.ToDateTime(row["VacationCancellationDate"]);
                    vacationOpportunity.VacationOpportunityStatus = Convert.ToBoolean(row["VacationOpportunityStatus"]);

                    vacationOpportunity.Career = new Career();
                    vacationOpportunity.Career.CareerId = Convert.ToInt32(row["CareerId"]);
                    vacationOpportunity.Career = _careerRepository.GetCareerById(vacationOpportunity.Career.CareerId);

                    vacationOpportunity.ProfessionalLevel = new ProfessionalLevel();
                    vacationOpportunity.ProfessionalLevel.ProfessionalLevelId = Convert.ToInt32(row["ProfessionalLevelId"]);
                    vacationOpportunity.ProfessionalLevel = _professionalLevelRepository.GetProfessionalLevelById(vacationOpportunity.ProfessionalLevel.ProfessionalLevelId);

                    vacationOpportunity.OpportunityType = new OpportunityType();
                    vacationOpportunity.OpportunityType.OpportunityTypeId = Convert.ToInt32(row["OpportunityTypeId"]);
                    vacationOpportunity.OpportunityType = _opportunityTypeRepository.GetOpportunityTypeById(vacationOpportunity.OpportunityType.OpportunityTypeId);

                    listVacationOpportunities.Add(vacationOpportunity);
                }
                return listVacationOpportunities;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public VacationOpportunity GetVacationOpportunityByVacationLeader(string vacationLeader)
        {
            try
            {
                VacationOpportunity vacationOpportunity = null;

                parameters.Add("@VacationLeader", vacationLeader);

                var read = _repositoryConnection.SearchCommand("GetVacationOpportunityByVacationLeader", parameters);

                DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(read);

                foreach (DataRow row in dataTable.Rows)
                {
                    vacationOpportunity = new VacationOpportunity();

                    vacationOpportunity.VacationOpportunityId = Convert.ToInt32(row["VacationOpportunityId"]);
                    vacationOpportunity.VacationOpeningNumber = row["VacationOpeningNumber"].ToString();
                    vacationOpportunity.VacationOpeningDate = Convert.ToDateTime(row["VacationOpeningDate"]);
                    vacationOpportunity.VacationOfferLetterDate = Convert.ToDateTime(row["VacationOfferLetterDate"]);
                    vacationOpportunity.VacationLeader = row["VacationLeader"].ToString();
                    vacationOpportunity.VacationCancellationDate = Convert.ToDateTime(row["VacationCancellationDate"]);
                    vacationOpportunity.VacationOpportunityStatus = Convert.ToBoolean(row["VacationOpportunityStatus"]);

                    vacationOpportunity.Career = new Career();
                    vacationOpportunity.Career.CareerId = Convert.ToInt32(row["CareerId"]);
                    vacationOpportunity.Career = _careerRepository.GetCareerById(vacationOpportunity.Career.CareerId);

                    vacationOpportunity.ProfessionalLevel = new ProfessionalLevel();
                    vacationOpportunity.ProfessionalLevel.ProfessionalLevelId = Convert.ToInt32(row["ProfessionalLevelId"]);
                    vacationOpportunity.ProfessionalLevel = _professionalLevelRepository.GetProfessionalLevelById(vacationOpportunity.ProfessionalLevel.ProfessionalLevelId);

                    vacationOpportunity.OpportunityType = new OpportunityType();
                    vacationOpportunity.OpportunityType.OpportunityTypeId = Convert.ToInt32(row["OpportunityTypeId"]);
                    vacationOpportunity.OpportunityType = _opportunityTypeRepository.GetOpportunityTypeById(vacationOpportunity.OpportunityType.OpportunityTypeId);
                }
                return vacationOpportunity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<VacationOpportunity> GetVacationOpportunityByOpeningDate(DateTime vacationOpeningDate)
        {
            try
            {
                List<VacationOpportunity> listVacationOpportunities = new List<VacationOpportunity>();
                VacationOpportunity vacationOpportunity = null;

                parameters.Add("@VacationOpeningDate", vacationOpeningDate.ToString());

                var read = _repositoryConnection.SearchCommand("GetVacationOpportunityByDateRegister", parameters);

                DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(read);

                foreach (DataRow row in dataTable.Rows)
                {
                    vacationOpportunity = new VacationOpportunity();

                    vacationOpportunity.VacationOpportunityId = Convert.ToInt32(row["VacationOpportunityId"]);
                    vacationOpportunity.VacationOpeningNumber = row["VacationOpeningNumber"].ToString();
                    vacationOpportunity.VacationOpeningDate = Convert.ToDateTime(row["VacationOpeningDate"]);
                    vacationOpportunity.VacationOfferLetterDate = Convert.ToDateTime(row["VacationOfferLetterDate"]);
                    vacationOpportunity.VacationLeader = row["VacationLeader"].ToString();
                    vacationOpportunity.VacationCancellationDate = Convert.ToDateTime(row["VacationCancellationDate"]);
                    vacationOpportunity.VacationOpportunityStatus = Convert.ToBoolean(row["VacationOpportunityStatus"]);

                    vacationOpportunity.Career = new Career();
                    vacationOpportunity.Career.CareerId = Convert.ToInt32(row["CareerId"]);
                    vacationOpportunity.Career = _careerRepository.GetCareerById(vacationOpportunity.Career.CareerId);

                    vacationOpportunity.ProfessionalLevel = new ProfessionalLevel();
                    vacationOpportunity.ProfessionalLevel.ProfessionalLevelId = Convert.ToInt32(row["ProfessionalLevelId"]);
                    vacationOpportunity.ProfessionalLevel = _professionalLevelRepository.GetProfessionalLevelById(vacationOpportunity.ProfessionalLevel.ProfessionalLevelId);

                    vacationOpportunity.OpportunityType = new OpportunityType();
                    vacationOpportunity.OpportunityType.OpportunityTypeId = Convert.ToInt32(row["OpportunityTypeId"]);
                    vacationOpportunity.OpportunityType = _opportunityTypeRepository.GetOpportunityTypeById(vacationOpportunity.OpportunityType.OpportunityTypeId);

                    listVacationOpportunities.Add(vacationOpportunity);
                }
                return listVacationOpportunities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertVacationOpportunity(VacationOpportunity vacationOpportunity)
        {
            try
            {
                parameters.Add("@VacationOpeningNumber", vacationOpportunity.VacationOpeningNumber);
                parameters.Add("@VacationOpeningDate", vacationOpportunity.VacationOpeningDate.ToString());
                parameters.Add("@VacationOfferLetterDate", vacationOpportunity.VacationOfferLetterDate.ToString());
                parameters.Add("@VacationLeader", vacationOpportunity.VacationLeader);
                parameters.Add("@VacationCancellationDate", vacationOpportunity.VacationCancellationDate.ToString());
                parameters.Add("@VacationOpportunityStatus", vacationOpportunity.VacationOpportunityStatus.ToString());
                parameters.Add("@OpportunityTypeId", vacationOpportunity.OpportunityType.OpportunityTypeId.ToString());
                parameters.Add("@CareerId", vacationOpportunity.Career.CareerId.ToString());
                parameters.Add("@ProfessionalLevelId", vacationOpportunity.ProfessionalLevel.ProfessionalLevelId.ToString());

                _repositoryConnection.SimpleExecuteCommand("InsertVacationOpportunity", parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateVacationOpportunity(VacationOpportunity vacationOpportunity)
        {
            try
            {
                parameters.Add("@VacationOpeningNumber", vacationOpportunity.VacationOpeningNumber);
                parameters.Add("@VacationOpeningDate", vacationOpportunity.VacationOpeningDate.ToString());
                parameters.Add("@VacationOfferLetterDate", vacationOpportunity.VacationOfferLetterDate.ToString());
                parameters.Add("@VacationLeader", vacationOpportunity.VacationLeader);
                parameters.Add("@VacationCancellationDate", vacationOpportunity.VacationCancellationDate.ToString());
                parameters.Add("@VacationOpportunityStatus", vacationOpportunity.VacationOpportunityStatus.ToString());
                parameters.Add("@VacationOpportunityId", vacationOpportunity.VacationOpportunityId.ToString());

                _repositoryConnection.SimpleExecuteCommand("UpdateVacationOpportunity", parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteVacationOpportunity(VacationOpportunity vacationOpportunity)
        {
            try
            {
                parameters.Add("@VacationOpportunityId", vacationOpportunity.VacationOpportunityId.ToString());
                _repositoryConnection.SimpleExecuteCommand("DeleteVacationOpportunity", parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }       
    }
}
