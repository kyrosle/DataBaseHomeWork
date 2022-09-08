using RestSharp;
namespace HomeWork.App.Service
{
    internal class BaseRequest
    {
        public Method Method { get; set; }
        public string Route { get; set; }
        public string ContentType { get; set; } = "application/json";
        public object Parameter { get; set; }
    }
}
