using RestSharp;

namespace Minimal_Web_API.Services
{
    public class DataService
    {
        private readonly string filePath = $"{Environment.CurrentDirectory}/Resources/stops.json";
        
        public async Task<RestResponse> GetResponseFromAPI(string baseUrl, string resource)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.Get);
            var response = await client.ExecuteAsync(request);
            return response;
        }

        public void SaveResponseToFile(RestResponse response)
        {
            var json = response.Content;
            File.WriteAllText(filePath, json);
        }
    }
}
