using AutoMapper;
using Minimal_Web_API.DTO;
using Minimal_Web_API.Models;
using Minimal_Web_API.Repositories;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Minimal_Web_API.Services
{
    public class StopService
    {
        private readonly string filePath = $"{Environment.CurrentDirectory}/Resources/stops.json";

        private readonly StopRepository _stopRepository;
        private readonly IMapper _mapper;

        public StopService(StopRepository stopRepository, IMapper mapper)
        {
            _stopRepository = stopRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetStopDTO>> GetStops()
        {
            RestResponse response = await GetResponseFromAPI(
                $"https://ckan.multimediagdansk.pl",
                $"/dataset/c24aa637-3619-4dc2-a171-a23eec8f2172/resource/4c4025f0-01bf-41f7-a39f-d156d201b82b/download/stops.json");

            if (response.IsSuccessful)
            {
                SaveResponseToFile(response);
                var stops = ConvertResponseToStopsList(response).Where(s => s.Name != null);
                _stopRepository.AddStops(stops);
                return stops.Select(s => _mapper.Map<GetStopDTO>(s)).ToList(); ;
            }

            return new List<GetStopDTO>();
        }

        public async Task<StopTimetable> GetStopTimetableByStopId(string stopId)
        {
            RestResponse response = await GetResponseFromAPI(
                $"http://ckan2.multimediagdansk.pl",
                $"/delays?stopId={stopId}");

            if (response.IsSuccessful)
                return ConvertResponseToStopTimetable(response);

            return new StopTimetable();
        }

        private async Task<RestResponse> GetResponseFromAPI(string baseUrl, string resource)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.Get);
            var response = await client.ExecuteAsync(request);
            return response;
        }

        private void SaveResponseToFile(RestResponse response)
        {
            var json = response.Content;
            File.WriteAllText(filePath, json);
        }

        private static IEnumerable<Stop> ConvertResponseToStopsList(RestResponse response)
        {
            var stopsData = JObject.Parse(response.Content);
            var stops = stopsData[DateTime.Now.ToString("yyyy-MM-dd")]["stops"].ToObject<Stop[]>().ToList();
            return stops;
        }

        private static StopTimetable ConvertResponseToStopTimetable(RestResponse response)
        {
            var stopTimetableData = JObject.Parse(response.Content);
            var stopTimetable = stopTimetableData.ToObject<StopTimetable>();
            return stopTimetable;
        }
    }
}
