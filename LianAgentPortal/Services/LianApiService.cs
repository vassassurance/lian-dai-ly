using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Hangfire;
using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Data;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.BaseInsurance;
using LianAgentPortal.Models.ViewModels.InsuranceAutomobileDetail;
using LianAgentPortal.Models.ViewModels.InsuranceMotorDetail;
using LianAgentPortal.Models.ViewModels.LianAgent;
using LianAgentPortal.Models.ViewModels.LianInsurance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace LianAgentPortal.Services
{
    public interface ILianApiService
    {
        CalculateInsurancePremiumResponse CalculatePremiumInsuranceAutomobileDetail(InsuranceAutomobileDetail detail, LianAgentApiKey apiKey);
        BuyInsuranceApiResponse BuyInsuranceAutomobile(InsuranceAutomobileDetail detail, LianAgentApiKey apiKey);


        CalculateInsurancePremiumResponse CalculatePremiumInsuranceMotorDetail(InsuranceMotorDetail detail, LianAgentApiKey apiKey);
        BuyInsuranceApiResponse BuyInsuranceMotor(InsuranceMotorDetail detail, LianAgentApiKey apiKey);


        LianInsuranceDetailResponseViewModel GetDetailLianInsurance(string lianTransaction, LianAgentApiKey apiKey);
        LianInsuranceSearchResponseViewModel SearchLianInsurance(ListLianInsuranceJqGridRequestViewModel jqgridRequest, LianAgentApiKey apiKey);
    }
    public class LianApiService : ILianApiService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IBackgroundJobClient _backgroundJobs;

        public LianApiService(ApplicationDbContext db, IMapper mapper, IBackgroundJobClient backgroundJobs, IConfiguration configuration)
        {
            _db = db;
            _mapper = mapper;
            _backgroundJobs = backgroundJobs;
            _configuration = configuration;
        }
        #region Automobile
        public BuyInsuranceApiResponse BuyInsuranceAutomobile(InsuranceAutomobileDetail detail, LianAgentApiKey apiKey)
        {
            try
            {
                string path = "/be/lian/postpaid/buyInsurance";

                BuyInsuranceAutomobileViewModel model = _mapper.Map<BuyInsuranceAutomobileViewModel>(detail);

                string payload = System.Text.Json.JsonSerializer.Serialize(model, GeneralConstants.CamelCaseJsonSerializerOptions);

                return MakePostRequest<BuyInsuranceApiResponse>(path, payload, apiKey);
            }
            catch (Exception ex)
            {
                return new BuyInsuranceApiResponse()
                {
                    Code = (long)BuyInsuranceResultEnum.UNKNOWN_ERROR,
                    Message = ex.Message
                };
            }
        }
        public CalculateInsurancePremiumResponse CalculatePremiumInsuranceAutomobileDetail(InsuranceAutomobileDetail detail, LianAgentApiKey apiKey)
        {
            try
            {
                string path = "/be/lian/calculateInsuranceFee";
                CalculateInsurancePremium<CalculateInsurancePremiumDetailAutomobile> model = _mapper.Map<CalculateInsurancePremium<CalculateInsurancePremiumDetailAutomobile>>(detail);
                string payload = System.Text.Json.JsonSerializer.Serialize(model, GeneralConstants.CamelCaseJsonSerializerOptions);

                CalculateInsurancePremiumResponse result = MakePostRequest<CalculateInsurancePremiumResponse>(path, payload, apiKey);
                if (result.Code == (long)CalculateInsurancePremiumResultEnum.SUCCESS && result.Data.TotalAmount <= 0)
                {
                    return new CalculateInsurancePremiumResponse()
                    {
                        Code = (long)CalculateInsurancePremiumResultEnum.ERROR,
                        Message = "Không tìm thấy biểu phí"
                    };
                }
                return result;

            }
            catch (Exception ex)
            {
                return new CalculateInsurancePremiumResponse()
                {
                    Code = (long)CalculateInsurancePremiumResultEnum.ERROR,
                    Message = ex.Message
                };
            }

        }
        #endregion

        #region Motor
        public BuyInsuranceApiResponse BuyInsuranceMotor(InsuranceMotorDetail detail, LianAgentApiKey apiKey)
        {
            try
            {
                string path = "/be/lian/postpaid/buyInsurance";

                BuyInsuranceMotorViewModel model = _mapper.Map<BuyInsuranceMotorViewModel>(detail);

                string payload = System.Text.Json.JsonSerializer.Serialize(model, GeneralConstants.CamelCaseJsonSerializerOptions);
                return MakePostRequest<BuyInsuranceApiResponse>(path, payload, apiKey);
            }
            catch (Exception ex)
            {
                return new BuyInsuranceApiResponse()
                {
                    Code = (long)BuyInsuranceResultEnum.UNKNOWN_ERROR,
                    Message = ex.Message
                };
            }

        }
        public CalculateInsurancePremiumResponse CalculatePremiumInsuranceMotorDetail(InsuranceMotorDetail detail, LianAgentApiKey apiKey)
        {
            try
            {
                string path = "/be/lian/calculateInsuranceFee";
                CalculateInsurancePremium<CalculateInsurancePremiumDetailMotor> model = _mapper.Map<CalculateInsurancePremium<CalculateInsurancePremiumDetailMotor>>(detail);
                string payload = System.Text.Json.JsonSerializer.Serialize(model, GeneralConstants.CamelCaseJsonSerializerOptions);
                return MakePostRequest<CalculateInsurancePremiumResponse>(path, payload, apiKey);
            }
            catch (Exception ex)
            {
                return new CalculateInsurancePremiumResponse()
                {
                    Code = (long)CalculateInsurancePremiumResultEnum.ERROR,
                    Message = ex.Message
                };
            }

        }
        #endregion
        
        #region LianInsurance
        public LianInsuranceDetailResponseViewModel GetDetailLianInsurance(string lianTransaction, LianAgentApiKey apiKey)
        {
            string path = "/be/lian/insurance/detail";
            string payload = "{\"transaction\":\"" + lianTransaction + "\"}";
            return MakePostRequest<LianInsuranceDetailResponseViewModel>(path, payload, apiKey);

        }
        public LianInsuranceSearchResponseViewModel SearchLianInsurance(ListLianInsuranceJqGridRequestViewModel jqgridRequest, LianAgentApiKey apiKey)
        {
            try
            {
                string path = "/be/lian/insurances";

                int start = jqgridRequest.page == 1 ? 0 : ((jqgridRequest.page - 1) * jqgridRequest.rows);
                string sortObject = "{\"createdAt\":-1}";
                if (jqgridRequest.sidx == "CreatedAt")
                {
                    if (jqgridRequest.sord == "desc")
                    {
                        sortObject = "{\"createdAt\":-1}";
                    }
                    else
                    {
                        sortObject = "{\"createdAt\":1}";
                    }
                }
                else if (jqgridRequest.sidx == "ExpiredDate")
                {
                    if (jqgridRequest.sord == "desc")
                    {
                        sortObject = "{\"expiredDate\":-1}";
                    }
                    else
                    {
                        sortObject = "{\"expiredDate\":1}";
                    }
                }

                string payload = "{\"filter\":{\"search\":\"" + jqgridRequest.Search + "\",\"accountIds\":[],\"isIncludeCommission\":true},\"paging\":{\"start\":" + start + ",\"limit\":" + jqgridRequest.rows + "},\"sort\":" + sortObject + "}";

                return MakePostRequest<LianInsuranceSearchResponseViewModel>(path, payload, apiKey);
            }
            catch (Exception ex)
            {
                return new LianInsuranceSearchResponseViewModel()
                {
                    Code = 500,
                    Message = ex.Message,
                };
            }
        }

        #endregion

        private TResult MakePostRequest<TResult>(string path, string payload, LianAgentApiKey apiKey)
        {
            string xApiValidate = Commons.Functions.MD5Hash(path + "POST" + payload + apiKey.SecretKey);
            string apiEndPoint = _configuration[AppSettingConfigKeyConstants.LianBaseApi] + path;

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, apiEndPoint);
            request.Headers.Add("x-api-client", apiKey.AppId);
            request.Headers.Add("x-api-validate", xApiValidate);
            request.Content = new StringContent(payload);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = client.Send(request);
            response.EnsureSuccessStatusCode();
            var taskReadString = response.Content.ReadAsStringAsync();
            taskReadString.Wait();
            string responseBody = taskReadString.Result;
            return JsonConvert.DeserializeObject<TResult>(responseBody);
        }

    }
}
