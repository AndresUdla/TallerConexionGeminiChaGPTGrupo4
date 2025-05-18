using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TallerConexionGeminiChaGPTGrupo4.Interfaces;
using TallerConexionGeminiChaGPTGrupo4.Models;

namespace TallerConexionGeminiChaGPTGrupo4.Repositories
{
    public class GeminiRepository : IGeminiRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        // Recibe HttpClient y apiKey desde afuera (ideal para inyección de dependencias)
        public GeminiRepository(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<string> GetResponseAsync(string prompt)
        {
            string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={_apiKey}";

            var requestBody = new GeminiRequest
            {
                contents = new List<Content>
                {
                    new Content
                    {
                        parts = new List<Part>
                        {
                            new Part
                            {
                                text = prompt
                            }
                        }
                    }
                }
            };

            var response = await _httpClient.PostAsJsonAsync(url, requestBody);
            response.EnsureSuccessStatusCode();

            var answer = await response.Content.ReadAsStringAsync();
            return answer;
        }
    }
}
