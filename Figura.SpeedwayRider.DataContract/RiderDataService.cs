using Figura.SpeedwayRider.Model.DAO;
using Newtonsoft.Json;
using System.Text;

namespace Figura.SpeedwayRider.DataContract
{
    public class RiderDataService : IRiderDataService
    {
        public RiderDataService()
        {
            
        }

        public async Task<List<Rider>> FetchByInitials(List<Rider> body)
        {
            string link = "http://localhost:5001/Rider/InitialRiders";

            HttpClient _httpClient = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, link);

            string jsonContent = JsonConvert.SerializeObject(body);

            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await _httpClient.SendAsync(request);

            var jsonString = await responseMessage.Content.ReadAsStringAsync();

            List<Rider> res = JsonConvert.DeserializeObject<List<Rider>>(jsonString)!;

            return res;
        }

        public async Task<List<Rider>> GetAllRiders(string url)
        {
            HttpClient _httpClient = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            HttpResponseMessage responseMessage = await _httpClient.SendAsync(request);

            var jsonString = await responseMessage.Content.ReadAsStringAsync();

            List<Rider> res = JsonConvert.DeserializeObject<List<Rider>>(jsonString)!;

            return res;
        }
    }
}
