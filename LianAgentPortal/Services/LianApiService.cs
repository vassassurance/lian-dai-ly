using LianAgentPortal.Data;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.BaseInsurance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LianAgentPortal.Services
{
    public interface ILianApiService
    {
        CalculateInsuranceFeeResponse CalculateInsuranceFee();
        void SetUserInfo(string username);
    }
    public class LianApiService : ILianApiService
    {
        private string _appid = "";
        private string _secretKey = "";
        private string _lianBaseApi = "https://sbx-gapi.lian.vn";

        private readonly ApplicationDbContext _db;


		public LianApiService(ApplicationDbContext db)
        {
            _db = db;
		}

        public void SetUserInfo(string username)
        {
            var userRequest = _db.Users.Include(item => item.LianAgent).FirstOrDefault(item => item.UserName == username);
            if (userRequest == null || userRequest.LianAgent == null) throw new KeyNotFoundException(username);
			this._appid = userRequest.LianAgent.AppId;
			this._secretKey = userRequest.LianAgent.SecretKey;
		}

		public CalculateInsuranceFeeResponse CalculateInsuranceFee()
        {

			string path = "/be/lian/insurances";
			string payload = "{\"filter\":{\"filterType\":\"SUCCEEDED\",\"search\":\"NGUYEN VAN A\",\"accountIds\":[],\"isIncludeCommission\":true},\"paging\":{\"start\":1,\"limit\":20},\"sort\":{\"paymentAt\":-1,\"createdAt\":-1}}";
			string xApiValidate = Commons.Functions.MD5Hash(path + "POST" + payload + _secretKey);
            string apiEndPoint = _lianBaseApi + path;

			HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, apiEndPoint);
            request.Headers.Add("x-api-client", _appid);
            request.Headers.Add("x-api-validate", xApiValidate);
			request.Content = new StringContent(payload);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = client.Send(request);
            response.EnsureSuccessStatusCode();
            var taskReadString = response.Content.ReadAsStringAsync();
            taskReadString.Wait();
			string responseBody = taskReadString.Result;

            return new CalculateInsuranceFeeResponse();
        }
    }
}
