using LianAgentPortal.Models.ViewModels.BaseInsurance;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LianAgentPortal.Services
{
    public interface ILianApiService
    {
        CalculateInsuranceFeeResponse CalculateInsuranceFee();
    }
    public class LianApiService : ILianApiService
    {
        private string _appid;
        private string _secretKey;
        public LianApiService()
        {

        }

        public CalculateInsuranceFeeResponse CalculateInsuranceFee()
        {
            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://sbx-gapi.lian.vn/be/lian/insurances");

            request.Headers.Add("x-api-client", "27472747");
            request.Headers.Add("x-api-validate", "1f00b314c38a37a4c6b5fd7c459ded98");

            request.Content = new StringContent("{\"filter\":{\"filterType\":\"SUCCEEDED\",\"search\":\"NGUYEN VAN A\",\"accountIds\":[],\"isIncludeCommission\":true},\"paging\":{\"start\":1,\"limit\":20},\"sort\":{\"paymentAt\":-1,\"createdAt\":-1}}");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return new CalculateInsuranceFeeResponse();
        }
    }
}
