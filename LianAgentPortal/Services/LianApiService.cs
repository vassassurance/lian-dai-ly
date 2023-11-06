using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Hangfire;
using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Commons.Enums;
using LianAgentPortal.Data;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.BaseInsurance;
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
        CalculateInsurancePremiumResponse CalculatePremiumInsuranceMotorDetail(InsuranceMotorDetail detail, LianAgentApiKey apiKey);
        BuyInsuranceApiResponse BuyInsuranceMotor(InsuranceMotorDetail detail, LianAgentApiKey apiKey);
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
                return JsonConvert.DeserializeObject<LianInsuranceSearchResponseViewModel>(responseBody);
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

        public BuyInsuranceApiResponse BuyInsuranceMotor(InsuranceMotorDetail detail, LianAgentApiKey apiKey)
        {
            try
            {
                string path = "/be/lian/postpaid/buyInsurance";

                BuyInsuranceMotorViewModel model = _mapper.Map<BuyInsuranceMotorViewModel>(detail);

                string payload = System.Text.Json.JsonSerializer.Serialize(model, GeneralConstants.CamelCaseJsonSerializerOptions);
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
                return JsonConvert.DeserializeObject<BuyInsuranceApiResponse>(responseBody);
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
                return JsonConvert.DeserializeObject<CalculateInsurancePremiumResponse>(responseBody);
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

        private void Test(LianAgentApiKey apiKey)
        {

			string path = "/be/lian/insurances";
			string payload = "{\"filter\":{\"filterType\":\"SUCCEEDED\",\"search\":\"NGUYEN VAN A\",\"accountIds\":[],\"isIncludeCommission\":true},\"paging\":{\"start\":1,\"limit\":20},\"sort\":{\"paymentAt\":-1,\"createdAt\":-1}}";
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

        }
    }
}
