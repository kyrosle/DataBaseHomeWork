using HomeWork.Share.Service;
using Newtonsoft.Json;
using RestSharp;

namespace HomeWork.App.Service
{
    internal class HttpRestClient
    {
        private readonly string apiUrl;
        protected readonly RestClient restClient;

        public HttpRestClient(string apiUrl)
        {
            this.apiUrl = apiUrl;
            restClient = new RestClient();
        }

        public async Task<ApiResponse> ExecuteAsync(BaseRequest baseRequest)
        {
            var request = new RestRequest(baseRequest.Method);
            request.AddHeader("Content-Type", baseRequest.ContentType);
            if (baseRequest.Parameter is not null)
                request.AddParameter("param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
            restClient.BaseUrl = new Uri(apiUrl + baseRequest.Route);

            var response = await restClient.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            else return new ApiResponse()
            {
                Status = false,
                Result = null,
                Message = response.ErrorMessage
            };
        }
        public async Task<ApiResponse<T>> ExecuteAsync<T>(BaseRequest baseRequest)
        {
            var request = new RestRequest(baseRequest.Method);
            request.AddHeader("Content-Type", baseRequest.ContentType);
            if (baseRequest.Parameter is not null)
                request.AddParameter("param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
            restClient.BaseUrl = new Uri(apiUrl + baseRequest.Route);

            var response = await restClient.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<ApiResponse<T>>(response.Content);
            else return new ApiResponse<T>()
            {
                Status = false,
                Message = response.ErrorMessage
            };
        }
    }
}
