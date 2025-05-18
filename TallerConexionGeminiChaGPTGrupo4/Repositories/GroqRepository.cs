using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TallerConexionGeminiChaGPTGrupo4.Interfaces;
using TallerConexionGeminiChaGPTGrupo4.Models;

namespace TallerConexionGeminiChaGPTGrupo4.Repositories
{
    public class GroqRepository : IGroqRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GroqRepository(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<string> GetResponseAsync(string prompt)
        {
            string url = $"https://api.groq.ai/v1/chat/completions"; // Ajusta la URL según documentación oficial

            var requestBody = new
            {
                model = "groq-3.5-turbo",  // Ajusta según el modelo que uses
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };

            // Agrega la apiKey en el header si así lo requiere la API de Groq
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

            var response = await _httpClient.PostAsJsonAsync(url, requestBody);
            response.EnsureSuccessStatusCode();

            var answer = await response.Content.ReadAsStringAsync();
            return answer;
        }
    }
}
