using TallerConexionGeminiChaGPTGrupo4.Interfaces;
using TallerConexionGeminiChaGPTGrupo4.Models;

namespace TallerConexionGeminiChaGPTGrupo4.Repositories
{
    public class GeminiRepository : IChatBotService
    {
        HttpClient _httpClient;
        private string apiKey = "AIzaSyAWRxEriVFjv74UGbnDrCXDTx25XRRSuTM";
        
        public GeminiRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetChatBotResponse(string prompt)
        {
            string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key="+apiKey;
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, url);

            GeminiRequest requestBody = new GeminiRequest
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
            message.Content = JsonContent.Create<GeminiRequest>(requestBody);
            var response = await _httpClient.SendAsync(message);
            string answer = await response.Content.ReadAsStringAsync();
            return answer;

        }
    }
}
